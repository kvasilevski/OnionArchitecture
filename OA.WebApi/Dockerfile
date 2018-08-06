FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY OnionArchitecture.sln ./
COPY OA.WebApi/OA.WebApi.csproj OA.WebApi/
COPY OA.Repo/OA.Repo.csproj OA.Repo/
COPY OA.Data/OA.Data.csproj OA.Data/
COPY OA.Service/OA.Service.csproj OA.Service/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/OA.WebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OA.WebApi.dll"]
