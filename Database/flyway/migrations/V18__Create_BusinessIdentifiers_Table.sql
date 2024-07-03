CREATE TABLE FoodRetailMicroserviceSchema.[BusinessIdentifiers]
(
    business_identifier_id INT PRIMARY KEY IDENTITY(1,1),
    property_name VARCHAR NOT NULL,
    property_value VARCHAR NOT NULL
);
GO