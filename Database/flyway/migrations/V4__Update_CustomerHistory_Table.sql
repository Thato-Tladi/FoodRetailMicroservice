ALTER TABLE FoodRetailMicroserviceSchema.[ConsumerHistory]
ALTER COLUMN consumer_id BIGINT NOT NULL;

ALTER TABLE FoodRetailMicroserviceSchema.[ConsumerHistory]
ADD price FLOAT NOT NULL;