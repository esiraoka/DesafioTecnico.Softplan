#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DesafioTecnico.Softplan.API.CalculaJuros/DesafioTecnico.Softplan.API.CalculaJuros.csproj", "DesafioTecnico.Softplan.API.CalculaJuros/"]
RUN dotnet restore "DesafioTecnico.Softplan.API.CalculaJuros/DesafioTecnico.Softplan.API.CalculaJuros.csproj"
COPY . .
WORKDIR "/src/DesafioTecnico.Softplan.API.CalculaJuros"
RUN dotnet build "DesafioTecnico.Softplan.API.CalculaJuros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioTecnico.Softplan.API.CalculaJuros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioTecnico.Softplan.API.CalculaJuros.dll"]