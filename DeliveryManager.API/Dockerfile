#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /src
COPY ["DeliveryManager.API/DeliveryManager.API.csproj", "DeliveryManager.API/"]
COPY ["DeliveryManager.Infra.IoC/DeliveryManager.Infra.IoC.csproj", "DeliveryManager.Infra.IoC/"]
COPY ["DeliveryManager.Application/DeliveryManager.Application.csproj", "DeliveryManager.Application/"]
COPY ["DeliveryManager.Domain/DeliveryManager.Domain.csproj", "DeliveryManager.Domain/"]
COPY ["DeliveryManager.Infra.Repositories/DeliveryManager.Infra.Repositories.csproj", "DeliveryManager.Infra.Repositories/"]
RUN dotnet restore "DeliveryManager.API/DeliveryManager.API.csproj"
COPY . .
WORKDIR "/src/DeliveryManager.API"
RUN dotnet build "DeliveryManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeliveryManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeliveryManager.API.dll"]