FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/FreeCourse.Shared/*.csproj Shared/FreeCourse.Shared/
COPY Core/FreeCourse.Core/*.csproj Core/FreeCourse.Core/
COPY Services/DiscountEf/FreeCourse.Services.DiscountEfCore/*.csproj Services/DiscountEf/FreeCourse.Services.DiscountEfCore/
 
RUN dotnet restore Services/DiscountEf/FreeCourse.Services.DiscountEfCore/*.csproj
COPY . . 
RUN dotnet publish Services/DiscountEf/FreeCourse.Services.DiscountEfCore/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","FreeCourse.Services.DiscountEfCore.dll" ]