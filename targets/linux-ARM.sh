#!/bin/bash

cd ../

dotnet restore  --no-cache


if  dotnet publish ./Neuralium/src/Neuralium.csproj --self-contained true /p:PublishTrimmed=true -c Release -o ./build -r linux-arm ; then
dotnet clean ;
 echo "publish completed"
else
echo "publish failed"
fi



   
