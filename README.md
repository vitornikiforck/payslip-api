# API Contracheque

Aplicação responsável por criar o extrato da folha salarial dos funcionários. Esse
extrato deve expôr o salário líquido do funcionário e todos os seus descontos
discriminados.

**Executando o projeto**

Necessário ter instalado:

- Visual Studio 2019/2022
- Docker
- SQL Server

**Local**

Opção 1:
- Navegar até o local onde foi clonado o projeto
- Abrir a solução Payslip.sln
- Alterar a ConnectionString `Data Source=host.docker.internal;Initial Catalog=LocadoraDbContext;User ID=sa;Password=L@c@d@r@123;MultipleActiveResultSets=true` localizada no arquivo appsettings.json
- Executar o projeto Payslip.Api

Opção 2:
- Navegar até o local onde foi clonado o projeto
- Executar docker-compose-dev.yml:

Utilizar o seguinte comando ``` docker compose -f .\docker-compose-dev.yml up```

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
      
  payslip-api:
    image: vitornikiforck/payslip:latest
    container_name: payslip-api
    restart: always
    environment:
      - ASPNETCORE_URLS=http://+
      - ASPNETCORE_ENVIRONMENT=Development
      - AppSettings__ConnectionString=Data Source=host.docker.internal; Initial Catalog=PayslipDbContext; User=sa; Password=P@ssw0rd; MultipleActiveResultSets=true
    ports:
      - 9000:80
```
- Acessar em ```http://localhost:9000/swagger```

#

**Azure Pipeline Builds**
- [Payslip API Builds](https://dev.azure.com/vitornikiforck/Payslip/_build)

#

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


# Referências 
- [Asp Net Core 6.0](https://docs.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-6.0?view=aspnetcore-6.0)
- [Domain Driven Design](https://martinfowler.com/tags/domain%20driven%20design.html)
- [MediatR](https://github.com/jbogard/MediatR/wiki)
- [FluentValidation](https://fluentvalidation.net/)
- [Autofac](https://autofac.readthedocs.io/en/latest/integration/aspnetcore.html)
- [AutoMapper](https://docs.automapper.org/en/latest/)
- [Moq](https://documentation.help/Moq/)




 
