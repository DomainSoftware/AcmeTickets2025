# What are all these acronyms?
-  PACE is the name of the initiative.
-  InsuranceCo Tiering & Rating (GTR) System is the name of the system we're building as part of the PACE initiative.

# Overall InsuranceCo Tiering & Rating System Flow
<small>**Disclaimer**:  The Sequence Diagrams are the ultimate source of info on the flow.  **You must refer to the Sequence Diagrams directly.** The following is just meant to supplement the information there as a high-level summary.  If anything below does not match the Sequence Diagrams, please let Sam know.

- Premium calculation will provide a product ID to each domain (operator, vehicle, geolocation)
-  Each domain (operator, vehicle, and geolocation) will identify the characteristics that it needs to refine based on the product ID.
-  Within each domain, there will be a Characteristic Engine that takes the raw data elements, applies the rules, and creates the refined characteristics.
-  Once a domain has completed all of its work related to the product ID, it will need to alert that the event has been completed.
- The Premium Saga will keep track of whether it receives a completed event from each domain before calling rating.
