#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["API/API.csproj", "API/"]
COPY ["Framework/Framework.AssemblyHelper/Framework.AssemblyHelper.csproj", "Framework/Framework.AssemblyHelper/"]
COPY ["Framework/Framework.Core/Framework.Core.csproj", "Framework/Framework.Core/"]
COPY ["ReadModel/ReadModel.Context/TicketContext.ReadModel.Context.csproj", "ReadModel/ReadModel.Context/"]
COPY ["Contract/TicketContext.Contract/TicketContext.Contract.csproj", "Contract/TicketContext.Contract/"]
COPY ["ReadModel/ReadModel.Query.Contracts/TicketContext.ReadModel.Query.Contracts.csproj", "ReadModel/ReadModel.Query.Contracts/"]
COPY ["ReadModel/ReadModel.Pagination/ReadModel.Pagination.csproj", "ReadModel/ReadModel.Pagination/"]
COPY ["ReadModel/ReadModel.Query.Facade/TicketContext.ReadModel.Query.Facade.csproj", "ReadModel/ReadModel.Query.Facade/"]
COPY ["WriteModel/Persistence/Persistence/Persistence.csproj", "WriteModel/Persistence/Persistence/"]
COPY ["Framework/Framework.Persistence/Framework.Persistence.csproj", "Framework/Framework.Persistence/"]
COPY ["Framework/Framework.Domain/Framework.Domain.csproj", "Framework/Framework.Domain/"]
COPY ["WriteModel/Ticket/Infrastructure/TicketContext.Infrastructure/TicketContext.Infrastructure.csproj", "WriteModel/Ticket/Infrastructure/TicketContext.Infrastructure/"]
COPY ["WriteModel/Ticket/Domain/TicketContext.Domain/TicketContext.Domain.csproj", "WriteModel/Ticket/Domain/TicketContext.Domain/"]
COPY ["WriteModel/Ticket/Resource/TicketContext.Resource/TicketContext.Resource.csproj", "WriteModel/Ticket/Resource/TicketContext.Resource/"]
COPY ["WriteModel/Ticket/ApplicationService/TicketContext.ApplicationService.Contract/TicketContext.ApplicationService.Contract.csproj", "WriteModel/Ticket/ApplicationService/TicketContext.ApplicationService.Contract/"]
COPY ["WriteModel/Ticket/ApplicationService/TicketContext.ApplicationService/TicketContext.ApplicationService.csproj", "WriteModel/Ticket/ApplicationService/TicketContext.ApplicationService/"]
COPY ["WriteModel/Ticket/Domain/TicketContext.Domain.Services/TicketContext.Domain.Services.csproj", "WriteModel/Ticket/Domain/TicketContext.Domain.Services/"]
COPY ["WriteModel/Ticket/Domain/TicketContext.Domain.Test/TicketContext.Domain.Test.csproj", "WriteModel/Ticket/Domain/TicketContext.Domain.Test/"]
COPY ["WriteModel/Ticket/Facade/TicketContext.CenterCommandFacade.Contract/TicketContext.Facade.Contract.csproj", "WriteModel/Ticket/Facade/TicketContext.CenterCommandFacade.Contract/"]
COPY ["WriteModel/Ticket/Facade/TicketContext.Facade/TicketContext.Facade.csproj", "WriteModel/Ticket/Facade/TicketContext.Facade/"]
COPY ["Framework/Framework.Facade/Framework.Facade.csproj", "Framework/Framework.Facade/"]
COPY ["WriteModel/Ticket/TicketContext.Configuration/TicketContext.Configuration.csproj", "WriteModel/Ticket/TicketContext.Configuration/"]
COPY ["Framework/framework.DependencyInjection/Framework.DependencyInjection.csproj", "Framework/framework.DependencyInjection/"]
COPY ["Framework/Framework.ApplicationService/Framework.ApplicationService.csproj", "Framework/Framework.ApplicationService/"]
RUN dotnet restore "API/API.csproj"
COPY . .
WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]