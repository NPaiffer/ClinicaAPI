# ClinicaAPI - Sistema de Gerenciamento de Clínicas Odontológicas

## Objetivo do Projeto
O ClinicaAPI é uma aplicação RESTful para gerenciar informações de clínicas odontológicas,
dentistas, pacientes e atendimentos. O objetivo do projeto é simplificar o processo de gestão das informações da clínica,
permitindo que dentistas possam registrar e acessar dados sobre pacientes e atendimentos de forma eficiente.

## Escopo do Projeto
A aplicação permitirá:

- Cadastro, consulta, atualização e exclusão de Usuários, Endereços, Telefones, Clínicas, Pacientes, Dentistas e Atendimentos. 
- Autenticação e autorização para os usuários (em desenvolvimento).
- Integração com banco de dados Oracle para persistência de dados.
- Interface para interagir com a API via ferramentas como Postman ou similar.

## Requisitos Funcionais
1. O sistema deve permitir o cadastro de novos Usuários e Pacientes.
2. O sistema deve permitir o gerenciamento de informações de Dentistas e suas Especialidades.
3. O sistema deve permitir o registro de Atendimentos e associar esses atendimentos a pacientes e dentistas.
4. O sistema deve se conectar ao banco de dados Oracle para persistir os dados.
5. O sistema deve oferecer uma API que permita realizar operações CRUD (Create, Read, Update, Delete) para todas as entidades.


## Requisitos Não Funcionais
1. A API deve ser responsiva e responder em menos de 1 segundo para operações simples.
2. O sistema deve seguir os padrões REST para facilitar a integração com outras aplicações.
3. Utilizar autenticação baseada em JWT (JSON Web Token) para segurança de endpoints (em desenvolvimento).
4. A aplicação deve ser desenvolvida com a tecnologia .NET e seguir boas práticas de arquitetura de software.
