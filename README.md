# web-api

<h3> Implementação </h3>
<hr/>
  <ul>
  <li>ASP.NET CORE 6</li>
  <li>EntityFramework 6 com Npgsql</li>
  <li>PostgreSQL</li>
  <li>MVC</li>
<ul/>
<hr/><br/>
    
<h3> Sobre o projeto: </h3>
    <p> O projeto foi implementado com o uso de camadas (service e repository), cada uma com a sua devida responsabilidade. A service é responsável pela regra de negócios implementada; A repository é designada para o acesso ao banco de dados com entity framework. Cada uma possui uma interface para criar um acesso seguro a instância e aumentar a escalabilidade do projeto;</p>
    <p> Através da interface foi implementado a injenção de depêndencia nas classes para cada necessidade;</p>
    <p> Existe um crud generico criado para ser herdado por outras classes que possuem um cadastro básico, facilitando a implementação de possiveis entidades novas; (BaseRepository)</p>
    <p> EndPoints documentados com swaggers</p>
  <hr/>

