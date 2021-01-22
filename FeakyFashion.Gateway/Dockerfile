#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["FeakyFashion.Gateway/FeakyFashion.Gateway.csproj", "FeakyFashion.Gateway/"]
RUN dotnet restore "FeakyFashion.Gateway/FeakyFashion.Gateway.csproj"
COPY . .
WORKDIR "/src/FeakyFashion.Gateway"
RUN dotnet build "FeakyFashion.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FeakyFashion.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FeakyFashion.Gateway.dll"]
