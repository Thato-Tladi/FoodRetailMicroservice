import * as React from "react";
import { PieChart } from "@mui/x-charts/PieChart";

const BasicPieChart = ({ data }) => {
  return (
    <PieChart
      series={[
        {
          data: data,
        },
      ]}
      title="Test"
      width={400}
      height={200}
    />
  );
};

export default BasicPieChart;
