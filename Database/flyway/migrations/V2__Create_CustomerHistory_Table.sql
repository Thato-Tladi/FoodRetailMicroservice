CREATE TABLE FoodRetailMicroserviceSchema.[CustomerHistory]
(
    consumer_history_id INT PRIMARY KEY IDENTITY(1,1),
    consumer_id INT NOT NULL UNIQUE,
    purchased_date DATETIME NOT NULL DEFAULT GETDATE()

);
GO
