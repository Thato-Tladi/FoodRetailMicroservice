import * as React from "react";
import { BarChart } from "@mui/x-charts/BarChart";

const BasicBarChart = ({ data }) => {
  return (
    <BarChart
      title="Average Price per Consumer"
      xAxis={[{ scaleType: "band", data: data.x, title: "Consumer ID" }]}
      yAxis={[{ title: "Average Price" }]}
      series={[{ data: data.y, label: "Average Price" }]}
      width={500}
      height={300}
    />
  );
};

export default BasicBarChart;
