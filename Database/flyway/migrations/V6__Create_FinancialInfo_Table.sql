CREATE TABLE FoodRetailMicroserviceSchema.[FinancialInfo]
(
    financial_info_id INT PRIMARY KEY IDENTITY(1,1),
    property_name VARCHAR NOT NULL,
    property_value VARCHAR NOT NULL,
    updated_at DATETIME DEFAULT GETDATE()
);
GO