#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/FAT.Customer.API/FAT.Customer.API.csproj", "src/FAT.Customer.API/"]
RUN dotnet restore "src/FAT.Customer.API/FAT.Customer.API.csproj"
COPY . .
WORKDIR "/src/src/FAT.Customer.API"
RUN dotnet build "FAT.Customer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FAT.Customer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FAT.Customer.API.dll"]