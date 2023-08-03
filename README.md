# ODatatutorial

## Recommendation

In order to test this project out, please use Docker for postgres
<br >
<br >

## Steps

- First create a database in **PostgresSQL**
- Run "`cd ODataTutorial`" note this is where solution file is existed
- Then run "`code .`" for editing in VS Code
- Edit the database connection in **Settings.json**
- Run "`dotnet restore`" to restore the packages
- Update the databse with migration file, run "`dotnet ef database update --project ODataTutorial`" in terminal
- Start debugging the project
- For the testing import the postman collection named "**ODatatutorial.postman_collection.json**" into your postman
- Change the host and port of the OData API Endpoint if necessary
<br >
<br >

## References

https://dev.to/berviantoleo/odata-with-net-6-5e1p   
\
https://www.entityframeworktutorial.net/efcore/configure-one-to-many-relationship-using-fluent-api-in-ef-core.aspx   
\
https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli  
\
https://learn.microsoft.com/en-us/odata/concepts/queryoptions-overview