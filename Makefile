run:
	cd WFB.Backend && dotnet build -c Release -o app/
	docker compose up frontend
	
run-backend:
	cd WFB.Backend && dotnet build -c Release -o app/
	cd WFB.Backend && ./wagi -c ./api.toml
	
run-docker:
	cd WFB.BackendApi && dotnet build -c Release -o app/
	docker compose up backend-api

run-frontend:
	cd WFB.Frontend && dotnet run
    