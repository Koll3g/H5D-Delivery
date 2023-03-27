#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["H5D-Delivery.Mgmt.Gui/H5D-Delivery.Mgmt.Gui.csproj", "H5D-Delivery.Mgmt.Gui/"]
RUN dotnet restore "H5D-Delivery.Mgmt.Gui/H5D-Delivery.Mgmt.Gui.csproj"
COPY . .
WORKDIR "/src/H5D-Delivery.Mgmt.Gui"
RUN dotnet build "H5D-Delivery.Mgmt.Gui.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "H5D-Delivery.Mgmt.Gui.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "H5D-Delivery.Mgmt.Gui.dll"]