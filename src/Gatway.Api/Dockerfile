#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Gatway.Api/Gatway.Api.csproj", "src/Gatway.Api/"]
RUN dotnet restore "src/Gatway.Api/Gatway.Api.csproj"
COPY . .
WORKDIR "/src/src/Gatway.Api"
RUN dotnet build "Gatway.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gatway.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gatway.Api.dll"]