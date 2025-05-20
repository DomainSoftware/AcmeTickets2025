FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 5271

ENV ASPNETCORE_URLS=http://+:5271

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Domains/EventManagement/Api/Api.csproj", "Domains/EventManagement/Api/"]
RUN dotnet restore "Domains/EventManagement/Api/Api.csproj"
COPY . .
WORKDIR "/src/Domains/EventManagement/Api"
RUN dotnet build "Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
