FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CarteiraDigital/CarteiraDigital.csproj", "CarteiraDigital/"]
RUN dotnet restore "CarteiraDigital/CarteiraDigital.csproj"
COPY . .
WORKDIR "/src/CarteiraDigital"
RUN dotnet build "CarteiraDigital.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarteiraDigital.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarteiraDigital.dll"]
