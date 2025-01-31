This is an overall guide on how to best implement rules in our code knowing that Apollo will likely replace the c# rule files.

This is not written in stone and can be a discussion point but wanted to at least have something down for people to read and talk about.

The thought was, rules were be created off of an abstract class then reflection would pull all the classes that inherit that abstract class and run based off of the data available.

Originally this was run after a saga to get all the data then run rules.

This type of pattern will be similar to how the domains and Apollo will work.

Domain Gathers all Data -> sends to Apollo to generate chars -> Apollo returns chars and domain sends chars where they need to go.

Apollo turns JSON into C# classes....so the pattern we are doing except we are just stating with C#.  Apollo has validation and all sorts of tools built in.    It would be really easy to inject Apollo service into the domain manager and replace the part of the code that calls all the abstract class rules.

This is an open discussion.  This was original design and why it was designed the way it was.  Domains would be data retrieval to send to Apollo then be in charge of where to send the chars.





