# =========================
# BUILD
# =========================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
 
# Copiamos el csproj y restauramos
COPY ["bootcampCLT.csproj", "./"]
RUN dotnet restore "bootcampCLT.csproj"
 
# Copiamos el resto del código
COPY . .
RUN dotnet build "bootcampCLT.csproj" -c Release -o /app/build
 
# =========================
# PUBLISH
# =========================
FROM build AS publish
RUN dotnet publish "bootcampCLT.csproj" -c Release -o /app/publish /p:UseAppHost=false
 
# =========================
# RUNTIME
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
 
EXPOSE 8080
 
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "bootcampCLT.dll"]