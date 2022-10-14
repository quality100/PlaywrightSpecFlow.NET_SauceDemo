FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["playwright_specflow/playwright_specflow.csproj", "playwright_specflow/"]
RUN dotnet restore "playwright_specflow/playwright_specflow.csproj"
COPY . .
WORKDIR "/src/playwright_specflow"
RUN dotnet build "playwright_specflow.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "playwright_specflow.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "playwright_specflow.dll"]
