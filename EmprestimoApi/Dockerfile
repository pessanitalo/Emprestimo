#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EmprestimoApi/CredEmprestimoApi.csproj", "EmprestimoApi/"]
COPY ["Emprestimo.Data/CredEmprestimo.Data.csproj", "Emprestimo.Data/"]
COPY ["Emprestimo.Business/CredEmprestimo.Business.csproj", "Emprestimo.Business/"]
RUN dotnet restore "EmprestimoApi/CredEmprestimoApi.csproj"
COPY . .
WORKDIR "/src/EmprestimoApi"
RUN dotnet build "CredEmprestimoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CredEmprestimoApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CredEmprestimoApi.dll"]