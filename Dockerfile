FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Case.SoftGenius.Api.Presentation/Case.SoftGenius.Api.Presentation.csproj", "Case.SoftGenius.Api.Presentation/"]
RUN dotnet restore "Case.SoftGenius.Api.Presentation/Case.SoftGenius.Api.Presentation.csproj"
COPY . .
WORKDIR "/src/Case.SoftGenius.Api.Presentation"
RUN dotnet build "Case.SoftGenius.Api.Presentation.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Case.SoftGenius.Api.Presentation.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Case.SoftGenius.Api.Presentation.dll"]
