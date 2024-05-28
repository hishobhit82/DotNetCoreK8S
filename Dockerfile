FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /source

COPY ./MyLocalServiceCore/MyLocalServiceCore.csproj ./MyLocalServiceCore/MyLocalServiceCore.csproj
COPY ./MyLocalEntities/MyLocalEntities.csproj ./MyLocalEntities/MyLocalEntities.csproj
COPY ./PeronsFactory/PersonsFactory.csproj ./PeronsFactory/PersonsFactory.csproj

COPY ./MyLocalServiceCore.sln .

RUN dotnet restore

COPY . .

RUN dotnet build -c Release

RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
ENV PORT 80
EXPOSE 80
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "MyLocalServiceCore.dll"]
