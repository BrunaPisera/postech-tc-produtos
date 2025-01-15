FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . .

RUN dotnet restore Produtos.sln

RUN dotnet publish Produtos.API/Produtos.API.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build ./app/out .
ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "Produtos.API.dll"]