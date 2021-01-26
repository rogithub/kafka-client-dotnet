# Commands

## Server Connect
    - docker-compose exec broker bash

## Create topic with partitions
    - kafka-topics --bootstrap-server broker:9092 --topic test --create --replication-factor 1 --partitions 3

## Delete topic
    - kafka-topics --bootstrap-server broker:9092 --topic test --delete

## List topics
    - kafka-topics --list --bootstrap-server localhost:9092

## Describe topic
    - kafka-topics --bootstrap-server localhost:9092 --topic test --describe

## List groups
    - kafka-consumer-groups --bootstrap-server localhost:9092 --list

## Describe consumer group
    - kafka-consumer-groups --bootstrap-server localhost:9092 --group text-consumer-group1 --describe



## List all docker containers
    - docker container ls -a

## Remove containner
    - docker container rm cc3f2ff51cab cd20b396a061



## Tmux session re-attach
    - tmux attach -t AT

## Tmux list sessions
    - tmux list-sessions
