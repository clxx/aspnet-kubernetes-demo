#!/bin/bash

docker build -t demo-web-api:v1 AspNetKubernetesDemo/WebApi
docker build -t demo-web-app:v1 AspNetKubernetesDemo/WebApp

kubectl apply -f aspnet-kubernetes-demo.yaml

kubectl get all

echo
echo 'Press Ctrl+C to stop watching (this does not stop the cluster).'
echo

kubectl get pods -w

# kubectl describe all
# kubectl delete -f aspnet-kubernetes-demo.yaml
