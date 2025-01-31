# Summary of Outstanding Questions

Old vs. new structure
- Previously, built applications using POC 
- David M. (PACE Discovery architect) built out the sequence diagrams and changed the structure
- Code stuff
- Restructuring repos for Geolocation and Vehicle this PI
- Causing issues because was using UI
- Not gonna have an API, so development is going to shift toward building out that test UI

## Characteristic Development Features
- If Characteristic Engine is still being developed, how are we developing characteristics?

Data Validation Strategy?  Testing strategy?
There's validation for the geolocation domain
Columbia has a user story in this PI to come up a data validation strategy 
**Sam ask in PO Sync**

Persistence & retrieval strategy
- Geolocation structure is following the overall strategy, just need to switch over to the Cosmos DB 
- set up containers = sub-grouping in cosmos = table = store - 1 for raw data, 1 for info to refine it, 1 for refined characteristics

## Publish Refined Characteristics
- If Characteristic Engine is still being developed, how are we developing characteristics?  Using mock data for now, so we'll need to come back and revise it later once we implement the characteristic engine in Operator Domain.  When will that be?
- This is impacted by the overall flow of the GTR System since we'll need to know when/where/how to signal that we're done refining characteristics.

- sPACE force has feature for domain consumption in 1st iteration & PACE Columbia are working with them to see if sPACE Force can take Char Engine and put it in their domain (documentation finished this week by Columbia sufficient to get teams going)
-  PACE Columbia will continue enhancing the characteristic engine along the way
-  User story for PACE Columbia where they are putting characteristic engine in operator domain, working on it now (Mona and Balaji (sp?) - checking to see if it's done done
- sPACE Force - vehicle, geolocation domain
- Mock the input data like we do with the test harness UI 
- PACE Columbia is working on max named insured age assumes we get the named insured indicator



## Expand Data Persistence Strategy
- This [Raw Data Persistence User Story](https://dev.azure.com/InsuranceCo/PACE%20and%20PURE/_workitems/edit/5934049) says that we need retention ID, operator ID, policy ID, and application ID.  Where did this come from?
    - If this is accurate, then the conversation regarding Nikki's team's modifications to the test harness apply.
-  We need a clear definition of done for this feature.
-  Is Geolocation a working prototype of the Data Persistence Strategy or not?
-  Can we update the Data Persistence Strategy to guide folks to their tech specs for specific information regarding what to store?
-  Are all business rules that we need to consider in the DREAM tool?  If not, where else do we need to look for these?  (I assume that the characteristic definition rules are coming from the characteristic features directly.)

## Overall InsuranceCo Tiering & Rating (GTR) System
-  Can Nikki confirm that Premium Calculation will not store any operator data/chars and there won't be any overlap in terms of what's stored between Prem Calc & Operator domains?  

-  Is the characteristic assembly the same as the characteristic engine?
- Is Premium Saga part of the Premium Calculation domain
-  **Question for David Holland:** Once the domain identifies the characteristics to be refined based on the product ID aka product version, does it interact directly with the FE to get the data it needs for those characteristics? Or is all data passed to the domain proactively?
- Assembly & saga are related terms 


** Premium Calc will (Kevin) receive start application command and publish it based on the sequence diagrams and connect to the test harness UI
Different IDs:  policy ID, application ID, retention ID, operator ID
Application ID - premium calc had that work last sprint
There's an exploration feature to figure out the life cycle of these IDs -> not sure who is assigned to it
https://InsuranceCo.visualstudio.com/PACE%20and%20PURE/_workitems/edit/5864805
PACE Columbia demoed the Application ID feature - use these demos


**Specifically regarding the Test UI, but it should mimic the overall system, so 

- There was confusion around whether we need to connect the UI to a Cosmos DB or not.  Jim Keller & David Holland advised that we (the PACE Discovery team) think through the use case to determine whether this is needed.
    - We need to be able to store the data to a Cosmos DB.
     - **James Vawter**: Should teams access CosmosDb directly from the UI or use an eventing pattern to request the data in line with the work that sPACE force did in PI-1?  
     - **David Holland**:  In order to retrieve data at rest in a store, you will need to call it synchronously.  It can then be pushed to an ASB once in memory to make available for other domains, but right now the use case is to be able to retrieve and view the data that has been stored in the DB (vs. posting to a queue for another domain to use)
    - **James Vawter**:  Would each domain need to set up an api for retrieval from each container (raw data and char)? I think there were security concerns from EA with the test harness accessing the dbs directly. Come to think of it, they may have made a suggestion for accessing the data that doesn't directly expose the db to the UI layer. I'll have to dig through my emails later to see what the recommendation was. Away from my desk at the moment. 
- We need to collaborate with the other Product Owners to understand how the Premium Calculation, Operator, Vehicle, and Geolocation domains will be integrated in the UI and what each page will need to do.
    - **Decision:  Display & store all 4 IDs**
    - **Recommendation: PACE Columbia can build in functionality into the UI to generate and pass all 4 IDs to the domains.  The Premium Calculation domain would kick off the application process, start the saga to provide/generate the various IDs, and then pass those to every other domain.** 
        - Consider whether to conditionally auto-generate the other IDs (so if 1 ID is left blank, auto-generate it; otherwise, use the ID provided).  This would allow us to provide an application ID instead of creating a new one whenever you try to add on an additional operator.  We do not currently do this, which means that we autogenerate a new ID every time we add an operator, so we cannot test multiple operator policies/quotes.
        - If PACE Columbia agrees, when will that happen?
        - As a team, we should have a workaround for now to eliminate the dependency.
- When should we expect each ID type?
    - NBUS:  We expect **both** Operator ID **and** Application ID.  (No Policy ID and no Retention ID.)
    - RENL:  We expect **all 4 IDs**: Policy ID, Retention ID, Operator ID, and Application ID.



- With Azure services like ASB and Cosmos DB, you are posting/receiving a message to/from those.

- UI is non-trusted.  Cosmos DB is trusted.  Can we trust the trusted to the non-trusted?  Need to white list the UI so both systems can share the data.
- From the local, when trying to connect, facing some issues.  This is why we need the Cosmos DB Emulator and why each developer needs to connect to Cosmos DB locally.

# UI Test Harness
## UI Test Harness should simulate how production will work.  So how will this work in production?
- 2 options to connect
   - Connect UI to Cosmos DB directly
   - Connect UI to Cosmos DB through ASB using an eventing pattern

- Need to be able to
   - Retrieve the data
      - Think this would be done directly
   - Save the data
     - Think this would be done with ASB, but Nagendra has been trying to explain to Sam that we can do this directly for DREAM tool :)

David:  Angular (which is what we used to develop the UI test harness) can connect to Cosmos DB and/or ASB without any middle layer (API) for BOTH retrieving and saving the data.

James V.:  We would need the middle layer (API).  Because the UI is untrustworthy.

Need an account key in order to access
Do we have any security on top of that?
The APIs don't have any authentication

Question I am asking David:
1.  Is the expectation that we connect the UI to Cosmos DB directly in order to save the data?
2.  Is the expectation that we connect the UI to Cosmos DB directly in order to retrieve the data? 
3.  For both scenarios, what security is set up?


We need a decision and for all teams to do it the same way.

Yash:  We will not use Postman anymore for testing.  We will always use UI.

James G.:  End goal was to use the UI for testing.  Angular calls UI own .NET section to connect so if there's a way to connect directly, then great.

**If you have something to test and haven't added the message to the UI, then they can test with Postman.  But then they would add the message to the UI and test it using the UI.**


James has a proposal for the work geolocation is going to be doing for this PI.  Will share it at PO sync - a dev came up with a mockup on the retrieve page.  Other demo UI work that's under the domain tab.





Connect UI to database in a more secure way
Don't like connecting from a UI layer to a DB layer because there's usually 
Can't make it to production because not secure

thinking API layer would be the way to do that
but its not an option

Connect UI to cosmos db for retrieve
for storage, follow the eventing pattern

Connect directly for now - any enhancements to that architecture/how UI should be built out should come from higher up

IF this is a longer term item,
We need more consideration from Watchtower - free form 

Writing out the user stories for the test harness UI 
with re-structure no API anymore - no way to test
Old structure = POC = had an API 
It would've worked this way:  Connect a UI to the POC Shire Database through an API layer
System touching the data is a trusted source (API has validation and security in place to make sure it's not a bad request and it's a separate source)
In production, would we have had an API layer?  Maybe - another way would be an eventing pattern.  Had retrieval through eventing - post retrieve event, pick it up, and then retrieve the data and publish it a container message for the raw data or char and then another way would be API
API is not part of the new code structure
has to be synchronous so we don't know how else to do it



Not comfortable with anything we can't integration test, can do unit testing but can't do it until the UI is ready - having to prioritize the UI - building it out for 2 domains

PO Sync - raise that as a concern - tradeoffs discussion for sPACE Force

I don't want to confuse this UI conversation so I'll post my question here - what is the use case for the UI needing to save data? I thought it was up to the domains to decide what to save and the UI would only be used to send raw data and then retrieve saved data (data that the domains saved to DB)


