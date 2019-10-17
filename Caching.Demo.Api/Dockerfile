FROM mcr.microsoft.com/dotnet/core/sdk:3.0
COPY . /app
WORKDIR /app
RUN dotnet new tool-manifest
RUN dotnet restore
RUN dotnet tool install --local dotnet-ef --version 3.0.0-preview7.19362.6