<p align="center">
  <img src="https://www.lar.ind.br/wp-content/themes/lar-by-housecricket/images/logo.png" alt="Logo" width="200"/>
</p>

# Projeto de Teste: Desenvolvedor Full Stack

## API Clean Architecture com CQRS e Docker

### O que é este projeto?
Este projeto demonstra uma implementação prática de uma API utilizando os princípios da Arquitetura Limpa, CQRS e SOLID. A aplicação é containerizada com Docker para facilitar o desenvolvimento e a implantação.

### Tecnologias utilizadas
* Backend: ASP Web Api, .net 8
* Arquitetura: Clean Architecture, CQRS
* Containers: Docker
* Documentação: Swagger
* Banco: Postgres

### Como executar
*  **Acesse o diretório do projeto:**
   cd nome-do-repositorio
*  **Execute o Docker Compose:**
   docker-compose up --build
* **Execute o Script:**
     .sql da na raiz do projeto para criar as taletas

### Estrutura do código
**Camada de Aplicação:**
* Contém a lógica de negócio e os handlers para comandos e consultas.

**Camada de Domínio:**
* Define as entidades e as regras de negócio.

**Camada de Infraestrutura:**
* Implementa os repositórios e a interação com o banco de dados.

### Contribuindo
Agradecemos sua contribuição! Para contribuir com este projeto:
1. Fork o repositório.
2. Crie um novo branch.
3. Faça suas alterações.
4. Abra um Pull Request.

### Licença
Este projeto está licenciado sob a MIT License.

**Melhorias futuras:**
* colocar testes unitários

**Autor:** Tiago Ribeiro