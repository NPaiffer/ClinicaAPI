# Integrantes: <br>
Alissa Silva Cezero - RM552535 <br> Melissa Barbosa de Souza - RM552535 <br> Nicolas Paiffer do Carmo - RM554145

# ClinicaAPI - Sistema de Gerenciamento de Clínicas Odontológicas

### Visão Geral do Projeto

O **ClinicaAPI** é uma aplicação RESTful desenvolvida em **.NET** para gerenciar informações de clínicas odontológicas, incluindo dados de dentistas, pacientes, atendimentos e outros. O objetivo do projeto é centralizar a gestão das informações da clínica, permitindo que dentistas possam registrar e acessar dados sobre pacientes e atendimentos de forma eficiente.

### Funcionalidades Implementadas
A aplicação atualmente permite:

- Cadastro, consulta, atualização e exclusão de Usuários, Endereços, Telefones, Clínicas, Pacientes, Dentistas e Atendimentos.
- Autenticação e autorização (com **JWT**) para controlar o acesso aos recursos da API.
- Integração com o banco de dados **Oracle** para persistência e gerenciamento seguro dos dados.
- Documentação da API via **Swagger/OpenAPI**, proporcionando descrições claras dos endpoints e modelos de dados.
- Arquitetura baseada em camadas (Domain, Application, Infrastructure), garantindo escalabilidade e manutenção do código.
- Implementação do padrão **Singleton** para gerenciamento de configurações.

### Escopo do Projeto
O escopo atual do sistema é:

1. **Cadastro de Usuários e Pacientes**: Permite o gerenciamento completo das informações de cadastro.
2. **Gerenciamento de Dentistas e Especialidades**: Registro e atualização dos dados profissionais.
3. **Registro de Atendimentos**: Associando atendimentos a pacientes e dentistas de maneira centralizada.
4. **Conexão com Banco de Dados Oracle**: Utilizado para garantir a persistência e integridade dos dados.
5. **Operações CRUD (Create, Read, Update, Delete)** para todas as entidades.

### Requisitos Funcionais
- O sistema permite o cadastro de novos usuários, pacientes e dentistas.
- Possibilita o gerenciamento de especialidades de dentistas.
- Oferece uma API que permite realizar operações CRUD para todas as entidades.
- Conecta-se ao banco de dados **Oracle** para persistência dos dados.

### Requisitos Não Funcionais
- **Performance**: A API responde em menos de **1 segundo** para operações simples.
- **Padrão REST**: Segue o padrão REST para facilitar a integração com outras aplicações.
- **Autenticação JWT**: Implementada para proteger os endpoints com autenticação baseada em JWT.
- **Boas práticas de desenvolvimento**: Arquitetura baseada em camadas para escalabilidade e manutenção.

### Instruções de Instalação e Configuração

#### 1. Pré-requisitos:

- **.NET SDK** (versão compatível com o **ASP.NET Core** utilizado no projeto)
- **Banco de dados Oracle** configurado e acessível com as permissões necessárias
- **Visual Studio** ou **Visual Studio Code** instalado para desenvolvimento e execução

#### 2. Instalação:

Clone o repositório:
```bash
git clone https://github.com/seu-usuario/ClinicaAPI.git
cd ClinicaAPI
```

Restaure as dependências:
```bash
dotnet restore
```

Inicie a aplicação:
```bash
dotnet run
```

#### 3. Uso da API:
- Utilize ferramentas como **Postman** ou **Swagger** para testar os endpoints da API e verificar o funcionamento das operações CRUD.

#### 4. Endpoints Principais:
- `GET /api/clinica` - Retorna todas as clínicas cadastradas.
- `POST /api/clinica` - Cadastra uma nova clínica.
- `PUT /api/clinica/{id}` - Atualiza os dados de uma clínica existente.
- `DELETE /api/clinica/{id}` - Remove uma clínica do sistema.

##### Este é o nosso projeto!


