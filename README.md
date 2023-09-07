# EventManagment
* SDK Net Core 6
* Database MSFT SQL Server
* Entityframework Core - Code First
* Angular 14.2.12
* Node 16.17.1

## When you start the backend project:
Run intialization process:
 * The database will be create
 * Migrations will be applied
 * And seed data will be inserted
	
> Note: if you don't want this approach, go to program.cs in RealEstate.Api project and comment this line:
```csharp
   await app.InitializeDatabaseAsync();
```

## Run Angular project
* First get localhost API url from running backend
* Set this value to the API_URL constant, inside the following path
```
...\src\app\shared\constants\api-url.constant.ts
```
* Now run with ng serve