# UI Test Harness (PI 22-1 Feature)

[UI Test Harness](https://pcluix.dv1.pcluix.aks.aze1.cloud.InsuranceCo.net/operator)
#Background
- Sales and Service Front End applications will pass information to the InsuranceCo Tiering & Rating System we're building.
   - Example:  If a potential customers goes to InsuranceCo.com and fills out an application for an insurance quote, then they'll provide us with their name, address, and other information.  That data will then need to be passed to the InsuranceCo Tiering & Rating System so that we can refine the raw data elements into characteristics and use those to determine the appropriate rate to charge.
- We are viewing our Sales and Service Front End as our clients.
- We need to be able to test the InsuranceCo Tiering & Rating System on the back end independently of changes to the Sales and Service Front End applications because:
   1. **We want to test our own product before delivering to a client.**
   2. **It will  allow us to more effectively troubleshoot errors.**  While we build the back end InsuranceCo Tiering & Rating System, the Sales & Service Front End teams are modifying those applications to be able to pass information to the InsuranceCo Tiering & Rating System.  If we're changing the front end and back end at the same time and testing them together, then we'll have to dig into whether any errors are happening because of changes to the front end or if they're happening because of changes to the back end.
   3. **Any new info we want to capture isn't going to be available from the front end as part of the PACE Challenge, but we still need to test it.**  The Sales and Service Front End applications (for now) are only going to pass information that they currently pass today.  However, the InsuranceCo Tiering & Rating System may need to use a new piece of data that would require us to ask a new question in the insurance application.  Even though the front end applications won't be able to pass us that information, we still want to be able to test it on the backend.
- In order to test the InsuranceCo Tiering & Rating System on the back end without having a dependency on the Sales and Service Front End applications for all of the reasons above, the PACE Discovery Team developed a User Interface that simulates the Front End Sales & Service Applications.

## Current Functionality
   - Currently, we fill in information on the Operator Page, add an operator, and then it auto-generates an Operator ID and Application ID.
      - Retention ID and Policy ID are not currently in the UI at all.
 
