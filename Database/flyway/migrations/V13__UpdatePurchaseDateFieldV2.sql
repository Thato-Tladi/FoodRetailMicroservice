ALTER TABLE FoodRetailMicroserviceSchema.ConsumerHistory
ADD purchase_date VARCHAR(50);

UPDATE FoodRetailMicroserviceSchema.ConsumerHistory
SET purchase_date = CONVERT(VARCHAR(50), purchased_date, 120);

ALTER TABLE FoodRetailMicroserviceSchema.ConsumerHistory
DROP COLUMN purchased_date;

EXEC sp_rename 'FoodRetailMicroserviceSchema.ConsumerHistory.purchase_date', 'purchased_date', 'COLUMN';
