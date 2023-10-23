# Gerenciamento de Contatos

O Sistema de Gerenciamento de Contatos é uma aplicação web que permite aos usuários armazenar e gerenciar informações de contato de forma eficiente. Com esta ferramenta, você pode adicionar, editar, excluir e visualizar informações detalhadas sobre seus contatos, garantindo que suas informações estejam sempre organizadas e acessíveis.

Tecnologias Utilizadas:
Front-end: HTML, CSS, JavaScript
Back-end: C#, AspNet MVC e Entity Framework
Banco de Dados: SqlServer

Instalação e Uso:
* Para utilizar a lista de contatos, basta ir no arquivo appsettings.json e alterar a 
string de conexão com as configurações do seu banco sql server (Essa é a string: "Server=SERVERSQL;Database=NOMEDOBANCO;User=USUARIO;Password=SENHA").

* Após alterar a string, você abre o console de gerenciador de pacotes 
(Ferramentas >  Gerenciador de Pacotes Nuget) e digite o seguinte comando:

"update-database -Context BancoContext"

Após isso o Entity vai automaticamente criar o banco para voce.

