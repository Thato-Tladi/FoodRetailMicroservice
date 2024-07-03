ALTER TABLE FoodRetailMicroserviceSchema.[ConsumerHistory]
DROP CONSTRAINT DF__ConsumerH__purch__398D8EEE;

ALTER TABLE FoodRetailMicroserviceSchema.[ConsumerHistory]
ALTER COLUMN purchased_date VARCHAR(255) NOT NULL;