run-backend:
	cd WFB.Backend && dotnet build -c Release -o app/
	cd WFB.Backend && ./wagi -c ./api.toml

run-frontend:
	cd WFB.Frontend && dotnet run