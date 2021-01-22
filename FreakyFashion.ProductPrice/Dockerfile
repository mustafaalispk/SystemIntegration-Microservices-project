#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["FreakyFashion.ProductPrice/FreakyFashion.ProductPrice.csproj", "FreakyFashion.ProductPrice/"]
RUN dotnet restore "FreakyFashion.ProductPrice/FreakyFashion.ProductPrice.csproj"
COPY . .
WORKDIR "/src/FreakyFashion.ProductPrice"
RUN dotnet build "FreakyFashion.ProductPrice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FreakyFashion.ProductPrice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FreakyFashion.ProductPrice.dll"]
