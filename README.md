# Instação EF Core.

### Execute os seguintes comandos para instalar e atualizar a ferramenta dotnet-ef:
```sh

    dotnet tool install --global dotnet-ef
    dotnet tool update --global dotnet-ef
    dotnet tool list --global
```
### Fazendo referencias ao dotenet-ef core:
```sh

    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

dotnet new globaljson --sdks-version 5.0.102 --force
