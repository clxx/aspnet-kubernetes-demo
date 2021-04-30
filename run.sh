#!/bin/bash

docker build -t demo-web-api:v1 AspNetKubernetesDemo/WebApi
docker build -t demo-web-app:v1 AspNetKubernetesDemo/WebApp

# Local Kubernetes:
# https://kubernetes.io/docs/tasks/tools/

# Docker Desktop Kubernetes
# https://docs.docker.com/desktop/kubernetes/

# Or minikube
# https://minikube.sigs.k8s.io/docs/start/
# https://github.com/kubernetes/minikube
# minikube start --cpus 8 --memory 8192

# Or kind
# https://kind.sigs.k8s.io/
# ./kind.exe create cluster

# Distribute Credentials Securely Using Secrets | Kubernetes
# https://kubernetes.io/docs/tasks/inject-data-application/distribute-credentials-secure/#define-container-environment-variables-using-secret-data
kubectl delete secret generic applicationinsights --ignore-not-found=true
kubectl create secret generic applicationinsights --from-literal=connection-string-api='InstrumentationKey=...;IngestionEndpoint=...'
kubectl create secret generic applicationinsights --from-literal=connection-string-app='InstrumentationKey=...;IngestionEndpoint=...'

kubectl apply -f aspnet-kubernetes-demo.yaml

kubectl get all

echo
echo 'Press Ctrl+C to stop watching (this does not stop the cluster).'
echo

kubectl get pods -w

# kubectl describe all
# kubectl delete -f aspnet-kubernetes-demo.yaml

# Thorough cleanup:

# kubectl delete all --all
# Docker Desktop: Reset Kubernetes Cluster

# Or
# minikube delete

# Or
# kind delete cluster
