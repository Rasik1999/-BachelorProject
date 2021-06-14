FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["WorkingWithProjects.API/WorkingWithProjects.API.csproj", "WorkingWithProjects.API/"]
COPY ["WorkingWithProjects.DATA/WorkingWithProjects.DATA.csproj", "WorkingWithProjects.DATA/"]
RUN dotnet restore "WorkingWithProjects.API/WorkingWithProjects.API.csproj"
COPY . .
WORKDIR "/src/WorkingWithProjects.API/"
RUN dotnet build "WorkingWithProjects.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkingWithProjects.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkingWithProjects.API.dll"]