#!/bin/bash
while ! nc -z localhost 5672; 
do 
    echo 'waiting for rabbitmq'    
    sleep 3; 
done
echo 'rabbitmq is runnin'

