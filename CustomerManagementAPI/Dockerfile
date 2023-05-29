FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CustomerManagementAPI/CustomerManagementAPI.csproj", "CustomerManagementAPI/"]
RUN dotnet restore "CustomerManagementAPI/CustomerManagementAPI.csproj"
COPY . .
WORKDIR "/src/CustomerManagementAPI"
RUN dotnet build "CustomerManagementAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CustomerManagementAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerManagementAPI.dll"]