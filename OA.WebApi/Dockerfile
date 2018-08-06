FROM microsoft/dotnet:latest
COPY ./published-website /app
WORKDIR /app
EXPOSE 5000/tcp
ENTRYPOINT ["dotnet", "run"]