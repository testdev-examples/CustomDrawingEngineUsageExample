#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

RUN apt-get update

RUN apt-get install -y software-properties-common
RUN add-apt-repository 'deb http://deb.debian.org/debian sid main'
RUN apt-get update
RUN apt-get install -y libgdiplus libc6-dev
RUN apt-get install -y libicu-dev libharfbuzz0b libfontconfig1 libfreetype6
RUN apt-get install -y libpango-1.0-0
RUN apt-get install -y libpangocairo-1.0

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TestReportsApp/TestReportsApp.csproj", "TestReportsApp/"]
RUN dotnet restore "TestReportsApp/TestReportsApp.csproj"
COPY . .
WORKDIR "/src/TestApp"
RUN dotnet build "TestReportsApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestReportsApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestReportsApp.dll"]