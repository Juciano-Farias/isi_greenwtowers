[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/JZTLzScX)

# Trabalho Prático II

Integração de Sistemas de Informação

Licenciatura em Engenharia de Sistemas Informáticos (regime _pós-laboral_) 2023-24

## constituição do grupo _99_

| número | nome | email |
| :----- | :--- | :---- |
| ...    | ...  | ...   |
| ...    | ...  | ...   |
| ...    | ...  | ...   |

## problema a resolver

título
: _o título do projeto_

breve descrição
: _uma breve descrição do problema a resolver_

mais informação
:

- _algumas referências acerca deste projeto_
- ...

## organização do repositório

[doc/](./doc/) documentação com o relatório

[src/](./src/) código da solução desenvolvida

# Green Towers Web API

<h2 align="center">
  <img alt="Logo" src="./logo.jpg" />
</h2>

<h4 align="center"> 
	🚧  🚀 Em construção...  🚧
</h4>

<p align="center">
 <a href="#-sobre-o-projeto">Sobre</a> •
 <a href="#-layout">Layout</a> • 
 <a href="#-como-executar-o-projeto">Como executar</a> • 
 <a href="#-tecnologias">Tecnologias</a> • 
</p>

## 💻 Sobre o projeto

O projeto Green Towers surge pela necessidade de uma aplicação que centralize a comunicação, necessidades e agendamentos entre os condôminos e o administrador do condomínio

---

## 🎨 Layout

O layout da aplicação está disponível no Figma:

<a href="https://www.figma.com/file/8dGv9queLnF8RUjZ2qmHBq/Sistema?t=ff4s6KgyZRwNuz6f-0">
  <img alt="Layout da app" src="https://www.figma.com/file/Cx5744SNmQVbRGQlbtIanh/PDM%2FPA%2FISI?type=design&node-id=0-1&mode=design&t=YKZrpdvGt0E3AMg4-0">
</a>

---

## 🚀 Como executar o projeto

### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com), [Docker](https://nodejs.org/en/).
Além disto é bom ter um editor para trabalhar com o código como [VSCode](https://code.visualstudio.com/)

🧭 Rodando a aplicação web API

```bash
# Clone este repositório
$ git clone <https://github.com/Juciano-Farias/PDM-PA-ISI.git>

# Suba o container
$ docker-compose up -d

# Acesse a pasta da webapi
$ cd src

# Aplique as migrations
$ cd ./Api.Data/
$ dotnet ef database update
$ cd ..

# Execute a build
$ dotnet build

# Execute a webapi
$ cd ./Api.Application/
$ dotnet run

# O servidor inciará na porta:5159 - acesse <http://localhost:5159/>
```

---

## 🛠 Tecnologias

As seguintes ferramentas estão sendo usadas na construção do projeto:

- **[.NET Core 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)**
- **[Entity Framework](https://learn.microsoft.com/en-us/ef/)**
- **[DDD](https://en.wikipedia.org/wiki/Domain-driven_design)**
- **[Docker](https://www.docker.com/)**
- **[PostgreSQL](https://www.postgresql.org/)**
- **[C#](https://learn.microsoft.com/en-us/dotnet/csharp/)**
