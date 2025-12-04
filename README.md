# BibliotecaRestFull

## Visão Geral
Este projeto é uma API para gerenciamento de uma biblioteca, implementada em .NET 10 e C# 14.0. Trata-se de um projeto **didático**, criado para fins de estudo e demonstração. O principal objetivo foi seguir fielmente o padrão RESTful nas rotas, facilitando o entendimento e uso dos endpoints. Não houve nenhuma preocupação com validação de dados.

## Estrutura e Separação dos Projetos
O projeto está dividido em múltiplas camadas, cada uma com sua responsabilidade:

- **Api**: Camada de apresentação, responsável pelos controllers e definição das rotas RESTful.
- **Aplicacao**: Camada de aplicação, onde ficam as interfaces e serviços que conectam a API à lógica de negócio.
- **Dominio**: Camada de domínio, contendo as entidades e interfaces que representam as regras de negócio.
- **InfraEstrutura**: Camada de infraestrutura, responsável pela persistência de dados e acesso ao banco.

## Bibliotecas Utilizadas
- **ASP.NET Core**: Para construção da API RESTful.
- **Entity Framework Core**: Para mapeamento e acesso ao banco de dados.
- **Swashbuckle/Swagger**: Para documentação automática dos endpoints (se configurado).

## Padrão das Rotas RESTful
As rotas seguem o padrão RESTful, utilizando os verbos HTTP adequados:

- `GET /api/[controller]` — Listagem de recursos
- `GET /api/[controller]/{id}` — Busca de recurso por ID
- `POST /api/[controller]` — Criação de recurso
- `PUT /api/[controller]/{id}` — Atualização de recurso
- `DELETE /api/[controller]/{id}` — Exclusão de recurso

## Avisos Importantes
Este projeto **não** seguiu os seguintes padrões e práticas:

- **Mapeamento de DTOs**: O uso de DTOs foi mínimo e não há mapeamento sofisticado entre entidades e DTOs.
- **Testes TDD**: Não foram implementados testes automatizados ou práticas de Test Driven Development.
- **Clean Code**: O foco não foi em legibilidade, organização ou boas práticas de código limpo.
- **DDD (Domain Driven Design)**: Não foi seguido o padrão de DDD na modelagem das entidades e serviços.

- **Validação de Dados**: Não houve preocupação com validação dos dados recebidos ou enviados pela API.

O objetivo principal foi demonstrar o funcionamento de uma API RESTful, sem se preocupar com padrões avançados de arquitetura ou testes.

---