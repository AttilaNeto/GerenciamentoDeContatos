# CADASTRO-DE-CONTATOS
Lista de Contato desenvolvido em ASP NET MVC + EntityFramework CodeFirst + SQL Server

Para utilizar a lista de contatos, basta ir no arquivo appsettings.json e alterar a 
string de conexão com as configurações do seu banco sql server.

Essa é a string: "Server=SERVERSQL;Database=NOMEDATABELA;User=USUARIO;Password=SENHA"

Após alterar a string, você abre o console de gerenciador de pacotes 
(Ferramentas >  Gerenciador de Pacotes Nuget) e digite o seguinte comando:

update-database -Context BancoContext

Após isso o Entity vai automaticamente criar o banco para voce.

