## Desafio Edusync/BRQ -  Módulo de construção de API com Entity Framework

### Objetivo
#### Construção de uma API REST utilizando Asp.Net Core e ADO.Net sem utilizar template

### O que foi utilizado?
 - Linguagem C#
 - Asp.Net Core Web API versão 5.0
 - Conceito de inversão de controle com injeção de dependência do repositório das models e do contexto
 - Repository Pattern com conceito de Generics para utilizar um Base Repository
 - ORM Entity Framework para acesso aos dados e persistência dos dados em um banco de dados
 - Conceito de criação do banco de dados: Code First
 - Criação de migration para atualização do banco de dados
 - SQL Server 
    - Inserção de dados com Script DML incluído no projeto na pasta Scripts
 - Entity Framework versão 5.0.17
    - CRUD básico utilizando o Base Repository com Insert, GetAll, GetById, Update, Patch e Delete utilizando o conceito de Generics
    - Consultas personalizadas utilizando relacionamentos entre as tabelas
 - Documentação via Swagger
 
 ### Configurações necessárias
 - No arquivo  appsettings.json substituir a string de conexão pela string de seu 
```
"ConnectionStrings": {
    "DesafioEntityFramework": "server=.\\SQLEXPRESS; Database = DesafioEntityFramework; User Id=seuUsuarioAqui; Password=suaSenhaAqui;"
  }
```
 - Executar o Update da Migration no banco de dados
    
    - Executar o comando: 
    ```
      dotnet ef database update
    ```
 - Executar o DML que está na pasta Scripts no projeto.
    - Esse script serve para facilitar os testes dos "Gets" sem a necessidade de persistir dados no banco através da API


