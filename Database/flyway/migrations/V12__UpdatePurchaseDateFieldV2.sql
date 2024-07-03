ALTER TABLE FoodRetailMicroserviceSchema.ConsumerHistory
ADD new_purchased_date VARCHAR(50);

UPDATE FoodRetailMicroserviceSchema.ConsumerHistory
SET new_purchased_date = CONVERT(VARCHAR(50), purchased_date, 120);

ALTER TABLE FoodRetailMicroserviceSchema.ConsumerHistory
DROP COLUMN purchased_date;

EXEC sp_rename 'FoodRetailMicroserviceSchema.ConsumerHistory.new_purchased_date', 'purchased_date', 'COLUMN';
