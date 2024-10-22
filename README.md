# Projeto Cred Emprestimos
Projeto em desenvolvimento, objetivo é criar um sistema de empréstimos. Onde o cliente possa simular um empréstimo e caso ele deseje fazer a contratação do mesmo.

## Tecnologias Utilizada
## Backend
- C#
- .Net 8
- ASP.NET WebApi   
- Arquitetura três camadas.
## Frontend
- Html-Css
- Angular V17
- Ngx-Mask
- Ngx-Bootstrap
- Ngx-Toastr

## Banco de Dados
- Sql Server

## Estrutura do Projeto:
<p align="center">
    <img alt="read before" src="https://github.com/pessanitalo/Assets/blob/main/Projeto.png" />
</p>

## Para você rodar na sua máquina local, precisa ter instalado os seguintes recursos:
- https://visualstudio.microsoft.com/pt-br/vs/community
- https://dotnet.microsoft.com/pt-br/download/dotnet/8.0
- https://www.npmjs.com/package/@angular/cli/v/17.3.10
- https://nodejs.org/en
- https://azure.microsoft.com/pt-br/products/data-studio

## Para criar rapidamente o ambiente disponibilizamos as imagens Docker da aplicação:
- É necessário ter o docker instalado em seu sistema operacional (Linux, Windows ou Mac).

### Baixar a imagem do backend
docker pull italopessan/emprestimo-api
ou
https://hub.docker.com/r/italopessan/emprestimo-api

### Baixar a imagem do front end
docker pull italopessan/emprestimoapp
ou
https://hub.docker.com/r/italopessan/emprestimoapp

### Rode o comando (apontando a pasta local do arquivo): 
- `docker-compose up -d --build`
### executar o script para a criação das tabelas
- Arquivo se encontra na raiz do projeto 'emprestimodb.txt'

### Autor
[Italo Pessan](https://www.linkedin.com/in/italopessan/)
