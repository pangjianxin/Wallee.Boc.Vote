#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/Wallee.Boc.Vote.Web/Wallee.Boc.Vote.Web.csproj", "src/Wallee.Boc.Vote.Web/"]
COPY ["src/Wallee.Boc.Vote.Application/Wallee.Boc.Vote.Application.csproj", "src/Wallee.Boc.Vote.Application/"]
COPY ["src/Wallee.Boc.Vote.Domain/Wallee.Boc.Vote.Domain.csproj", "src/Wallee.Boc.Vote.Domain/"]
COPY ["src/Wallee.Boc.Vote.Domain.Shared/Wallee.Boc.Vote.Domain.Shared.csproj", "src/Wallee.Boc.Vote.Domain.Shared/"]
COPY ["src/Wallee.Boc.Vote.Application.Contracts/Wallee.Boc.Vote.Application.Contracts.csproj", "src/Wallee.Boc.Vote.Application.Contracts/"]
COPY ["src/Wallee.Boc.Vote.HttpApi/Wallee.Boc.Vote.HttpApi.csproj", "src/Wallee.Boc.Vote.HttpApi/"]
COPY ["src/Wallee.Boc.Vote.EntityFrameworkCore/Wallee.Boc.Vote.EntityFrameworkCore.csproj", "src/Wallee.Boc.Vote.EntityFrameworkCore/"]
RUN dotnet restore "src/Wallee.Boc.Vote.Web/Wallee.Boc.Vote.Web.csproj"
COPY . .
WORKDIR "/src/src/Wallee.Boc.Vote.Web"
RUN dotnet build "Wallee.Boc.Vote.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Wallee.Boc.Vote.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN ln -sf /usr/share/zoneinfo/Asia/Shanghai /etc/localtime
RUN echo 'Asia/Shanghai' >/etc/timezone
ENTRYPOINT ["dotnet", "Wallee.Boc.Vote.Web.dll"]