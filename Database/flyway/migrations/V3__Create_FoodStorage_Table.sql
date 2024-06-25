CREATE TABLE FoodRetailMicroserviceSchema.[FoodStorage]
(
    food_storage_id INT PRIMARY KEY IDENTITY(1,1),
    consumer_id INT NOT NULL,
    food_health_percentage DECIMAL NOT NULL,
    days_in_storage INT NOT NULL,
    has_fridge BIT
);
GO
