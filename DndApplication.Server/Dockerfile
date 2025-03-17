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

# Install curl, procps, gnupg, iproute2, iputils-ping, and mssql-tools
RUN apt-get update && apt-get install -y curl procps gnupg iproute2 iputils-ping \
    && curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
    && curl https://packages.microsoft.com/config/debian/10/prod.list > /etc/apt/sources.list.d/mssql-release.list \
    && apt-get update \
    && ACCEPT_EULA=Y apt-get install -y msodbcsql17 mssql-tools \
    && echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc

# Copy the published output from the build stage
COPY --from=build /app/out ./

# Expose port 5002
EXPOSE 5002

# Set environment variables for ASP.NET Core
ENV ASPNETCORE_URLS=http://0.0.0.0:5002
ENV ASPNETCORE_ENVIRONMENT=Development

# Start the application
ENTRYPOINT ["dotnet", "DndApplication.Server.dll", "--urls", "http://0.0.0.0:5002"]