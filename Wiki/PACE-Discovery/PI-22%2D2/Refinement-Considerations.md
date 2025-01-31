# Consider the following for each and every single item we work on or review:
1. How will this work with the front-end applications?
1. How will this work with the UI?
1. What kinds of testing will we need to do?
1. What changes will need to be made to the UI's operator page data entry inputs?
1. What changes will need to be made to what we receive in the UI from Premium Calculation?
1. What other changes will need to be made to the UI to allow us to test this?
1. What kinds of errors could there be?
1. How will we handle errors?
1. What other teams/domains would this functionality interact with?
1. What other teams/domains have already done this?
1. What other teams/domains do we need to sync up with?
1.  What other teams/domains will be working on a similar item this PI and how have they broken out the work?  Should we sync up with them?
1. What do we need to do in order to make sure we're calculating an accurate rate for our customers?
1. What do we need to do to produce the highest quality output?
1. How will I know when this is complete?
1. How will I have this reviewed?
1. How will I demo this?
1. How does the data persistence strategy come into play here?
1. How does the data validation & testing strategy come into play here?
1. Do I understand who is going to benefit from this/use it and how?  Do I understand what the user needs to be able to do with the output of this work item?
1. What is the best way to make sure that the users fully understand this and provide feedback?  (This may or not be at a typical iteration, system, or PI system demo.)
1. Where do I have flexibility within this work item to create my own solution?
1. What other teams are currently doing similar work?
1. What tools, resources, and permissions do I need in order to do this and do I have those?
1. If I decided to go on vacation right now for the next month, would it be easy for the team to pick up this work item?  Do they have the links, background, updates on progress made, connection strings, etc. needed in the ADO work item?  Is it well-organized?  Have I been working in a silo?
1. If I were testing/reviewing this, what would I check?  What would I challenge me on?
1. Who might need to use any part of this work later?
1.  What needs to be documented and where?
1.  What overall PACE guidance applies to this story?
1.  What revisions to PACE guidance have been made?
1.  What new PACE guidance has come out recently?
1.  Hoes does this impact the Operator Tech Spec?  How is this impacted by the Operator Tech Spec?  What changes need to be made to the Operator Tech Spec?  Do we have work items to represent communicating that change to the front end teams, revising the document, and publishing it?


## In addition to the considerations for ALL items, these are additional considerations specifically for characteristic development.


In general, we need to be able to complete the high-level process below for each characteristic that we develop.

As we work to refine features, decompose them into user stories, and refine those user stories, think through each step of the process to make sure that
- We understand how each step will be accomplished and by which team/domain
- If we are responsible for a step, we have ADO work items to reflect that
- If another team/domain is responsible for a step, we understand how we will be aware of when that step is completed

#High-Level New Business Process
1. Determine product needed
2. Identify the characteristics needed (based on the product)
3. Identify the data element(s) needed (based on the characteristics)
4. Collect the raw data element(s) for identified characteristics
5. Refine the raw data element(s) into characteristics
6. Store the characteristics
7. Signal that application was refined
8. Calculate policy premium
9. Post policy premium to customer