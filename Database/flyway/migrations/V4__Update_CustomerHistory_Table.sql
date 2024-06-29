ALTER TABLE FoodRetailMicroserviceSchema.[ConsumerHistory]
ALTER COLUMN consumer_id BIGINT NOT NULL;
GO

ALTER TABLE FoodRetailMicroserviceSchema.[ConsumerHistory]
ADD price DOUBLE;
GO