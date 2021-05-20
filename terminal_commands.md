# Terminal Commands

# Create Project in VSCode

```
mkdir ShopApp
```

```
cd ShopApp
```

```
dotnet new classlib -o ShopApp.Entities
```

```
dotnet new classlib -o ShopApp.DataAccess
```

```
dotnet new classlib -o ShopApp.Business
```

```
dotnet new web -o ShopApp.WebUI
```

```
code .
```


## Migrations Commands

__Apply the codes below in Data Access Layer.__

### Install Dotnet EF Core Tools to Use Migrations

```
dotnet tool install --global dotnet-ef
```

### Create a New Migration

```
dotnet ef migrations add InitialCreate
```

### Apply Migrations to the Database

```
dotnet ef database update
```

