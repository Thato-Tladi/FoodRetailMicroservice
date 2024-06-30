ALTER TABLE FoodRetailMicroserviceSchema.[FinancialInfo]
ALTER COLUMN property_value BIGINT NOT NULL;

ALTER TABLE FoodRetailMicroserviceSchema.[FinancialInfo]
ALTER COLUMN property_name VARCHAR(128) NOT NULL;

INSERT INTO FoodRetailMicroserviceSchema.[FinancialInfo]
    (property_name, property_value)
VALUES 
    ('VAT', 15),
    ('FOOD_PRICE', 1024),
    ('PROFIT', 0);