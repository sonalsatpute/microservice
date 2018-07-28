#!/bin/bash
while true
do
    curl -X POST "http://localhost:5000/api/Todo" -H "accept: text/plain" -H "Content-Type: application/json-patch+json" -d "{ \"id\": 0, \"name\": \"new task \", \"time\": \"2018-07-28T17:04:54.986Z\", \"isComplited\": false}"
done