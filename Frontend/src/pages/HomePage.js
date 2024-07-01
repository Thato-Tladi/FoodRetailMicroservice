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
    PurchasedDate: "2024-06-24 10:15:30",
    Price: 4.0,
  },
  {
    ConsumerHistoryId: 2,
    ConsumerId: 432,
    PurchasedDate: "2024-06-24 11:20:45",
    Price: 4.3,
  },
  {
    ConsumerHistoryId: 3,
    ConsumerId: 160,
    PurchasedDate: "2024-06-24 12:25:50",
    Price: 6.0,
  },
  {
    ConsumerHistoryId: 4,
    ConsumerId: 307,
    PurchasedDate: "2024-06-24 13:30:55",
    Price: 4.3,
  },
  {
    ConsumerHistoryId: 5,
    ConsumerId: 162,
    PurchasedDate: "2024-06-24 14:35:00",
    Price: 3.9,
  },
];

const HomePage = () => {
  return (
    <div>
      <h1>Consumer History</h1>
      <BasicTable columns={columns} rows={rows} />
    </div>
  );
};

export default HomePage;
