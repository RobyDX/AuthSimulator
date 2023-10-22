# AuthSimulator
Auth Simulator is a small provider whose purpose is to simulate an OAuth2 provider.

By configuring your web application you can simulate the connection to a real provider, helping you in the development and testing phase.

Auth simulator can be run in memory (you will lose all configuration by restarting the container) or using SQLite or SQLServer to mantain your data


### Environment Variable

- ConnectionStrings__SQL: Contain the SQL Server Connection String. Required only if ConnectionMode is set to SQL
- ConnectionStrings__Lite: Contains path and filename of your SQLite DB. Required only if ConnectionMode is set to Lite
- ConnectionStrings__Memory: Contain name of your in memory DB. Required only if ConnectionMode is set to Memory
- ConnectionMode": Contains Database type you prefer to use (Lite, SQL, Memory). 

Visit our [Project Page](https://github.com/RobyDX/AuthSimulator)


Here some docker compose example to configure Auth Simulator on Port 6080 and 6443 of docker
Configure container to match your needs. 



### In Memory Configuration

	version: '3.4'
	services:
		authsimulator:
			image: robydx/authsimulator
			restart: on-failure
			environment:
				- ConnectionStrings:Memory=authsimulator
				- ConnectionMode=Memory
			ports:
				- "6080:80" 

### SQLLite Configuration

	version: '3.4'
	services:
		authsimulator:
			image: robydx/authsimulator
			restart: on-failure
			environment:
				- ConnectionStrings:Lite=litedata/authsimulator.db
				- ConnectionMode=Lite
			ports:
				- "6080:80" 
			volumes:
				- authdata:/app/litedata
	volumes:
		authdata:
	
### SQL Server Configuration
	
	
	version: '3.4'
	services:
		sqldata:
			image: mcr.microsoft.com/mssql/server:2019-latest
			restart: always
			volumes:
				- mssql-server-data:/var/opt/mssql
			environment:
				- SA_PASSWORD=Auth1234@@
				- ACCEPT_EULA=Y
			ports:
				- "1433:1433"
		authsimulator:
			image: robydx/authsimulator
			restart: on-failure
			environment:
				- ConnectionStrings:SQL=Server=sqldata,1433;Database=AuthSimulator;User Id=sa;Password=Auth1234@@;MultipleActiveResultSets=True;App=EntityFramework
				- ConnectionMode=sql
			ports:
				- "6080:80" 
	volumes:
		mssql-server-data: