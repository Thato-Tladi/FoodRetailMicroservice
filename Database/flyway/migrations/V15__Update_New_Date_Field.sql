UPDATE FoodRetailMicroserviceSchema.[ConsumerHistory]
SET new_purchased_date = CONVERT(VARCHAR(50), purchased_date, 120);
