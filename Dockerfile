FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore "EmailServer/EmailServer.csproj"
COPY . .
WORKDIR "/src/EmailServer"
RUN dotnet build "EmailServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmailServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmailServer.dll"]
