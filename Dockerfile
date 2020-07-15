FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
EXPOSE 5050
COPY ./AccountManager/dist .
ENTRYPOINT ["dotnet", "AccountManager.dll"]