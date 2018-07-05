#!/bin/bash

CRED=$(tput setaf 1 2> /dev/null)
CGREEN=$(tput setaf 2 2> /dev/null)
CDEFAULT=$(tput sgr0 2> /dev/null)

echo Creating output folder...
mkdir artifact

echo Restoring packages for all solutions

cd src
dotnet restore Service/Service.csproj

echo Building project...
dotnet build Service/Service.csproj --configuration Release

echo Publishing release....
dotnet publish Service/Service.csproj --configuration Release --output publish

echo Creating artifact directory...
cd Service/publish
cp -R . ../../../artifact/