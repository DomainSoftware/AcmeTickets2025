# Postman

[Postman - Install and Setup Instructions](https://InsuranceCo365.sharepoint.com/:w:/r/sites/BillingHTZ/_layouts/15/Doc.aspx?sourcedoc=%7BBE2FFF29-106D-4988-ADED-21CBB97DB30F%7D&file=Postman%20-%20Install%20and%20Setup%20Instructions.docx&action=default&mobileredirect=true&DefaultItemOpen=1&cid=ea145ee0-98e6-4ae7-aa12-32b952f1d6d8)

[PACE Demo UI](https://pcluix.dv1.pcluix.aks.aze1.cloud.InsuranceCo.net/geolocation)


# Splunk queries

- index="uwsystems_np" applicationAcronym="*approc*" env=dv1 7407438683

- Basic Triaging Query for Splunk
- env=ED1 index=*_np error 7407308670

# ASB explorer Link

# CosmosDB link

# Testing

# ADC Trace Tool

ADC Trace Tool
This is used to trace ADC code for a given transaction you may be testing in EDGE.
The link below contains links to trace in the different environments and instructions on how to use this tool.  
https://InsuranceCo365.sharepoint.com/:w:/r/sites/DuckCreek/Shared%20Documents/TraceMonitor/WebTraceManual.docx?d=wf23026c9c2d7430cb7c9c862d6bda2d6&csf=1&web=1&e=UEfr3O

UN: WebTraceUser

PW:  WebTraceUser


# Reference Data Services 

https://InsuranceCo365.sharepoint.com/sites/ReferenceDataServices
 
For looking at an existing look up..
 
1.	Start with the RDS_Lookups_usage spreadsheet to identify the look up you are referencing and the parameters
 
2.	Then pull up the URL for the specific environment you are looking for 
 
3.	Then copy the href link into the RDS Dashboard
 
4.	Be sure to replace the bracketed date with what you are looking for
 
5.	Select table
 
6.	Select invoke
 
 
Tips:  you cannot hard code using an existing lookups…If you have additional or missing parameters that need to be added you must request a new look up.  
 
To do this you must: 
a.	Request permission from the table owner
b.	Once approved you must submit a request to the RDS team.  This will always go into their next sprint so there is a 3 week lead time that is needed.
 
[RDS Environments Overview](https://InsuranceCo365.sharepoint.com/:w:/r/sites/ReferenceDataServices/_layouts/15/Doc.aspx?sourcedoc=%7BA618B025-E88C-40E5-BE1F-775A68549AA5%7D&file=RDS%20Environments%20Overview.docx&action=default&mobileredirect=true&DefaultItemOpen=1&cid=70ed3afa-7db0-4ae4-a8da-2d361b22c002)

# Sentry Authorization
Review the authorization form: 
 
https://gnie.InsuranceCo.net/sites/msi/service/SitePages/TeamPrometheus.aspx
 
  
Steps:
1.	Look to see if there is an existing authorization that is established for the same transaction you are working on.  It has to be for the same transaction/ page you are working on otherwise a new one is required.
Link:
 
2.	Submit a request to Hound
Link: https://InsuranceCo365.sharepoint.com/sites/HOUNDEdge/Lists/EDGE%20Issues%20and%20Questions/AllItems.aspx
 
3.	Submit  a request to the Sentry Team (This can be submitted at the same time, but will not be completed until hound approval is received)
Link:  Edge Requirements: Sentry Authorization Master and Request Form

# Midstream

[Mid Stream and Rating Triaging Link](https://svcdv3adm01.dev3.ibu.InsuranceCo.net:8443/display/ISR/Midstream+and+Rating+Splunk+Triaging)
 
Mid Stream - Translates EDGE requests to rating and vice versa

this query give you the full flow of data:
UpstreamRequest -> Data from EDGE & PEAK to Midstream

DownstreamRequest -> Data from Midstream to Rating

DownstreamReply -> Data from Rating to Midstream

UpstreamReply -> Data from Midstream to EDGE/PEAK

env=ed1 index=policycore_np applicationShortName=ratpms LogLevel!=INFO
just add the PolicyNumber



Open Forum Q/A Topics


| Question/Statement |Answer  |Notes  |
|--|--|--|
|  |  |  |
|  |  |  |
|  |  |  |

