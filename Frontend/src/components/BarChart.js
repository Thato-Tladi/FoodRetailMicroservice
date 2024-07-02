import React from "react";
import {
  BarChart,
  Bar,
  XAxis,
  YAxis,
  Tooltip,
  ResponsiveContainer,
  Label,
} from "recharts";

const BasicBarChart = ({ data, xAxisLabel, yAxisLabel, chartTitle }) => {
  return (
    <ResponsiveContainer width="100%" height={300}>
      <BarChart
        data={data.x.map((value, index) => ({
          name: value,
          averagePrice: data.y[index],
        }))}
        margin={{ top: 20, right: 30, left: 20, bottom: 20 }}
      >
        <XAxis dataKey="name">
          <Label value={xAxisLabel} offset={0} position="insideBottom" />
        </XAxis>
        <YAxis>
          <Label
            value={yAxisLabel}
            angle={-90}
            position="insideLeft"
            style={{ textAnchor: "middle" }}
          />
        </YAxis>
        <Tooltip />
        <Bar dataKey="averagePrice" fill="#001F3F" />
      </BarChart>
    </ResponsiveContainer>
  );
};

export default BasicBarChart;
