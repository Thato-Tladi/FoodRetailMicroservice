import React from "react";
import {
  LineChart as RechartsLineChart,
  Line,
  XAxis,
  YAxis,
  Tooltip,
  Legend,
  ResponsiveContainer,
} from "recharts";

const BasicLineChart = ({ data, width = 500, height = 300 }) => {
  return (
    <ResponsiveContainer width="100%" height={height}>
      <RechartsLineChart data={data.x.map((value, index) => ({ name: value, profit: data.y[index] }))}>
        <XAxis dataKey="name" ticks={data.x} />
        <YAxis />
        <Tooltip />
        <Legend />
        <Line type="monotone" dataKey="profit" stroke="#001F3F" />
      </RechartsLineChart>
    </ResponsiveContainer>
  );
};

export default BasicLineChart;
