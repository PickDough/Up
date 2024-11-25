FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Up.Client/Up.Client.csproj", "Up.Client/"]
RUN dotnet restore "Up.Client/Up.Client.csproj"
COPY . .
WORKDIR "/src/Up.Client"
RUN dotnet build "Up.Client.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Up.Client.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY Up.Client/nginx.conf /etc/nginx/nginx.conf
