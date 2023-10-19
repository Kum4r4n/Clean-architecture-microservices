#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/student/host/student.api/student.api.csproj", "src/student/host/student.api/"]
COPY ["src/student/core/student.application/student.application.csproj", "src/student/core/student.application/"]
COPY ["src/student/core/student.domain/student.domain.csproj", "src/student/core/student.domain/"]
COPY ["src/student/infrastructure/student.infrastructure/student.infrastructure.csproj", "src/student/infrastructure/student.infrastructure/"]
RUN dotnet restore "src/student/host/student.api/student.api.csproj"
COPY . .
WORKDIR "/src/src/student/host/student.api"
RUN dotnet build "student.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "student.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "student.api.dll"]