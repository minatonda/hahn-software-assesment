# dotnet run --project ./dotnet/hahn-software-assesment/HahnApi/HahnApi.csproj --urls http://0.0.0.0:5094 &
# dotnet run --project ./dotnet/hahn-software-assesment/HahnWorkerService/HahnWorkerService.csproj --urls http://0.0.0.0:5000 &
# cd ./typescript/hahn-software-assesment && npm run prod

dotnet run --project ./backend/HahnApi/HahnApi.csproj --urls http://0.0.0.0:5094 &
dotnet run --project ./backend/HahnWorkerService/HahnWorkerService.csproj --urls http://0.0.0.0:5000 &
cd ./frontend && npm run prod