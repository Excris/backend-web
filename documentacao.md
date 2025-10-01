# Tipos de API

## RESTFul 
### RESTful (Representational State Transfer) é um estilo arquitetural para APIs que utiliza o protocolo HTTP. A comunicação é baseada na manipulação de recursos (ex: /usuarios/123) usando métodos padrão do HTTP: GET (leitura), POST (criação), PUT/PATCH (atualização) e DELETE (remoção). É a API mais comum, ideal para aplicações web e mobile que precisam de um modelo de requisição-resposta.

## Web Sockets
### WebSockets é um protocolo que estabelece uma comunicação bidirecional e persistente (conexão contínua) entre o cliente e o servidor. Diferente das APIs tradicionais, que exigem uma nova requisição para cada interação, WebSockets permite a troca de dados em tempo real de forma eficiente. É ideal para aplicações como chats, jogos online e notificações instantâneas.
## AMQP
### AMQP (Advanced Message Queuing Protocol) é um protocolo de mensageria para comunicação assíncrona. Ele utiliza um broker de mensagens como intermediário, permitindo que o produtor e o consumidor de dados operem de forma desacoplada. Mensagens são armazenadas em filas, garantindo que não se percam caso um dos sistemas esteja offline. É essencial para arquiteturas de microsserviços e processamento de tarefas em segundo plano.

## GraphQL
### GraphQL é uma linguagem de consulta e manipulação de dados para APIs. Desenvolvida para resolver problemas de over-fetching e under-fetching, permite que o cliente solicite exatamente os dados que precisa em uma única requisição, eliminando a necessidade de múltiplos endpoints. Oferece flexibilidade e eficiência na busca de dados.

## gRPC
### gRPC (gRPC Remote Procedure Calls) é um framework de comunicação de alto desempenho. Utilizando Protocol Buffers para serialização de dados e HTTP/2 para transporte, permite chamadas de procedimentos remotos de forma eficiente. É amplamente utilizado na comunicação entre microsserviços, oferecendo performance superior e funcionalidades como streaming.


# Métodos HTTP

## GET
### FUNÇÃO: Recupera dados de um recurso sem alterá-lo
### USO: Obter informações, como listar usuários (GET/users) ou busca produto (GET/products/125)
## POST
### FUNÇÃO: Cria um novo recurso no servidor
### USO: Enviar dados para criar registros, como um como um novo usuário ou pedido

## PUT
### FUNÇÃO: Atualiza un recurso existente ou cria un recurso se ele não existir

### USO: Atualizar informações completas de un recurso, como os dados de usuário
## DELETE
### FUNÇÃO: Remove um recurso do servidor
### USO: Excluir registros, como um produto ou usuário

## PATCH
### FUNÇÃO: Atualiza parciamente un recurso
### USO :Alterar apenas alguns campos de um recurso, como o e-mail de um usuário

## Códigos de erro 

### 200 ok 
### Requisição foi bem-sucedida, o servidor retornou os dados  solicitados

### 201 Created 
### Requisição foi bem-sucedida, é um novo recurso foi criado.

### 400 Bad Request
### A requisição foi invalida devido a erros no formato ou nos dados enviadados 

### 401 Unauthorized
### A requisição requer altentificação, mas o clientes não fornceu credenciais validas 

### 406 Not Aceeptable
### O servidor não pode responder como o formato ou conteudo solcitado pelo cliente (Ex. O cliente aceita apenas XML, mas o servidor retorna JSON)

### 500 Internal Server Error
### Um erro genérico no servidor, indicado que alago de errado no processo

## Ferch API
### O que é: Uma internface nativa do Javascrip (disponível em navegadores modernos) para fazer requisições HTTP
### Caracteríticas:
#### Baseada em Promises; facilitando o usi com async/await
#### Simples e flexivel, mas menos robusta que bibliotecas como Axios
#### Suporta JSON, FormData, entre outro formatos
## https://developer.mozila.org/docs/web/API/Fetch_API/Using_Fetch

## Axios
## XMLHttpRequest
## Request
