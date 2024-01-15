# Projeto de Sistema de Gerenciamento de Romarias 

## Descrição do Projeto

Este projeto consiste no desenvolvimento de um sistema de gerenciamento de viagens de ônibus, utilizando a arquitetura limpa. O sistema permitirá o cadastro de passageiros, o registro de viagens e o cadastro de informações sobre os ônibus utilizados.

## Arquitetura Limpa

A arquitetura limpa (Clean Architecture) será adotada para garantir uma estrutura modular e independente de frameworks, facilitando a manutenção e testabilidade do código. A arquitetura será organizada em camadas, como apresentado a seguir:

1. **Entidades:** Representação das entidades principais do sistema, como `Passageiro`, `Viagem` e `Ônibus`.
2. **Casos de Uso (Use Cases):** Contém os casos de uso da aplicação, representando as operações específicas que o sistema pode realizar. Exemplos incluem `CadastrarPassageiro`, `RegistrarViagem` e `CadastrarOnibus`.
3. **Interfaces de Serviço:** Define interfaces que serão implementadas fora da camada de casos de uso, como por exemplo `PassageiroRepository` e `ViagemRepository`.
4. **Adaptadores:** Converte os dados da camada de casos de uso para as interfaces de serviço. Pode incluir adaptadores para banco de dados, API, entre outros.

## Funcionalidades

### Cadastro de Passageiros

- **Requisitos:**
  - Nome completo
  - CPF
  - RG
  - Data de nascimento
  - Telefoe

- **Casos de Uso:**
  - Cadastrar passageiro
  - Consultar informações do passageiro
  - Atualizar dados do passageiro
  - Remover passageiro

### Cadastro de Viagens

- **Requisitos:**
  - Destino
  - Data e horário de partida
  - Data e horário de retorno
  - Lista de ônibus responsaveis pela viagem
  - Lista de passageiros da viagem

- **Casos de Uso:**
  - Registrar viagem
  - Consultar informações da viagem
  - Atualizar dados da viagem
  - Cancelar viagem

### Cadastro de Ônibus

- **Requisitos:**
  - Número do ônibus
  - Modelo
  - Capacidade de passageiros

- **Casos de Uso:**
  - Cadastrar ônibus
  - Consultar informações do ônibus
  - Atualizar dados do ônibus
  - Remover ônibus

## Tecnologias Utilizadas

- Linguagem de Programação:  C#
- Frameworks: ASP.NET
- Banco de Dados: SQL SERVER 

## Diagrama do Banco De Dados
o diagrama a seguir representa como está as relaçôes no banco de dados 

(https://github.com/GeuberLucas/travel_software/blob/master/Imagens_Readme/diagrame%20er%20travel_software.png)

