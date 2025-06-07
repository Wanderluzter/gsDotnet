# 🌪️ Weatherman - Sistema de Apoio em Situações Climáticas Extremas

**Weatherman** é um aplicativo mobile inteligente que utiliza geolocalização, colaboração entre usuários e inteligência artificial para auxiliar pessoas em regiões afetadas por desastres naturais e eventos climáticos extremos.

Este projeto foi desenvolvido como parte da disciplina **Advanced Business Development with .NET**, com foco na construção de uma API REST robusta e inovadora para cenários de urgência climática.

---

## 🚨 Problema

Eventos climáticos extremos (enchentes, tempestades, queimadas, etc.) estão cada vez mais frequentes e perigosos. Em situações críticas, as pessoas frequentemente não têm acesso a informações confiáveis, comunicação segura ou suporte imediato.

---

## 🎯 Solução

A proposta do SafeZone é entregar um sistema completo com as seguintes funcionalidades:

- 📍 **Geolocalização** em tempo real das áreas afetadas
- 🛰️ **Previsão de riscos futuros** usando modelos de IA
- 🏥 **Indicação de rotas e locais seguros**
- 🗣️ **Canal de comunicação e colaboração entre usuários**
- 🤖 **IA para suporte contextual e tomada de decisão**

---

## 🛠️ Tecnologias Utilizadas

| Tecnologia            | Finalidade                                |
|-----------------------|-------------------------------------------|
| ASP.NET Core          | Backend e construção da API REST          |
| Entity Framework Core | Mapeamento objeto-relacional (ORM)        |
| Oracle                | Banco de dados relacional                 |
| Razor Pages           | Interface administrativa (se aplicável)   |
| C#                    | Lógica de negócio e modelo de dados       |
| JSON + Insomnia       | Testes e consumo da API                   |
| Swagger               | Documentação da API REST                  |
| Mobile (Futuro)       | App híbrido com Flutter ou React Native   |

---

## 🧩 Funcionalidades Principais da API

- Cadastro e autenticação de usuários
- Registro e visualização de alertas geolocalizados

---

## 📂 Estrutura do Projeto

/SafeZoneAPI

├── Controllers

├── Models

├── DTOs

├── Services

├── Data

├── Migrations

└── Program.cs

---

## 🧪 Como Executar

### Pré-requisitos

- [.NET 7 ou superior](https://dotnet.microsoft.com/download)
- Banco de dados (PostgreSQL ou Oracle)
- [Insomnia](https://insomnia.rest/) ou Postman para testes da API

### Executar localmente

```bash
git clone https://github.com/wanderluzter/gsDotnet.git
cd gsDotnet
dotnet restore
dotnet ef database update
dotnet run
```

Acesse via: http://localhost:5218/swagger

---

👥 Equipe

Leonardo José - RM556110

Raul Clauson - RM555006

Mirian Bronzati - RM555041
