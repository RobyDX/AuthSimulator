#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AuthSimulator/AuthSimulator.csproj", "AuthSimulator/"]
COPY ["AuthSimulator.Business/AuthSimulator.Business.csproj", "AuthSimulator.Business/"]
RUN dotnet restore "AuthSimulator/AuthSimulator.csproj"
COPY . .
WORKDIR "/src/AuthSimulator"
RUN dotnet build "AuthSimulator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthSimulator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthSimulator.dll"]