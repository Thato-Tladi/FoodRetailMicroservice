import React from "react";
import BasicTable from "../components/BasicTable";

const columns = [
  { id: "ConsumerHistoryId", label: "Consumer History ID" },
  { id: "ConsumerId", label: "Consumer ID", align: "right" },
  { id: "PurchasedDate", label: "Date Of Purchase", align: "right" },
  { id: "Price", label: "Price (BBDough)", align: "right" },
];
const rows = [
  {
    ConsumerHistoryId: 1,
    ConsumerId: 123,
    PurchasedDate: "24-06-2024",
    Price: 4.0,
  },
  {
    ConsumerHistoryId: 2,
    ConsumerId: 432,
    PurchasedDate: "24-06-2024",
    Price: 4.3,
  },
  {
    ConsumerHistoryId: 3,
    ConsumerId: 160,
    PurchasedDate: "24-06-2024",
    Price: 6.0,
  },
  {
    ConsumerHistoryId: 4,
    ConsumerId: 307,
    PurchasedDate: "24-06-2024",
    Price: 4.3,
  },
  {
    ConsumerHistoryId: 5,
    ConsumerId: 162,
    PurchasedDate: "24-06-2024",
    Price: 3.9,
  },
  {
    ConsumerHistoryId: 6,
    ConsumerId: 245,
    PurchasedDate: "25-06-2024",
    Price: 5.2,
  },
  {
    ConsumerHistoryId: 7,
    ConsumerId: 398,
    PurchasedDate: "25-06-2024",
    Price: 4.5,
  },
  {
    ConsumerHistoryId: 8,
    ConsumerId: 185,
    PurchasedDate: "25-06-2024",
    Price: 3.8,
  },
  {
    ConsumerHistoryId: 9,
    ConsumerId: 272,
    PurchasedDate: "26-06-2024",
    Price: 6.7,
  },
  {
    ConsumerHistoryId: 10,
    ConsumerId: 113,
    PurchasedDate: "26-06-2024",
    Price: 4.1,
  },
  {
    ConsumerHistoryId: 11,
    ConsumerId: 324,
    PurchasedDate: "26-06-2024",
    Price: 5.0,
  },
  {
    ConsumerHistoryId: 12,
    ConsumerId: 187,
    PurchasedDate: "27-06-2024",
    Price: 3.5,
  },
  {
    ConsumerHistoryId: 13,
    ConsumerId: 291,
    PurchasedDate: "27-06-2024",
    Price: 4.8,
  },
  {
    ConsumerHistoryId: 14,
    ConsumerId: 157,
    PurchasedDate: "27-06-2024",
    Price: 6.2,
  },
  {
    ConsumerHistoryId: 15,
    ConsumerId: 369,
    PurchasedDate: "28-06-2024",
    Price: 3.3,
  },
  {
    ConsumerHistoryId: 16,
    ConsumerId: 214,
    PurchasedDate: "28-06-2024",
    Price: 4.9,
  },
  {
    ConsumerHistoryId: 17,
    ConsumerId: 435,
    PurchasedDate: "28-06-2024",
    Price: 5.5,
  },
  {
    ConsumerHistoryId: 18,
    ConsumerId: 140,
    PurchasedDate: "29-06-2024",
    Price: 3.7,
  },
  {
    ConsumerHistoryId: 19,
    ConsumerId: 328,
    PurchasedDate: "29-06-2024",
    Price: 4.4,
  },
  {
    ConsumerHistoryId: 20,
    ConsumerId: 179,
    PurchasedDate: "29-06-2024",
    Price: 5.1,
  },
  {
    ConsumerHistoryId: 21,
    ConsumerId: 253,
    PurchasedDate: "30-06-2024",
    Price: 3.6,
  },
  {
    ConsumerHistoryId: 22,
    ConsumerId: 392,
    PurchasedDate: "30-06-2024",
    Price: 4.7,
  },
  {
    ConsumerHistoryId: 23,
    ConsumerId: 168,
    PurchasedDate: "30-06-2024",
    Price: 6.3,
  },
  {
    ConsumerHistoryId: 24,
    ConsumerId: 301,
    PurchasedDate: "01-07-2024",
    Price: 3.2,
  },
  {
    ConsumerHistoryId: 25,
    ConsumerId: 126,
    PurchasedDate: "01-07-2024",
    Price: 4.5,
  },
  {
    ConsumerHistoryId: 26,
    ConsumerId: 349,
    PurchasedDate: "01-07-2024",
    Price: 5.4,
  },
  {
    ConsumerHistoryId: 27,
    ConsumerId: 194,
    PurchasedDate: "02-07-2024",
    Price: 3.9,
  },
  {
    ConsumerHistoryId: 28,
    ConsumerId: 277,
    PurchasedDate: "02-07-2024",
    Price: 4.6,
  },
  {
    ConsumerHistoryId: 29,
    ConsumerId: 163,
    PurchasedDate: "02-07-2024",
    Price: 6.1,
  },
  {
    ConsumerHistoryId: 30,
    ConsumerId: 417,
    PurchasedDate: "03-07-2024",
    Price: 3.4,
  },
  {
    ConsumerHistoryId: 31,
    ConsumerId: 195,
    PurchasedDate: "03-07-2024",
    Price: 4.7,
  },
  {
    ConsumerHistoryId: 32,
    ConsumerId: 280,
    PurchasedDate: "03-07-2024",
    Price: 5.6,
  },
  {
    ConsumerHistoryId: 33,
    ConsumerId: 172,
    PurchasedDate: "04-07-2024",
    Price: 3.1,
  },
  {
    ConsumerHistoryId: 34,
    ConsumerId: 317,
    PurchasedDate: "04-07-2024",
    Price: 4.8,
  },
  {
    ConsumerHistoryId: 35,
    ConsumerId: 154,
    PurchasedDate: "04-07-2024",
    Price: 6.4,
  },
  {
    ConsumerHistoryId: 36,
    ConsumerId: 358,
    PurchasedDate: "05-07-2024",
    Price: 3.0,
  },
  {
    ConsumerHistoryId: 37,
    ConsumerId: 237,
    PurchasedDate: "05-07-2024",
    Price: 4.9,
  },
  {
    ConsumerHistoryId: 38,
    ConsumerId: 420,
    PurchasedDate: "05-07-2024",
    Price: 5.7,
  },
  {
    ConsumerHistoryId: 39,
    ConsumerId: 203,
    PurchasedDate: "06-07-2024",
    Price: 3.3,
  },
  {
    ConsumerHistoryId: 40,
    ConsumerId: 298,
    PurchasedDate: "06-07-2024",
    Price: 4.8,
  },
  {
    ConsumerHistoryId: 41,
    ConsumerId: 172,
    PurchasedDate: "06-07-2024",
    Price: 6.5,
  },
];

const HomePage = () => {
  return (
    <div style={{ height: "80vh", overflowY: "auto" }}>
      <h1>Consumer History</h1>
      <BasicTable columns={columns} rows={rows} />
    </div>
  );
};

export default HomePage;
