#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["backend/backend.csproj", "backend/"]
RUN dotnet restore "backend/backend.csproj"

WORKDIR "/src/backend"
COPY "/backend" .
RUN dotnet build "backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend.dll"]


FROM build AS migration-base
RUN PATH="$PATH:/root/.dotnet/tools"; \
    dotnet tool install --global dotnet-ef

FROM migration-base AS execute-migration
CMD PATH="$PATH:/root/.dotnet/tools"; \
    dotnet-ef migrations add InitMigration \
        -p "backend/backend.csproj" \
        --configuration Release && \ 
    dotnet-ef database update InitMigration \
        -p "backend/backend.csproj" \
        --configuration Release


FROM migration-base AS generate-schema
RUN PATH="$PATH:/root/.dotnet/tools"; \
    dotnet-ef dbcontext script \
        -p "backend/backend.csproj" \
        -o scripts/init.sql