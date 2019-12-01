# ex-api-inicial-aspnetcore
Api de exemplo inicial asp net core sql server linux em docker

API Asp Net Core

Data Base SQL Server Docker Linux
create table Product 
( ProductId uniqueidentifier not null,
Name varchar(30) not null, 
Description varchar(60) not null, 
Active bit not null, 
Price numeric(10,2),

constraint pkProduct primary key(ProductId)
)

Dependencias de pacotes

1 - Entity Framework dotnet remove package Microsoft.EntityFrameworkCore --version 3.1.0-preview1.19506.2

2 - SQL Server dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.0.1

3 - Configuration dotnet add package Microsoft.Extensions.Configuration --version 3.0.1

obs - Pasta imagens - Testes executados na api
