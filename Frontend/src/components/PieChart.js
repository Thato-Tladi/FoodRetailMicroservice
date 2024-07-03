import React, { PureComponent } from "react";
import { PieChart, Pie, Cell, ResponsiveContainer, Legend } from "recharts";
import Typography from "@mui/material/Typography";
import Grid from "@mui/material/Grid";

const COLORS = ["##001F3F", "#00478F", "#11406F", "#0058B0", "#359AFF", "#004284"];

const RADIAN = Math.PI / 180;

const renderCustomizedLabel = ({
  cx,
  cy,
  midAngle,
  innerRadius,
  outerRadius,
  percent,
  index,
}) => {
  const radius = innerRadius + (outerRadius - innerRadius) * 0.5;
  const x = cx + radius * Math.cos(-midAngle * RADIAN);
  const y = cy + radius * Math.sin(-midAngle * RADIAN);

  return (
    <text
      x={x}
      y={y}
      fill="white"
      textAnchor="middle"
      dominantBaseline="middle"
      fontSize="10px"
    >
      {`${(percent * 100).toFixed(0)}%`}
    </text>
  );
};

class BasicPieChart extends PureComponent {
  render() {
    const { data } = this.props;
    return (
      <Grid container direction="column" alignItems="center">
        <Grid item>
          <Typography variant="h6" gutterBottom>
            Top Consumers
          </Typography>
        </Grid>
        <Grid item style={{ width: "100%", height: 500 }}>
          <ResponsiveContainer>
            <PieChart>
              <Pie
                data={data}
                cx="50%"
                cy="50%"
                labelLine={false}
                label={renderCustomizedLabel}
                outerRadius={120}
                fill="#8884d8"
                dataKey="value"
              >
                {data.map((entry, index) => (
                  <Cell
                    key={`cell-${index}`}
                    fill={COLORS[index % COLORS.length]}
                  />
                ))}
              </Pie>
              <Legend 
                payload={data.map((item, index) => ({
                  id: item.name,
                  type: "square",
                  value: `${item.label}`,
                  color: COLORS[index % COLORS.length],
                }))}
              />
            </PieChart>
          </ResponsiveContainer>
        </Grid>
      </Grid>
    );
  }
}

export default BasicPieChart;
