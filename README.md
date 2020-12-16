# Called
Sistema de Chamados em arquitetura de Microserviços.

## Ambiente


### Banco de Dados
Para a criação do banco de dados e tabelas, entre no Gerenciador de Pacotes Nuget e selecione o projeto "Infrastructure" de cada Microserviço e execute o seguinte comando:
```
PM> Update-Database
```


### Mensageria
Acesse o link abaixo para acessar a pagina web docker hub do RabbitMQ:
* https://hub.docker.com/_/rabbitmq

Após acessar a pagina web acima utilize o seguinte comando para iniciar o download da imagem docker do RabbitMQ
```
CMD> docker pull rabbitmq
```

Após a execução do comando acima, basta inicializar o RabbitMQ, o serviço de mensageria implementado na solução. Para iniciar o mesmo devemos executar o seguinte comando no prompt:
```
CMD> docker run -d --hostname rabbitserver --name rabbitmq-server -p 15672:15672 -p 5672:5672 rabbitmq:3-management
```


### Projeto
Toda a aplicação foi desenvolvida em Core 3.1, após a execução do comando acima basta ir nas propriedades da solução e selecionar a inicialização de todos os projetos "API".


## Requisições
Toda requisição HTTP dos microserviços e feita através da API.Gatway, que foi contruida utilizando o pacote Ocelot. Para a utlização do endpoints da soluçao, utilize as seguintes requisições:

#### GET User
* http://localhost:5000/user

#### GET User
* http://localhost:5000/user/57d033aa-7402-40cc-9371-c26a103d42af

#### POST User
* http://localhost:5000/user
```
{
  "Name": "Fulano",
  "Email": "fulano@teste.com",
  "Password": "123"
}
```

#### PUT User
* http://localhost:5000/user
```
{
  "Id": "57d033aa-7402-40cc-9371-c26a103d42af"
  "Name": "Fulano",
  "Email": "fulano@teste.com",
  "Password": "123"
}
```

#### DELETE User
* http://localhost:5000/user/57d033aa-7402-40cc-9371-c26a103d42af


### JWT Token
Os endpoints do microserviço Called necessitam de um JWT Token para completar a sua requisição, o mesmo será obtido com o seguinte endpoint:

#### POST Token
* http://localhost:5000/token
```
{
  "Email": "fulano@teste.com",
  "Password": "123"
}
```

#### GET Called
* http://localhost:5000/called

#### POST Called
* http://localhost:5000/called
```
{
  "Name": "Fulano",
  "Email": "fulano@teste.com",
  "Complaint": "Send message with microservice Called"
}
```
