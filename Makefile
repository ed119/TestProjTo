project = testProjection
solution = TestProjection

rm-db: stop-db
	@docker rm $(project)-db

stop-db:
	@docker stop $(project)-db

start-db:
	@docker start $(project)-db

create-db:
	@docker run -d \
	-p 54324:5432 \
	--name=$(project)-db \
	--restart=always \
	-e POSTGRES_DB=$(project) \
	-e POSTGRES_USER=$(project) \
	-e POSTGRES_PASSWORD=$(project) \
	postgres:alpine

migrate:
	@dotnet ef database update -s ./$(solution)/ -p ./$(solution).DataAccess/

migrate-add:
	@dotnet ef migrations add $(name) -s ./$(solution)/ -p ./$(solution).DataAccess/

migrate-rm:
	@dotnet ef migrations remove -s ./$(solution)/ -p ./$(solution).DataAccess/
	
run:
	docker build -t cbh-api .
	docker rm -f cbh-api || true
	docker run -d --name cbh-api \
		-e PROXY_URL=http://cbh-proxy:8080 \
		-p 8081:80 \
		--add-host cbh-proxy:192.168.1.73 \
		cbh-api