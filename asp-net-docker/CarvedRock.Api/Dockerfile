#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV SimpleProperty="hello-from-FINAL-dockerfile"
ENV Inventory__NestedProperty="Inventory Nested Property -- Docker files"
ENV ConnectionStrings__Db="Server=notsure;Database=CarvedRockFromDockerFileDB;User Id=sa;Password=somepassword;MultipleActiveResultSets=true;"


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CarvedRock.Api/CarvedRock.Api.csproj", "CarvedRock.Api/"]
RUN dotnet restore "CarvedRock.Api/CarvedRock.Api.csproj"
COPY . .
WORKDIR "/src/CarvedRock.Api"
RUN dotnet build "CarvedRock.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarvedRock.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarvedRock.Api.dll"]