FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["examples.elastic.api/examples.elastic.api.csproj", "examples.elastic.api/"]
RUN dotnet restore "examples.elastic.api/examples.elastic.api.csproj"
COPY . .
WORKDIR "/src/examples.elastic.api"
RUN dotnet build "examples.elastic.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "examples.elastic.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "examples.elastic.api.dll"]
