# School Demo Project

# To run
Create `SchoolProject/SchoolProject.MVC/appsettings.local.json`
```json
{
    "ConnectionStrings": {
      "SchoolProjectConnection": "Insert Your SQL Server Connection String Here"
    }
}
```

Make sure you're in `SchoolProject/SchoolProject.MVC/`
```
dotnet restore
dotnet run
```