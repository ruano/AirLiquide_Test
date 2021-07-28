# AirLiquide_Test

Esse projeto consiste em uma API para gerenciamento de clientes (CRUD).

### Requisitos
- Visual Studio 2019;
- SQLServer 2019;
- .NET 5.0;
- Ferramenta do Entity Framework para gerenciamento de migrações da base de dados, executar o comando abaixo para instalação:
```
dotnet tool install --global dotnet-ef
```

### Deploy

Através do prompt de comando do VS, executar os seguintes passos para deploy da API:
- Na raíz do projeto:
```
dotnet build
```
```
dotnet publish -c Release -o C:\temp\api
```

### Configuração

- Após, é necessário somente configurar a connection string para acesso à base de dados SQLServer. Esta seção está disponível no arquivo appsettings.json. Ao subir a API, a criação/atualização da base será realizada automaticamente pela ferramenta de migração do Entity Framework.

Obs.: Caso opte por realizar a criação/atualização da base de forma manual, executar o seguinte comando dentro do projeto AirLiquide_Test.Domain:

```
dotnet ef database update
```

### Execução

Para subir a API, executar no diretório em que foi gerado o deploy, no caso dessa documentação em C:\temp\api:
```
dotnet AirLiquide_Test.API.dll --urls http://*:5009/
```

A documentação da API, poderá ser consultada pelo Swagger em:
```
http://127.0.0.1:5009/swagger
```

Os requests poderão ser feitos por algum aplicativo cliente como o Postman, Fiddler ou até mesmo pela interface do Swagger.