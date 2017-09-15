# aspnetcore2
Projeto ASP.NET Core 2.0

Criar class library
```
dotnet new classlib --name Demo.Domain
```

Criar solution
```
dotnet new sln --name <nome_solution>
```

Adicionar referenciar projeto na solution
```
dotnet sln add src\Demo.Domain\Demo.Domain.csproj
```

Gerar o migrations
```
..\src\Demo.Data> dotnet ef --startup-project ..\Demo.Api\Demo.Api.csproj --project .\Demo.Data.csproj  migrations add AddCategory
..\src\Demo.Data> dotnet ef --startup-project ..\Demo.Api\Demo.Api.csproj --project .\Demo.Data.csproj database update
```