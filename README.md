# API Contracheque

**Tecnologias utilizadas**

**Back-end**
- C#
- Asp Net Core 6.0
- MediatR
- AutoMapper
- FluentValidation 
- Autofac
- EF Core
- Moq
- NUnit
- `swagger` Para gerar a UI da documentação dos serviços Rest

**Banco de dados**
 - SQL Server

**Executando o projeto**

Local:

- Necessário ter instalado Visual Studio 2019/2022
- Navegar até o local onde foi clonado o projeto
- Abrir a solução Payslip.sln
- ConnectionString padrão do banco de dados está configurada para acessar o sql-server publicado em container

Opção 1: Criar docker-compose sql-server:

```
version: "3.7"

services:
  sql-server:
    image: mcr.microsoft.com/mssql/server:2017-latest-ubuntu
    container_name: sql-server-payslip
    restart: always 
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=P@ssw0rd
      - MSSQL_PID=Express
    ports:
      - "1433:1433"
```

Opção 2: Alterar a ConnectionString `Data Source=host.docker.internal;Initial Catalog=LocadoraDbContext;User ID=sa;Password=L@c@d@r@123;MultipleActiveResultSets=true` localizada no arquivo appsettings.json

# Referências 
- [Asp Net Core 6.0](https://docs.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-6.0?view=aspnetcore-6.0)
- [Domain Driven Design](https://martinfowler.com/tags/domain%20driven%20design.html)
- [Lidar com a complexidade dos negócios em um microsserviço com padrões DDD e CQRS](https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/)
- [MediatR](https://github.com/jbogard/MediatR/wiki)
- [FluentValidation](https://fluentvalidation.net/)
- [Autofac](https://autofac.readthedocs.io/en/latest/integration/aspnetcore.html)
- [AutoMapper](https://docs.automapper.org/en/latest/)
- [Moq](https://documentation.help/Moq/)




 
