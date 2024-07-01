import * as React from "react";
import { PieChart } from "@mui/x-charts/PieChart";
import Typography from "@mui/material/Typography";
import Grid from "@mui/material/Grid";

const BasicPieChart = ({ data }) => {
  return (
    <Grid container direction="column" alignItems="center">
      <Grid item>
        <Typography variant="h6" gutterBottom>
          Top Consumers
        </Typography>
      </Grid>
      <Grid item>
        <PieChart
          series={[
            {
              data: data,
            },
          ]}
          width={600}
          height={200}
        />
      </Grid>
    </Grid>
  );
};

export default BasicPieChart;
