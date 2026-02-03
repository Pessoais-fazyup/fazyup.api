# Tutorial 01 — Estrutura do Projeto e Fundamentos do Entity Framework

Este documento tem como objetivo **ensinar o que foi feito e por quê**, de forma didática, pensando em alguém que **acabou de chegar no projeto** ou está tendo o **primeiro contato com Entity Framework**.

O foco aqui é **entendimento conceitual** — não explicar código linha por linha.

---

## Visão geral do projeto

Este projeto é uma **API em .NET** organizada para crescer sem virar bagunça. Cada parte foi pensada para ter uma responsabilidade bem definida, o que facilita:

* Entender o sistema
* Dar manutenção
* Adicionar novas funcionalidades
* Trabalhar em equipe

---

## Como a estrutura de pastas foi pensada

A estrutura do projeto **não é aleatória**. Ela foi criada para separar responsabilidades e facilitar a leitura do código.

### Pasta `Feature`

Aqui ficam as **funcionalidades da aplicação**, separadas por contexto.

Exemplos de contextos:

* Usuário
* Admin
* Health (verificação se a API está online)

👉 A ideia é simples: **cada funcionalidade tem seu próprio espaço**.

Isso ajuda quem chega novo a entender rapidamente onde mexer.

---

### Pasta `Shared`

Tudo que é **reutilizável** fica aqui.

Ou seja, coisas que:

* São usadas por várias partes do sistema
* Não pertencem a uma funcionalidade específica

Dentro dela existem três conceitos importantes:

#### 1️⃣ Configurações

Aqui ficam configurações globais da aplicação, como autenticação (JWT).

👉 Centralizar configurações evita código duplicado e facilita mudanças futuras.

---

#### 2️⃣ Domain

O **Domain representa o negócio** da aplicação.

É onde ficam as entidades que fazem sentido para o sistema, como:

* Usuário
* Papel do usuário (roles)

Essas classes **não sabem nada sobre banco de dados ou API**.

👉 Isso mantém o domínio limpo, independente e fácil de testar.

---

#### 3️⃣ Database

Essa pasta existe exclusivamente para lidar com o **Entity Framework**.

Nada de regra de negócio aqui.
Somente:

* Contexto do banco
* Configurações das entidades

---

## Conceito de ORM

ORM significa **Object-Relational Mapping**.

Ele faz a ponte entre o **banco de dados** e o **código C#**:

* Tabela → Classe
* Coluna → Propriedade
* Registro → Objeto

Exemplo conceitual:

* Tabela `Users` → Classe `User`
* Coluna `Email` → Propriedade `Email`

👉 O desenvolvedor trabalha com objetos, e o ORM cuida do banco.

---

## Principais componentes do Entity Framework

### 1️⃣ Entity (Entidade)

É a **classe que representa uma tabela** no banco de dados.

Cada objeto criado a partir dessa classe representa um **registro**.

---

### 2️⃣ DbContext

O `DbContext` é o **coração do Entity Framework**.

Pense nele como:

* A porta de entrada para o banco
* O lugar onde o EF entende quais entidades existem

Ele **não contém regra de negócio**.

👉 Ele apenas coordena o acesso aos dados, deixando o sistema mais organizado e testável.

---

### 3️⃣ DbSet

O `DbSet` representa uma **tabela do banco dentro do código**.

Por meio dele é possível:

* Inserir dados
* Buscar dados
* Atualizar dados
* Remover dados

---

## Como o Entity Framework funciona na prática

Fluxo simplificado:

1. Você cria as entidades (classes)
2. O EF mapeia essas entidades para o banco
3. Você consulta os dados usando LINQ
4. O EF converte isso automaticamente em SQL

👉 Assim, não é necessário escrever SQL na maior parte do tempo.

---

## Por que as configurações ficam separadas das entidades

Em vez de misturar banco de dados com as classes de domínio, foi escolhida a abordagem de **configurações externas**.

Isso traz vários benefícios:

* Entidades ficam mais limpas
* Banco de dados não se mistura com regra de negócio
* Mudanças no banco não impactam o domínio diretamente

👉 Essa é uma prática muito comum em projetos profissionais.

---

## Configuração base das entidades (BaseEntity)

Muitas entidades compartilham características comuns, como:

* Identificador (Id)
* Data de criação
* Data de atualização

Para evitar repetição, foi criada uma **entidade base**, que concentra essas informações.

Depois, o Entity Framework é configurado para:

* Reconhecer automaticamente quem herda dessa base
* Aplicar regras comuns para todas as entidades

👉 Isso garante padronização, organização e menos erros.

---

## Por que usar esse padrão

Esse modelo foi escolhido porque:

* Escala bem conforme o projeto cresce
* Facilita a entrada de novos desenvolvedores
* Segue boas práticas do mercado
* Evita código duplicado
* Mantém responsabilidades bem separadas

---

## Entity Framework Core

Atualmente, o mais utilizado é o **Entity Framework Core (EF Core)**, que é:

* Mais leve
* Mais rápido
* Multiplataforma

Ele é ideal para APIs modernas em **ASP.NET Core**.

---

## Conclusão

A organização do projeto e o uso do Entity Framework **não são apenas decisões técnicas, mas estratégicas**.

Tudo foi pensado para que:

* O código seja fácil de entender
* O sistema seja fácil de evoluir
* Novas pessoas consigam contribuir rapidamente

No próximo tutorial, o foco será:
➡️ **O que são Migrations e por que elas são importantes** 🚀
