FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Pazaar.Web/Pazaar.Web.csproj", "Pazaar.Web/"]
RUN dotnet restore "Pazaar.Web/Pazaar.Web.csproj"
COPY . .
WORKDIR "/src/Pazaar.Web"
RUN dotnet build "Pazaar.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pazaar.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pazaar.Web.dll"]