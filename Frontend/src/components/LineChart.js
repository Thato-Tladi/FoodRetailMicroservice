import * as React from "react";
import { LineChart } from "@mui/x-charts/LineChart";

const BasicLineChart = ({ data, width = 500, height = 300 }) => {
  return (
    <LineChart
      xAxis={[{ data: data.x }]}
      title="YT"
      series={[
        {
          data: data.y,
        },
      ]}
      width={width}
      height={height}
    />
  );
};

export default BasicLineChart;
