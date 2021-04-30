# aspnet-kubernetes-demo

## Description

ASP.NET Core 5.0 Web App, Web API, and SQL Server in Kubernetes demo.

## Running with Kubernetes

Make sure you have e.g. Docker Desktop installed and Kubernetes enabled: [Deploy on Kubernetes | Docker Documentation](https://docs.docker.com/desktop/kubernetes/).

In a Bash run

`./run.sh`

and simply visit <http://localhost:8080>.

Tipp: You can always update a deployment by running `./run.sh` again.

## Running without Kubernetes

For easier local debugging start SQL Server in Docker

`docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest`

the Web API

`dotnet run --project AspNetKubernetesDemo/WebApi/WebApi.csproj` (or via Visual Studio)

and in parallel the Web App (Frontend)

`dotnet run --project AspNetKubernetesDemo/WebApp/WebApp.csproj` (or via Visual Studio)

and simply visit <http://localhost:5000>.

## Docker Cleanup

`docker system prune --all --volumes --force`

## Links

[Tutorial: Get started with EF Core in an ASP.NET MVC web app | Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-5.0)

[C# Ubuntu](https://www.microsoft.com/en-us/sql-server/developer-get-started/csharp/ubuntu)

[Deploy ASP.NET Core app to Kubernetes on Google Kubernetes Engine](https://codelabs.developers.google.com/codelabs/cloud-kubernetes-aspnetcore)

[Hello Minikube | Kubernetes](https://kubernetes.io/docs/tutorials/hello-minikube/)

[Example: Deploying PHP Guestbook application with MongoDB | Kubernetes](https://kubernetes.io/docs/tutorials/stateless-application/guestbook/)

[Deploy to Local Kubernetes · dotnet-architecture/eShopOnContainers Wiki](https://github.com/dotnet-architecture/eShopOnContainers/wiki/Deploy-to-Local-Kubernetes)

[mssql-docker/linux/sample-helm-chart at master · microsoft/mssql-docker](https://github.com/microsoft/mssql-docker/tree/master/linux/sample-helm-chart)

[Docker-Images für ASP.NET Core | Microsoft Docs](https://docs.microsoft.com/de-de/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-5.0)

[dotnet/dotnet-docker: Docker images for .NET Core and the .NET Core Tools.](https://github.com/dotnet/dotnet-docker)

## Further Reading

[.Net Core Buildpack - Paketo Buildpacks](https://paketo.io/docs/buildpacks/language-family-buildpacks/dotnet-core/)

[Graduated and incubating projects | Cloud Native Computing Foundation](https://www.cncf.io/projects/)
