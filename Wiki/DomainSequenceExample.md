# Domain Sequence Example

## Sequence Diagram


### PlantUML

```plantuml
@startuml
Title Allocate and Purchase no TicketGroupId on request



Header this is the header
Footer This is the footer
skinparam backgroundColor #EEEBDC
skinparam ParticipantBackgroundColor DarkOrange
skinparam FontName Arial
skinparam FontSize 12
skinparam FontColor Black
skinparam ArrowThickness 4

autonumber
actor User 
'Participants in this diagram represent domains

participant ITOps.API
participant OrderManagement 
participant Inventory
participant FraudProtection
participant Fullfillment
participant ITOps.Integration
participant MarketplaceCommunication
 
'Events are those words that start with the letter I. For example ITicketGroupQuantityChanged

User -[#DarkBlue]> ITOps.API: PurchaseTickets
activate Inventory #grey
ITOps.API -[#DarkBlue]> Inventory: TicketAllocationRequest
note left: this is a first note
Inventory -[#DarkGreen]>  ITOps.API: Return
activate OrderManagement #grey
Inventory -[#Orange]>  OrderManagement: ITicketGroupQuantityChanged
Inventory -[#Orange]>  OrderManagement: ITicketsAllocatedToOrder
deactivate Inventory
'the following represents an event. It has dashed orange lines
OrderManagement --[#Orange]> ITOps.Integration: ITicketGroupPriceAndQuantityChanged
deactivate OrderManagement 
ITOps.API -[#DarkBlue]> Inventory: OrderManagement
activate OrderManagement #grey
OrderManagement --[#Orange]> MarketplaceCommunication: INeedAdditionalDataToCompletePurchase
OrderManagement -[#Orange]> OrderManagement: Validate
OrderManagement --[#Orange]> FraudProtection: IPurchaseOrderPlaced
OrderManagement --[#Orange]> Fullfillment: IPurchaseOrderPlaced
OrderManagement --[#Orange]> ITOps.Integration: IPurchaseOrderPlaced
deactivate OrderManagement 

legend right
|Color| Type |
|<#FF0000>| Type A class|
|<#00FF00>| Type B class|
|<#0000FF>| Type C class|
endlegend

' activate Frontend #red
'     Frontend -> Backend: API Call
'     Frontend -> Database: API Call2
' Backend -> Database: Query
' deactivate Frontend
' Database --> Backend: Result
' Backend --> Frontend: Response
' Frontend --> User: Display Result

' 'note over User,Frontend,Backend,Database: All participants and messages are yellow'
' User -[#orange]>> Frontend: Example Event
' Frontend -[#blue]> Backend: Example Event
' Backend ->> Database: Example Event
' Database --> Backend: Example Event
' Backend --> Frontend: Example Event
' Frontend --> User: Example Event

' 'note over User,Frontend: Example command in blue
' User -> Frontend: Example Command #blue

caption: \nEven though you made the arrow line\n from A to B the longest,\n their lengths are calculated and this\n calculated length is what's drawn.

@enduml