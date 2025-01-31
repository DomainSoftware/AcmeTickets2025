# Introduction

This is the External Integration guide on what you might need to define an integration with an external team or vendor

# What is an External Integration?

External Integration, or 3rd Party Integrations, are any systems you need to talk to retrieve specific data.
They can be as broad as an actual 3rd party to InsuranceCo, like our MVR and CLUE vendor systems, but also our other internal data sources like Duck Creek or Client which may be external to the systems we are working on. Even a system that is within the same department is external.

# Goals

For developer guidance I want to provide information we can reference when working on external service calls that communicate over HTTPS so that we can have a structured way to obtain information and handle it through the GTR systems.

# Code

The initial example here is an MVR integration that was created. This will likely change as the latest source code develops to become a better example. These can be easily referenced in the individual projects within a system, but should be outsourced to their own solution to facilitate reuse.

## Folder Structure

Depending on the type of integration & scenario you are using, you may need some or all these folders. These are for namespace and organizing the code in a structured way.

- Client -- Used when you need to connect to a new integration or URL to send or receive data.
- Client.Contracts -- Used for all client related contracts, generally internal to the project _(.gen.cs files)_
- Exceptions -- Used when you have a client or need to throw specific exceptions. Exceptions from the client themselves MUST be wrapped to avoid conflicts with other timeouts. _(TimeoutException vs FooClientTimeoutException)_
- Services -- **Always** needed to specify the layer that understands and consumes a client, makes a call to a client and initial processing logic or transforming data.
- Models -- Optional, and not included in the initial MVR implementation. Implementing a model should be a separate project/feature, providing outward facing models that both accept a type of data and respond similarly. Created so that consumers of the integration don't send internal contracts _(FooRequest (creates)-> FooInternalRequest (calls client)-> FooInternalResponse (processes)-> FooResponse)_

## Naming Conventions

The MVR project/feature initially contains a client that is not directly related to MVR; the GenAPIClient. To clarify, the GenAPIClient understands how to connect to the GenAPI's API, how to receive a request, and how to process a response. So broadly calling this client an "MVRClient" doesn't make sense since the API is not "MVR" or named as such. Instead, the project/feature contains an MVR named service that handles creating a GenAPI request that is MVR related, subsequently calling the GenAPIClient with this request and processing the response. The general guidelines should follow this pattern. Of course, this is subject to change with the additional planned GenAPI integrations and I suspect a GenAPIClient related package will be developed which understands how to call various external systems under GenAPI vs. this MVR specific package.

- The project/feature should be named after the integration your trying to implement.
- If the client name is different than the integration, the services should be named specifically and clients should be named broadly.

## Coding Guideline

Without a doubt, external integrations always need some sort of resiliency or exception handling to define what you want to do with a message that can't be processed for various reasons. If the HTTP calls have multiple integration exceptions that may be thrown, then those exceptions MUST be wrapped in some exception for that integration. _(FooClient throws TimeoutException -> Catch TimeoutException, log, throw FooTimeoutException)_.  On this note, exception handling at the Client level should always throw exceptions and not eat/hide the exceptions. Outside of the Client, the service can handle some scenario but there should be very few scenarios.

# Notes

Reach out to the Engineering Leaders team if you think something needs to be updated, changed, or suggested on this guidance. Also reaching out the submitter or submitting a PR on this Wiki is also advised.
