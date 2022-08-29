.PHONY: infra clean

infra:
	@docker-compose up -d rabbitmq

clean:
	@docker-compose down	
	@docker volume prune -f