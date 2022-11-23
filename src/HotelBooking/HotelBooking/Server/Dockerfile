#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HotelBooking/Server/HotelBooking.Server.csproj", "HotelBooking/Server/"]
COPY ["HotelBooking/Client/HotelBooking.Client.csproj", "HotelBooking/Client/"]
COPY ["HotelBooking/Shared/HotelBooking.Shared.csproj", "HotelBooking/Shared/"]
RUN dotnet restore "HotelBooking/Server/HotelBooking.Server.csproj"
COPY . .
WORKDIR "/src/HotelBooking/Server"
RUN dotnet build "HotelBooking.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HotelBooking.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotelBooking.Server.dll"]