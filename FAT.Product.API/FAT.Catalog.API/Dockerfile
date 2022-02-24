#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FAT.Catalog.API/FAT.Catalog.API.csproj", "FAT.Catalog.API/"]
RUN dotnet restore "FAT.Catalog.API/FAT.Catalog.API.csproj"
COPY . .
WORKDIR "/src/FAT.Catalog.API"
RUN dotnet build "FAT.Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FAT.Catalog.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FAT.Catalog.API.dll"]