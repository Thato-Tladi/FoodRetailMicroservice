import React, { useState } from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import FormControl from '@mui/material/FormControl';
import InputLabel from '@mui/material/InputLabel';
import Select from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';
import IconButton from '@mui/material/IconButton';
import ArrowUpwardIcon from '@mui/icons-material/ArrowUpward';
import ArrowDownwardIcon from '@mui/icons-material/ArrowDownward';
import Box from '@mui/material/Box';

export default function BasicTable({ columns, rows }) {
  const [sortConfig, setSortConfig] = useState({ key: '', direction: 'asc' });

  const sortedRows = React.useMemo(() => {
    if (sortConfig.key) {
      return [...rows].sort((a, b) => {
        if (a[sortConfig.key] < b[sortConfig.key]) {
          return sortConfig.direction === 'asc' ? -1 : 1;
        }
        if (a[sortConfig.key] > b[sortConfig.key]) {
          return sortConfig.direction === 'asc' ? 1 : -1;
        }
        return 0;
      });
    }
    return rows;
  }, [rows, sortConfig]);

  const handleSortChange = (key) => {
    setSortConfig((prevState) => ({
      key,
      direction: prevState.key === key && prevState.direction === 'asc' ? 'desc' : 'asc',
    }));
  };

  return (
    <div>
      <div style={{ marginBottom: '16px', display: 'flex', alignItems: 'center' }}>
        <FormControl variant="outlined" style={{ minWidth: 120, marginRight: '16px' }}>
          <InputLabel>Sort by</InputLabel>
          <Select
            value={sortConfig.key}
            onChange={(e) => handleSortChange(e.target.value)}
            label="Sort by"
          >
            {columns.map((column) => (
              <MenuItem key={column.id} value={column.id}>
                {column.label}
              </MenuItem>
            ))}
          </Select>
        </FormControl>
        <IconButton onClick={() => setSortConfig((prevState) => ({ ...prevState, direction: prevState.direction === 'asc' ? 'desc' : 'asc' }))}>
          {sortConfig.direction === 'asc' ? <ArrowUpwardIcon sx={{ color: '#2C3A92' }} /> : <ArrowDownwardIcon sx={{ color: '#2C3A92' }} />}
        </IconButton>
      </div>
      <Box sx={{ width: '100%', overflowX: 'auto' }}>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 650 }}>
            <TableHead>
              <TableRow>
                {columns.map((column) => (
                  <TableCell key={column.id} align={column.align || 'left'} sx={{ fontWeight: 'bold' }}>
                    {column.label}
                  </TableCell>
                ))}
              </TableRow>
            </TableHead>
            <TableBody>
              {sortedRows.map((row, rowIndex) => (
                <TableRow key={rowIndex} sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                  {columns.map((column) => (
                    <TableCell key={column.id} align={column.align || 'left'}>
                      {row[column.id]}
                    </TableCell>
                  ))}
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Box>
    </div>
  );
}
