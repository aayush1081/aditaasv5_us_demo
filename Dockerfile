# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /source

# copy csproj and restore as distinct layers
COPY V5RESTApi.sln .
COPY V5RESTApi/*.csproj ./V5RESTApi/
RUN dotnet restore

# copy everything else and build app
COPY V5RESTApi/. ./V5RESTApi/
WORKDIR /source/V5RESTApi
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0

RUN apt-get update
RUN apt-get install -y apt-utils
RUN apt-get install -y libgdiplus
RUN apt-get install -y libc6-dev 
RUN ln -s /usr/lib/libgdiplus.so/usr/lib/gdiplus.dll

RUN apt-get install -y --no-install-recommends gss-ntlmssp

WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "V5RESTApi.dll"]