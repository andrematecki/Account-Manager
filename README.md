# Account Manager (API)

Este projeto foi desenvolvido no framework .NET Core 2.1.

* Banco de dados utilizado: SQlite localizado em "4. Infra/Sqlite/AccountManagerDB.db". Pode ser lido com qualquer programa que suporte Sqlite, exemplo: "DB Browser for SQLite";
* Script de criação do banco estão na pasta "4. Infra/Sqlite"

## Design da Aplicação

A aplicação foi modelada com base em DDD (Domain-Driven Design). As principais estruturas são comentadas a seguir:

`Presentation` Interface com o usuário. Foram utilizados controladores do framework AspNetCore.

 **ResquestModel e ResponseModel** contém classes de IO de  informações da aplicação para não expor o modelo de dados do dominio.

`Service` Serviços que atendem ao negócio. Nessa aplicação foi abstraida a estrutura de *Serviços de Aplicação (ApplicationServices).*  

`Infra` Processos que suportam a aplicação. Foi criado a implementação das classes de acesso a dados aqui.
 
 `Domain` Contém toda lógica de negócios da aplicação. Foram usadas interfaces para definição de ações do negócio e a responsabilidade de implementação ficaram nas outras camadas.

 ## Documentação da API

Ao iniciar o projeto em ambiente de desenvolvimento (Visual Studio 2017 ou 2019) será aberto a documentação da API em Swagger. O arquivo Swagger também pode ser encontrado na raíz do repositório.


 ## Execução da API (Docker)
 
 Swagger ficará disponível em *localhost:local-port/swagger*
 
 **Método 1 (local):** criar imagem Docker e container. 
 
  `docker build -t image-name:tag Dockerfile-location`
  
 `docker container run -d -p local-port:5050 image-name:tag`
 
 **Método 2 (Docker hub):** realizar pull da imagem pronta e criar container Docker.
 
` docker pull andrematecki/acc-man:2.0`
 
 `docker container run -d -p local-port:5050 andrematecki/acc-man:2.0`
