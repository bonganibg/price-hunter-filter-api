#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PriceHunterFilterAPI.csproj", "."]
RUN dotnet restore "./PriceHunterFilterAPI.csproj"
RUN nuget restore PriceHunterFilterAPI.sln
COPY . .
WORKDIR "/src/."
RUN dotnet build "PriceHunterFilterAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PriceHunterFilterAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PriceHunterFilterAPI.dll"]
