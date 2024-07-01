import React, { useEffect, useState } from "react";
import { Grid, Box } from "@mui/material";
import axios from "axios";
import BasicLineChart from "../components/LineChart";
import BasicPieChart from "../components/PieChart";
import BasicBarChart from "../components/BarChart";
// API call function
const getConsumerHistory = async () => {
  try {
    const response = await axios.get(
      "https://api.sustenance.projects.bbdgrad.com/api/ConsumerHistory"
    );
    return response.data;
  } catch (error) {
    throw error;
  }
};

const StatsPage = () => {
  const [consumerHistory, setConsumerHistory] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getConsumerHistory();
        setConsumerHistory(data);
      } catch (err) {
        setError(err);
      }
    };

    fetchData();
  }, []);

  if (error) {
    return <div>Error: {error.message}</div>;
  }

  // Process data for charts
  const averagePricePerConsumer = consumerHistory.reduce((acc, cur) => {
    acc[cur.consumerId] = acc[cur.consumerId] || { total: 0, count: 0 };
    acc[cur.consumerId].total += cur.price;
    acc[cur.consumerId].count += 1;
    return acc;
  }, {});

  const averagePriceData = {
    x: Object.keys(averagePricePerConsumer),
    y: Object.values(averagePricePerConsumer).map(
      (val) => val.total / val.count
    ),
  };

  const priceTrendData = {
    x: consumerHistory.map((history) => new Date(history.purchasedDate)),
    y: consumerHistory.map((history) => history.price),
  };

  const purchaseDistributionData = consumerHistory.reduce((acc, cur) => {
    acc[cur.consumerId] = (acc[cur.consumerId] || 0) + 1;
    return acc;
  }, {});

  const purchaseDistributionPieData = Object.entries(
    purchaseDistributionData
  ).map(([id, value]) => ({
    id: Number(id),
    value,
    label: `Consumer ${id}`,
  }));

  return (
    <div>
      <h1>Consumer History</h1>
      <Box sx={{ p: 2 }}>
        <Grid justifyContent="space-between" container spacing={2}>
          <Grid
            sx={{ display: "flex", justifyContent: "center" }}
            item
            xs={12}
            sm={6}
          >
            <BasicBarChart data={averagePriceData} />
          </Grid>
          <Grid
            sx={{ display: "flex", justifyContent: "center" }}
            item
            xs={12}
            sm={6}
          >
            <BasicPieChart data={purchaseDistributionPieData} />
          </Grid>
          <Grid item xs={12} sx={{ display: "flex", justifyContent: "center" }}>
            <BasicLineChart data={priceTrendData} width={1000} height={500} />
          </Grid>
        </Grid>
      </Box>
    </div>
  );
};

export default StatsPage;
