# [Feature 5866950 - Expand Data Persistence into Operator Domain](https://InsuranceCo.visualstudio.com/PACE%20and%20PURE/_workitems/edit/5866950)

## Background
- Operator Domain will serve as the single source of truth for all operator data.
- Each domain has its own Cosmos DB that has been provisioned by the Systems Team and has its own connection string.
- We need to implement the PACE [Data Persistence Strategy](https://InsuranceCo365.sharepoint.com/:w:/r/sites/GTR/Shared%20Documents/Data%20Management%20Strategy%20for%20GTR%20Domains.docx?d=w7f003ad980b14be1962c80e80b47aed6&csf=1&web=1&e=phqieu) developed by sPACE Force team
- sPACE Force created a working prototype in the GeoLocation domain & in PI 22-2 will be expanding this strategy into the Vehicle Domain

## Why do we need to persist data?
- We need to make operator data available for future use by the InsuranceCo Tiering & Rating system and other systems/applications.
- We need to comply with regulatory requirements around retaining data.
- We need to be able to easily and clearly demonstrate to regulator and others how we calculated each piece of a rate at a specific point in time for a specific transaction, vehicle, operator ID, application ID, policy ID, etc., including
   - the raw data elements obtained,
   - the business rules used to transform that data into characteristics, and
   - the characteristic values calculated.
- We need to be able to easily re-calculate rates (including each component of the rate) for analytical purposes both for individual IDs and for groups of IDs over time.

## Why implement the PACE Data Persistence Strategy in the Operator domain?
- This will allow us to be consistent with all other domains within PACE even though the operator domain does not need to be completely identical to other domains.
- Each PACE team does not need to design a data persistence strategy from scratch for the domain they own.  Instead, this strategy sets expectations for everyone.
 
## Strategy Summary


>><small>**Disclaimer**:  This summary is **not** intended to replace reading the Data Persistence Strategy document.  **You must refer to the Data Persistence Strategy document directly throughout the duration of the PACE initiative.**  Please report any discrepancies between that document and this Wiki to Sam.

We need to be able to **persist** data to the operator domain's Cosmos DB that has been provisioned by the Systems Team.  Each domain has its own Cosmos DB and has its own connection string.

We need to be able to retrieve the persisted data.

We need to be able to persist and retrieve the following types of information:
- Raw data elements
   - Used to generate each characteristic
   - Associated with a given Application ID
   - Associated with a given "entity" (operator, vehicle, etc.)
   - Associated with a given transaction
- Rules used in creating a characteristic
   - Characteristic definition rules
   - Business rules^
- Characteristic Values
   - Used in a given price calculation request (aka a call to Rating API)
   - Associated with a given Application ID
   - Associated with a given "entity" (operator, vehicle, etc.)


### What are characteristic definition rules?
Characteristic definition rules are the rules that are used by characteristic assemblies to turn a raw data element into a characteristic value.

For example, if we receive the raw data element of 'date of birth' then we need to apply certain rules in order to calculate the operator age characteristic.  These rules would indicate whether we need to calculate the age based on the date of the quote, the effective date of the policy, or some other date.

### Where are the characteristic definition rules used to turn raw elements into characteristics?
The characteristic engine within each domain will take raw data elements, apply the characteristic definition rules, and develop the characteristic values.

### What are business rules?
Business rules are pre-processing rules that are **not** in the characteristic engine.

The Geolocation domain had some of these rules that needed to be applied up front and not in the characteristic engine.  The long-term goal is to incorporate these into the characteristic engine within the domain, but for now, they'll remain as pre-processing rules.

The Operator domain may or may not have rules that fall into this category.  We need to figure out if we have any rules that fall into this category, and if so, we need to mock up a process to enumerate and keep track of them.

## Who is responsible for storing characteristic definition rules and business rules?
Each domain is responsible for capturing the rules used to develop that domain's characteristics.  Each domain should follow the general approach used by the working prototype of the data persistence strategy (the Geolocation domain).

## Okay, but what data do we specifically need to persist and be able to retrieve within the Operator domain?
Check out the Operator Tech Spec.

## Is there overlap in terms of what will be saved in the Premium Calculation Domain and in the Operator Domain?
_To be confirmed by PACE Columbia Product Owner_



# Considerations
## Data Storage

1. How will we know that we know we need to do something?
1. How will we know what characteristics need to be developed?
1. How will we know what data elements we need in order to develop those characteristics?
1. How do we get the data and from where?
1. How will we know what we need to store?
1. Where in the process does the storage of various data elements happen (as we get the info or all at once at the end)?
1. Who needs to know that the data has been saved and how will we let them know?
1. Does who needs to know ever change and if so, how do we know who needs to know?

## Data Retrieval

1.  How will we know we need to retrieve previously stored data?
1.  How will we know what we need to retrieve?
1.  What inputs do we need in order to retrieve the right data?  Where will we get those inputs from?
1.  How do we retrieve the data?
1.  How do we signal that it's been retrieved and by whom?
1.  What do we do if there's an error?  What kinds of errors could happen?

## General
1.  How will this work with the UI vs. how will this work with the front-end applications?  What changes need to be made to the UI in order to make this happen?
1.  What teams do we need to coordinate with?  What other domains are involved and how will we make sure we know they need something from us and how will we signal to them that it's been completed or not?
1.  What dependencies do we have?  When will the items we depend on be completed?  What's our interim solution?  Do we have a user story to reflect the work to go back and change from the workaround to the long-term solution once the item we're dependent on is complete.
1.  What errors could happen?  How will we handle each?  What downstream impact is there?


