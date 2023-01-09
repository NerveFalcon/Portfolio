FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Portfolio.UI/Portfolio.UI.csproj", "Portfolio.UI/"]
RUN dotnet restore "Portfolio.UI/Portfolio.UI.csproj"
COPY . .
WORKDIR "/src/Portfolio.UI"
RUN dotnet build "Portfolio.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Portfolio.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Portfolio.UI.dll"]
