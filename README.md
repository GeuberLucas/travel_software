# Projeto de Sistema de Gerenciamento de Romarias 

## Descrição do Projeto

Este projeto consiste no desenvolvimento de um sistema de gerenciamento de viagens de ônibus, utilizando a arquitetura limpa. O sistema permitirá o cadastro de passageiros, o registro de viagens e o cadastro de informações sobre os ônibus utilizados.


## Tecnologias Utilizadas

- Linguagem de Programação:  C#
- Frameworks: ASP.NET
- Banco de Dados: SQL SERVER 

## Arquitetura Limpa

A arquitetura limpa (Clean Architecture) será adotada para garantir uma estrutura modular e independente de frameworks, facilitando a manutenção e testabilidade do código. A arquitetura será organizada em camadas, como apresentado a seguir:

1. **Entidades:** Representação das entidades principais do sistema, como `Passageiro`, `Viagem` e `Ônibus`.
2. **Casos de Uso (Use Cases):** Contém os casos de uso da aplicação, representando as operações específicas que o sistema pode realizar. Exemplos incluem `CadastrarPassageiro`, `RegistrarViagem` e `CadastrarOnibus`.
3. **Interfaces de Serviço:** Define interfaces que serão implementadas fora da camada de casos de uso, como por exemplo `PassageiroRepository` e `ViagemRepository`.
4. **Adaptadores:** Converte os dados da camada de casos de uso para as interfaces de serviço. Pode incluir adaptadores para banco de dados, API, entre outros.


## Padrões de Projeto 
-MVC (Model-View-Controller): Este padrão poderá ser alterado para segregar o front-end do back-end
-Repository
-CQRS


## Entidades

### Passageiros(Clientes)

- **Atributos:**
  - Id
  - Created_At
  - Updated_At
  - Nome completo
  - CPF
  - RG
  - Data de nascimento
  - Telefone
  - Orgao_Emissor
  - Url_Doc_Identidade

- **Casos de Uso:**
  - Cadastrar passageiro
  - Consultar informações do passageiro
  - Atualizar dados do passageiro
  - Remover passageiro

### Viagens

- **Atributos:**
  - Id
  - Created_At
  - Updated_At
  - Cidade_Destino
  - Uf_Destino
  - Cidade_Origem
  - Uf_Origem
  - Data e horário de partida
  - Data e horário de retorno
  - Valor_Passagem

- **Casos de Uso:**
  - Registrar viagem
  - Consultar informações da viagem
  - Atualizar dados da viagem
  - Cancelar viagem

### Ônibus

- **Atributos:**
  - Id
  - Created_At
  - Updated_At
  - Número_Onibus
  - Id_Modelo
  - Empresa

- **Casos de Uso:**
  - Cadastrar ônibus
  - Consultar informações do ônibus
  - Atualizar dados do ônibus
  - Remover ônibus

### Passagem

- **Atributos:**
  - Id
  - Created_At
  - Updated_At
  - Id_Passageiro
  - Id_Onibus
  - Id_viagem
  - Poltrona_onibus

### Tipo_Ônibus

- **Atributos:**
  - Id
  - Created_At
  - Updated_At
  - Descricao
  - Quantidade_Poltronas

## Diagrama do Banco De Dados
o diagrama a seguir representa como está as relaçôes no banco de dados 


<img src="https://github.com/GeuberLucas/travel_software/blob/master/Imagens_Readme/diagrame%20Er%20Travel_Software.png" alt="Diagram ER" >



