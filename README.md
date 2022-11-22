## Trabalho de conclusão de curso
### API desenvolvida em .NET 6 e C#, documentada com Swagger.
### Um site para os usuários e visitantes da cidade onde moro utilizar, o objetivo é listar todos comércios da cidade ou a maioria deles, onde será feita a busca por uma loja e assim irá ver as informações como: endereço, telefone, horário de atendimento, redes sociais, etc. Poderá filtrar por categoria de comércio também. A API foi desenvolvida em .NET 6 com C# (e também: Entity Framework Core, LINQ...) e o banco de dados relacional SQLServer para o backend do projeto, como este projeto o nosso publico alvo são os usuários utilizamos para o frontend o ReactJs com Router6 e o site é totalmente responsivo.

### Seguindo um padrão de Design Patterns e Clean Code, utilizamos o AspNet Core junto com o CQRS e Mediator para organizar ainda melhor nosso projeto. Fazendo com que ele tenha um nível profissional de projeto e que qualquer pessoa com um breve conhecimento possa dar manutenção e entender como funciona ele ao todo.

### O projeto tem integração com o S3 da AWS para armazenar as imagens em cloud. Para fazer o upload da foto no S3, você deve criar um bucket lá e configurar a localização dele e suas credenciais no arquivo CloudStorageService e também o nome do bucket em todos lugares que tem a variável bucket = " " (2 lugares) e a variável BucketName = " " (1 lugar)
### Caso não queira, pode usar o armazenamento local para as imagens mesmo, é só trocar as referência de CloudStorageService para LocalStorageService.

### No projeto também usamos uma API de mapas para localização do comércio, foi a Leaflet. É fácil usar ela com o ReactJs, apenas instalar duas bibliotecas e depois usar os componentes. Nós trazemos a latitude e longitude do banco de dados para marcar o ponto no mapa.

### Para o frontend consumir a API do backend usamos o Axios.
