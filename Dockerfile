FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "SalaryManagementAPI/SalaryManagementAPI.csproj"
WORKDIR "/src/SalaryManagementAPI"
RUN dotnet build "SalaryManagementAPI.csproj" -c Release -o /app/build
RUN dotnet publish "SalaryManagementAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SalaryManagementAPI.dll"] 