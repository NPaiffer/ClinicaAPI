# Integrantes: Alissa Silva Cezero - RM552535, Melissa Barbosa de Souza - RM552535, Nicolas Paiffer do Carmo - RM554145

# ClinicaAPI - Sistema de Gerenciamento de Clínicas Odontológicas

### Visão Geral do Projeto

- O ClinicaAPI é uma aplicação RESTful desenvolvida em .NET para gerenciar informações de clínicas odontológicas, incluindo dados de dentistas, pacientes, atendimentos e outros. O objetivo do projeto é centralizar a gestão das informações da clínica, permitindo que dentistas possam registrar e acessar dados sobre pacientes e atendimentos de forma eficiente.

### Funcionalidades Implementadas
A aplicação atualmente permite:

- Cadastro, consulta, atualização e exclusão de Usuários, Endereços, Telefones, Clínicas, Pacientes, Dentistas e Atendimentos.
- Autenticação e autorização (em desenvolvimento) para controlar o acesso a recursos da API.
- Integração com o banco de dados Oracle para persistência e gerenciamento seguro dos dados.
- Interface com layout customizado: Inclui cabeçalho, rodapé e navegação desenvolvidos com Bootstrap, proporcionando uma experiência visual aprimorada.
- Validação e feedback para o usuário nas principais funcionalidades, como o formulário de contato.

### Escopo do Projeto
O escopo atual do sistema é:

1. Cadastro de Usuários e Pacientes: Permite o gerenciamento completo das informações de cadastro.
2. Gerenciamento de Dentistas e Especialidades: Registro e atualização dos dados profissionais.
3. Registro de Atendimentos: Associando atendimentos a pacientes e dentistas de maneira centralizada.
4. Conexão com Banco de Dados Oracle: Utilizado para garantir a persistência e integridade dos dados.
5. Operações CRUD (Create, Read, Update, Delete) para todas as entidades.

### Requisitos Funcionais
- O sistema permite o cadastro de novos usuários, pacientes e dentistas.
- Possibilita o gerenciamento de especialidades de dentistas.
- Oferece uma API que permite realizar operações CRUD para todas as entidades.
- Conecta-se ao banco de dados Oracle para persistir os dados.

### Requisitos Não Funcionais
- Performance: A API responde em menos de 1 segundo para operações simples.
- Padrão REST: Segue o padrão REST para facilitar a integração com outras aplicações.
- Autenticação JWT: Implementação planejada para proteger os endpoints com autenticação baseada em JWT.
- Boas práticas de desenvolvimento: Arquitetura baseada em camadas para escalabilidade e manutenção.

### Instruções de Instalação e Configuração
1. Pré-requisitos:

- .NET SDK (versão compatível com o ASP.NET Core utilizado no projeto)
- Banco de dados Oracle configurado e acessível com as permissões necessárias
- Visual Studio ou Visual Studio Code instalado para desenvolvimento e execução

2. Instalação:
- Clone o repositório:
  git clone
  cd ClinicaAPI

- Restaure as dependências:
  dotnet restore

- Para iniciar a aplicação e testar suas funcionalidades, execute:
  dotnet run

3. Uso da API:
- Utilize ferramentas como Postman para testar os endpoints da API e verificar o funcionamento das operações CRUD.

  
