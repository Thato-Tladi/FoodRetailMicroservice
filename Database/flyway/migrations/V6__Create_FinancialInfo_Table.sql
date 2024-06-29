CREATE TABLE FoodRetailMicroserviceSchema.[FinancialInfo]
(
    financial_info_id INT PRIMARY KEY IDENTITY(1,1),
    current_price DOUBLE NOT NULL,
    profit DOUBLE NOT NULL,
    updated_at DATETIME DEFAULT GETDATE()
);
GO