import React, { useEffect, useState } from "react";
import { Box, Typography, MenuItem, Select, FormControl, InputLabel } from "@mui/material";
import BasicPieChart from "../components/PieChart";
import BasicBarChart from "../components/BarChart";
import BasicLineChart from "../components/LineChart";
import { getConsumerHistory } from '../api/api';
import { calculateMonthlyProfit, processAveragePriceData, processPurchaseDistributionData, unitsSoldPerMonth } from '../utils/statsUtils';

const StatsPage = () => {
  const [consumerHistory, setConsumerHistory] = useState([]);
  const [error, setError] = useState(null);
  const [selectedGraph, setSelectedGraph] = useState("line");

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

  const averagePriceData = processAveragePriceData(consumerHistory);
  const top7Data = processPurchaseDistributionData(consumerHistory);
  const monthlyProfitData = calculateMonthlyProfit(consumerHistory);
  const monthlyUnitsSold = unitsSoldPerMonth(consumerHistory);

  return (
    <div>
     <Typography variant="h4" gutterBottom style={{ textAlign: 'center', margin: '20px 0', color: '#001F3F' }}>
        Consumer Statistics
      </Typography>
      <Box sx={{ p: 2 }}>
        <FormControl variant="outlined" sx={{ minWidth: 200, marginBottom: 2 }}>
          <InputLabel id="graph-select-label">Select Graph</InputLabel>
          <Select
            labelId="graph-select-label"
            value={selectedGraph}
            onChange={(e) => setSelectedGraph(e.target.value)}
            label="Select Graph"
          >
            <MenuItem value="line">Monthly Profit</MenuItem>
            <MenuItem value="bar-average">Average Sales Per Consumer</MenuItem>
            <MenuItem value="pie">Top Consumers</MenuItem>
            <MenuItem value="bar-units">Units Sold Per Month</MenuItem>
          </Select>
        </FormControl>

        <Box 
          sx={{ 
            display: "flex", 
            justifyContent: "center", 
            alignItems: "center", 
            minHeight: "60vh",
            border: '2px solid #000', 
            borderRadius: '8px', 
            padding: '16px'
          }}
        >
          {selectedGraph === "bar-average" && <BasicBarChart data={averagePriceData} width={600} height={600} xAxisLabel={"Consumer ID"} yAxisLabel={"Average Sales"} chartTitle={"Average Sales Per Consumer"} />}
          {selectedGraph === "pie" && <BasicPieChart data={top7Data} width={800} height={600} />}
          {selectedGraph === "line" && <BasicLineChart data={monthlyProfitData} width={500} height={300} />}
          {selectedGraph === "bar-units" && <BasicBarChart data={monthlyUnitsSold} width={500} height={300} xAxisLabel={"Month"} yAxisLabel={"Units Sold"} chartTitle={"Units Sold Per Month"} />}
        </Box>
      </Box>
    </div>
  );
};

export default StatsPage;
