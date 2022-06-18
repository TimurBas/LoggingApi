# Technical interview assignment
## A logging library

### Tech Stack
Front-end: `React.js, TypeScript, Chakra-UI`

Back-end: `C# Web API (.NET Core project)`

### How is it used
#### Logging some messages
Created a front-end that makes a GET-request to retrieve all log events (Back-end uses a in-memory db) and then renders them in a table.
![image](https://user-images.githubusercontent.com/49007811/174460466-d7451c45-6592-438c-b40e-fca18d2c0161.png)

#### At application startup
![image](https://user-images.githubusercontent.com/49007811/174460426-e1692f80-e9c7-4c31-b289-a5fa420fc8a8.png)
Either change the existing `LogFactory`'s methods or create a new one factory implementing the `ILogFactory` interface. 

### The answer to the "Other things to consider" part
Simply create another data format strategy and implement the `IDataFormatStrategy` interface and implement the methods and you are good to go.

![image](https://user-images.githubusercontent.com/49007811/174460503-9f46e805-8b20-4c6c-8dd7-c31530ff0a72.png)
