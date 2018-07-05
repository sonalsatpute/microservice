FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 62188
EXPOSE 44367

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src

COPY . .

RUN dotnet restore Entities.csproj