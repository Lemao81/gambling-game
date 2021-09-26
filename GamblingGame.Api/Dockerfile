#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GamblingGame.Api/GamblingGame.Api.csproj", "GamblingGame.Api/"]
COPY ["GamblingGame.Domain/GamblingGame.Domain.csproj", "GamblingGame.Domain/"]
COPY ["GamblingGame.Repo/GamblingGame.Repo.csproj", "GamblingGame.Repo/"]
RUN dotnet restore "GamblingGame.Api/GamblingGame.Api.csproj"
COPY . .
WORKDIR "/src/GamblingGame.Api"
RUN dotnet build "GamblingGame.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GamblingGame.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GamblingGame.Api.dll"]
