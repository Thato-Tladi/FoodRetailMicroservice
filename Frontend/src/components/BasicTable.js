import React, { useState } from "react";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import FormControl from "@mui/material/FormControl";
import InputLabel from "@mui/material/InputLabel";
import Select from "@mui/material/Select";
import MenuItem from "@mui/material/MenuItem";
import IconButton from "@mui/material/IconButton";
import ArrowUpwardIcon from "@mui/icons-material/ArrowUpward";
import ArrowDownwardIcon from "@mui/icons-material/ArrowDownward";
import Box from "@mui/material/Box";
import TextField from "@mui/material/TextField";
import CircularProgress from "@mui/material/CircularProgress";
import "../css/tableStyles.css";

function parseDate(dateString) {
  const [day, month, year] = dateString.split("/");
  return new Date(`${year}-${month}-${day}`);
}

export default function BasicTable({ columns, rows, loading }) {
  const [sortConfig, setSortConfig] = useState({ key: "", direction: "asc" });
  const [searchQuery, setSearchQuery] = useState("");

  const filteredRows = React.useMemo(() => {
    return rows.filter((row) =>
      columns.some((column) =>
        row[column.id]
          .toString()
          .toLowerCase()
          .includes(searchQuery.toLowerCase())
      )
    );
  }, [rows, columns, searchQuery]);

  const sortedRows = React.useMemo(() => {
    if (sortConfig.key) {
      return [...filteredRows].sort((a, b) => {
        if (sortConfig.key === "PurchasedDate") {
          const dateA = parseDate(a[sortConfig.key]);
          const dateB = parseDate(b[sortConfig.key]);

          if (dateA < dateB) {
            return sortConfig.direction === "asc" ? -1 : 1;
          }
          if (dateA > dateB) {
            return sortConfig.direction === "asc" ? 1 : -1;
          }
          return 0;
        } else {
          if (a[sortConfig.key] < b[sortConfig.key]) {
            return sortConfig.direction === "asc" ? -1 : 1;
          }
          if (a[sortConfig.key] > b[sortConfig.key]) {
            return sortConfig.direction === "asc" ? 1 : -1;
          }
          return 0;
        }
      });
    }
    return filteredRows;
  }, [filteredRows, sortConfig]);

  const handleSortChange = (key) => {
    setSortConfig((prevState) => ({
      key,
      direction:
        prevState.key === key && prevState.direction === "asc" ? "desc" : "asc",
    }));
  };

  return (
    <div>
      <div className="container">
        <FormControl variant="outlined" className="formControl">
          <InputLabel className="input-label">Sort by</InputLabel>
          <Select
            value={sortConfig.key}
            onChange={(e) => handleSortChange(e.target.value)}
            label="Sort by"
            className="select"
          >
            {columns.map((column) => (
              <MenuItem key={column.id} value={column.id}>
                {column.label}
              </MenuItem>
            ))}
          </Select>
        </FormControl>
        <Box sx={{ display: "flex", alignItems: "center" }}>
          <IconButton
            onClick={() =>
              setSortConfig((prevState) => ({
                ...prevState,
                direction: prevState.direction === "asc" ? "desc" : "asc",
              }))
            }
            style={{ marginLeft: "8px" }} // Add padding to the left of the IconButton
          >
            {sortConfig.direction === "asc" ? (
              <ArrowUpwardIcon className="iconButton" />
            ) : (
              <ArrowDownwardIcon className="iconButton" />
            )}
          </IconButton>
        </Box>
        <TextField
          label="Search"
          variant="outlined"
          value={searchQuery}
          onChange={(e) => setSearchQuery(e.target.value)}
          className="textField"
        />
      </div>
      <Box sx={{ width: "100%", overflowX: "auto" }}>
        {loading ? (
          <Box className="loadingBox">
            <CircularProgress />
          </Box>
        ) : (
          <TableContainer component={Paper} className="tableContainer">
            <Table>
              <TableHead>
                <TableRow>
                  {columns.map((column) => (
                    <TableCell
                      key={column.id}
                      align="center"
                      className="tableCell"
                    >
                      {column.label}
                    </TableCell>
                  ))}
                </TableRow>
              </TableHead>
              <TableBody>
                {sortedRows.map((row, rowIndex) => (
                  <TableRow key={rowIndex} className="tableRow">
                    {columns.map((column) => (
                      <TableCell key={column.id} align="center">
                        {row[column.id]}
                      </TableCell>
                    ))}
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </TableContainer>
        )}
      </Box>
    </div>
  );
}
