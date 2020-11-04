Entendendo .Net
Entity Framework Core: mapeador relacional de objeto (ORM)

  - Permite trabalhar com banco de dados usando objetos .NET.
  - Elimina a necessidade da maior parte do código de acesso a dados que normalmente precisa ser escrito.
  - Permite criar uma representação do banco de dados em memória (DataContext)

Com EF Core, o acesso a dados é executado usando um modelo (Model). 
Um modelo é composto de classes de entidade e um objeto de contexto (Context) que representa uma sessão com o banco de dados. O objeto Context permite consultar e salvar dados.

O EF dá suporte às seguintes abordagens de desenvolvimento de modelo:
 
  - Gere um modelo a partir de um banco de dados existente.
  - Codifique manualmente um modelo para corresponder ao banco de dados.
  - Depois que um modelo é criado, use as migrações do EF para criar um banco de dados do modelo. As migrações permitem a evolução do banco de dados conforme o modelo é alterado.




DataBaseContext
  - Responsável por mapear os objetos para o banco de dados. Apenas as classes configuradas nesse arquivo serão mapeadas.
  - DbContext: classe herdada do EntiityFrameworkCore para criar uma sessão com o banco de dados.
  - Cria a conexão propriamente dita com o banco de dados



ORM
 - Classes -> Tabelas
 - Atualização no código para refletir no banco -> Migrations


Alguns comandos:
  dotnet restore 
    restaura todos os pacotes
  
  dotnet ef migrations add <migration-name>  
    criar migrations -> lê DataContext e os   respectivos models e gera script SQL automáticamente para gerar o banco de dados -> gera arquivo de migration (up/down)

  dotnet ef database update
    atualiza banco de dados -> executar sempre após a criação de cada migration


DataMapper

  - IEntityTypeConfiguration<ObjetoModel>
  - Permite melhorar a geração do banco (com objetivo de performance);
  - Define o nome das tabelas, relacionamentos, validações, etc
  - OnModelCreating -> builder apply para cada Mapper -> para aplicar os mappers na criação das tabelas (migration)
  - Executar criação da migration e update database



MVC
  - dotnet add package Microsoft.AspNetCore.Mvc

CONTROLLER
  - Classe que herda de Controller, do EntityFrameworkCore
  - Acesso ao DataContext (DC) e Model
  - Ao instanciar um DC, cria-se uma nova conexão com o banco, então é necessário garantir que existe apenas um DC no controller -> construtor -> controller precisa de um DC (injeção de dependência) -> gera uma dependência com o DC, ou seja, o controller precisa do DC para funcionar.
  - Resolver essa dependência gerada no Startup.cs -> services.AddScoped ou services.AddTransient -> 
  - AsNoTracking -> ao fazer uma leitura do banco, o EF traz uma proxy (contem informações adicionais da categoria: se foi adicionado, removido, etc) que contem informações extras que acabam afetando aperformance.
  - o Context é sempre em memória -> executar o SaveChanges() para salvar no banco 


VIEW MODELS
 Objetos de transporte para mostrar apenas o que se deseja a quem solicitou. Trata-se de uma adequação para o resultado final da API.