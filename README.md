# StockExchangeSolution

This solution contains an API that allows you to know the prices of the shares.

To launch the project, you must have visual studio 2022 and Sql Server. 
You will need to modify the connectionString in the 'Appsettings' file. Execute the 'update-database' command in the 'Package Manager Console' then launch the project.
At runtime, actual action data will be stored in the 'Tickers' table.
To test, the Swagger window contains the Get ​/Ticker​/{symbol} endpoint
This solution contains .Net6 projects.
