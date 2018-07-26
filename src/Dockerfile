FROM microsoft/dotnet:sdk AS build
WORKDIR /app

# Copy csproj and restore as distinct layers

COPY Domain/*.csproj ./Domain/
COPY Entities/*.csproj ./Entities/
COPY MessageBroker/*.csproj ./MessageBroker/
COPY Service/*.csproj ./Service/

WORKDIR /app/Service
RUN dotnet restore

# copy and publish app and libraries
WORKDIR /app/

COPY Domain/. ./Domain/
COPY Entities/. ./Entities/
COPY MessageBroker/. ./MessageBroker/
COPY Service/. ./Service/

WORKDIR /app/Service
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1-runtime AS runtime
WORKDIR /app
COPY --from=build /app/Service/out ./
ENTRYPOINT ["dotnet", "Service.dll"]