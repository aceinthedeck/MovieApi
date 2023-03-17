FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MovieApi.sln", "."]
COPY ["./MovieApi/MovieApi.csproj", "./MovieApi/"]
COPY ["./MovieApiTest/MovieApiTest.csproj", "./MovieApiTest/"]

RUN dotnet restore
COPY . .
WORKDIR "/src/."
RUN dotnet build
RUN dotnet test

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MovieApi.dll"]