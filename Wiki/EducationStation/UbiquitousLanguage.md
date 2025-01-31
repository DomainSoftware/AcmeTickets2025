# Ubiquitous Language

[[_TOC_]]

# Introduction 

## Business Term

### Raw Data Element 
A ***Raw Data Element*** is a piece of data that is collected from a customer or another data source that has not be manipulated or changed by InsuranceCo.
#### Example Raw Data Element
> Marital Status and Year, Make, Model, and VIN are examples of ***raw data element***

> A Date of Birth is a ***raw data element***, but Age may or may not be - depending on how it is acquired.

### Characteristic
- A ***Characteristic*** is the core building block of a product definition
- A ***Characteristic*** is constructed from one or more ***raw data elements*** based on mapping and transformation
- ***Characteristics*** are immutable (a characteristic does not change once it is derived, a set of characteristics will always produce the same results in rating)
- ***Characteristics*** are the only inputs to the "calculator" (not raw data, although raw data could be a characteristic if no transformations apply)
- ***Characteristics*** are referenced directly in formulas or factor tables (and don't need to be transformed again before this process)
- RAD models raw data to determine the rules that define a ***characteristic***
- RAD defines a product model based on ***characteristics*** as the input
- ***Characteristics*** will have versions that are specific to a ***Product Version***.  If a ***Characteristic*** changes and is a new version, a new ***Product Version*** must be established to implement it.

#### Example Characteristics
> *RatedMaritalStatus* and *RatedVehicleType* are examples of ***characteristics***

> *HouseholdCompositeIndex* is not a *Characteristic*

#### Diagram of developing a Characteristic
> ![data to characteristic.JPG](/.attachments/data%20to%20characteristic-68a9814b-dc95-486b-a796-d694d4813c91.JPG)

### Feature
- A ***Feature*** is a made up of one or more ***Characteristics*** that define a specific insurance product concept.
- A ***Feature*** is defined within the rating and placement engine itself based on one or more ***Characteristics***
- A ***Feature*** uses characteristic values to determine a specific ***Rate Factor*** to be used within the overall ***Rate Order Calculation***.  ***Tier Placement*** will follow the same process but may use different words instead of Rate Factor and Rate Order Calculation to describe the values and calculation steps to determine a tier. 
- Multiple ***Features*** may use the same ***Characteristic*** available within the rating engine to reach a ***Rate Factor*** (ex. Driver Age may be used in multiple Features)
- A ***Feature*** will have versions that are tied to a specific ***Product Version***

#### Example Features
> *HouseholdCompositeIndex* is a ***feature*** that is modeled in the engine based on the ***characteristics***, Named Insured Marital Status, Named Insured Gender, Number of Driver, Number of Drivers other than the Named Insured (PURE/REVO)

### Rate Factors
TBD

### Rate Order Calculations
TBD

### Product Version
***Product Version*** is a collection of specific ***Characteristic*** definitions, ***Feature*** definitions, ***Rate Factors***, and ***Rate Order Calculations*** that relate to a specific filed version of a product with effective dates.  

### Placement
***Placement*** is the process of using ***characteristics*** to determine a specific classification of insurance risk.  ***Placement*** can be used in a general context (determine risk) and also refer to more specific definitions such as ***Company Placement*** and ***Tier Placement***.  ***Placement*** for both Company and Tier may impact business rules and decisions outside of the placement process (such as rating or eligibility/business rules within other business processes).

### Company Placement

### Tier Placement



## Technical Terms
### Bounded Context
The logical grouping of business functions. A *bounded context* has the data and business rules for a business capability.  

## Acronyms
