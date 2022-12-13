dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 6.0.0
dotnet add package Microsoft.EntityFrameworkCore --version 6.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.0
dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 6.0.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.0

-------------------------------------------------------------------------------
https://github.com/dotnet-architecture/eShopOnContainers/wiki/Explore-the-code#overview-of-the-application-code

-------------------------------------------------------------------------------
Simple way to push your docker image to docker hub
we need to create image, just we need run our project using visual studio your image will create
docker images => this command will get all the image from your system
docker login => for push the image to docker hub then you need to login first
docker tag platformservice:dev shrawanchoubey/platformservice => its take default version
docker images => now your image will show
docker push shrawanchoubey/platformservice => now your image pushed to docker hub
docker pull shrawanchoubey/platformservice:latest
docker rmi shrawanchoubey/platformservice  => for remove your docker image
docker run -p 8081:8081 shrawanchoubey/platformservice => image now run 
-------------------------------------------------------------------------------
docker --version
enable Kubernetes from docker desktop app => setting option => then checked Kubernetes option => click on Apply & Restart
run your project
docker ps
docker stop {container id} = > docker stop 7b5ac9bd453b 
docker start {container id} = > docker start 7b5ac9bd453b 
docker push {docker hub id}/platformservice = > docker push shrawanchoubey/platformservice 
-------------------------------------------------------------------------------