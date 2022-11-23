#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HotelBooking/PaymentService/HotelBooking.PaymentService.csproj", "HotelBooking/PaymentService/"]
COPY ["HotelBooking/Shared/HotelBooking.Shared.csproj", "HotelBooking/Shared/"]
RUN dotnet restore "HotelBooking/PaymentService/HotelBooking.PaymentService.csproj"
COPY . .
WORKDIR "/src/HotelBooking/PaymentService"
RUN dotnet build "HotelBooking.PaymentService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HotelBooking.PaymentService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotelBooking.PaymentService.dll"]