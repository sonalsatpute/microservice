FROM rabbitmq:3.7.4-management-alpine

LABEL maintainer="sonal.satpute@gmail.com"
COPY rabbitmq.config /etc/rabbitmq/
COPY definitions.json /etc/rabbitmq/
CMD ["rabbitmq-server"]