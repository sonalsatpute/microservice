# RabbitMQ Docker

## Build

$ docker build -t dev-rabbitmq .

## Run

$ docker run -p 15672:15672 -p 5672:5672 --hostname dev-rabbitmq --name dev-rabbitmq dev-rabbitmq

http://localhost:15672

username: sonal
password: sonal