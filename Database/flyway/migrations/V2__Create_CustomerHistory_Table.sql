CREATE TABLE FoodRetailMicroserviceSchema.[ConsumerHistory]
(
    consumer_history_id INT PRIMARY KEY IDENTITY(1,1),
    consumer_id INT NOT NULL,
    purchased_date DATETIME DEFAULT GETDATE(),

);
GO
