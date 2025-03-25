# =========================
# Stage 1: Build
# =========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project files and restore dependencies
COPY DndApplication.Server.csproj ./
RUN dotnet restore ./DndApplication.Server.csproj

# Copy all files and build the project
COPY . ./
RUN dotnet publish ./DndApplication.Server.csproj -c Release -o /app/out

# =========================
# Stage 2: Runtime
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Add mssql-tools to path
ENV PATH="$PATH:/opt/mssql-tools/bin"

# Copy the published output from the build stage
COPY --from=build /app/out ./

# Expose port 8080
EXPOSE 8080

# Set environment variables for ASP.NET Core
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
# Set environment variable to ensure SQL connectivity works correctly
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

# Start the application
ENTRYPOINT ["dotnet", "DndApplication.Server.dll", "--urls", "http://0.0.0.0:8080"]