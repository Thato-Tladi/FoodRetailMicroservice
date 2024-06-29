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
import TextField from '@mui/material/TextField';

export default function BasicTable({ columns, rows }) {
  const [sortConfig, setSortConfig] = useState({ key: '', direction: 'asc' });
  const [searchQuery, setSearchQuery] = useState('');

  const filteredRows = React.useMemo(() => {
    return rows.filter((row) =>
      columns.some((column) =>
        row[column.id].toString().toLowerCase().includes(searchQuery.toLowerCase())
      )
    );
  }, [rows, columns, searchQuery]);

  const sortedRows = React.useMemo(() => {
    if (sortConfig.key) {
      return [...filteredRows].sort((a, b) => {
        if (a[sortConfig.key] < b[sortConfig.key]) {
          return sortConfig.direction === 'asc' ? -1 : 1;
        }
        if (a[sortConfig.key] > b[sortConfig.key]) {
          return sortConfig.direction === 'asc' ? 1 : -1;
        }
        return 0;
      });
    }
    return filteredRows;
  }, [filteredRows, sortConfig]);

  const handleSortChange = (key) => {
    setSortConfig((prevState) => ({
      key,
      direction: prevState.key === key && prevState.direction === 'asc' ? 'desc' : 'asc',
    }));
  };

  return (
    <div>
      <div style={{ marginBottom: '16px', marginTop: '16px', display: 'flex', alignItems: 'center', flexWrap: 'wrap' }}>
        <FormControl variant="outlined" style={{ minWidth: 180, marginRight: '8px', borderColor: '#001F3F', }}>
          <InputLabel>Sort by</InputLabel>
          <Select
            value={sortConfig.key}
            onChange={(e) => handleSortChange(e.target.value)}
            label="Sort by"
            sx={{ '& .MuiOutlinedInput-notchedOutline': { borderColor: '#001F3F' } }}
          >
            {columns.map((column) => (
              <MenuItem key={column.id} value={column.id}>
                {column.label}
              </MenuItem>
            ))}
          </Select>
        </FormControl>
        <Box sx={{ display: 'flex', alignItems: 'center' }}>
          <IconButton onClick={() => setSortConfig((prevState) => ({ ...prevState, direction: prevState.direction === 'asc' ? 'desc' : 'asc' }))}>
            {sortConfig.direction === 'asc' ? <ArrowUpwardIcon sx={{ color: '#2C3A92', marginLeft: '-12px' }} /> : <ArrowDownwardIcon sx={{ color: '#2C3A92', marginLeft: '-12px' }} />}
          </IconButton>
        </Box>
        <TextField
          label="Search"
          variant="outlined"
          value={searchQuery}
          onChange={(e) => setSearchQuery(e.target.value)}
          style={{ marginLeft: '16px', minWidth: '300px', flexGrow: 1, borderColor: '#001F3F' }}
          InputProps={{
            sx: { '&:hover .MuiOutlinedInput-notchedOutline': { borderColor: '#001F3F' }, '& .MuiOutlinedInput-notchedOutline': { borderColor: '#001F3F' } }
          }}
        />
      </div>
      <Box sx={{ width: '100%', overflowX: 'auto' }}>
        <TableContainer component={Paper}>
          <Table sx={{ minWidth: 200 }}>
            <TableHead>
              <TableRow>
                {columns.map((column) => (
                  <TableCell key={column.id} align="center" sx={{ fontWeight: 'bold' }}>
                    {column.label}
                  </TableCell>
                ))}
              </TableRow>
            </TableHead>
            <TableBody>
              {sortedRows.map((row, rowIndex) => (
                <TableRow
                  key={rowIndex}
                  sx={{
                    '&:last-child td, &:last-child th': { border: 0 },
                    backgroundColor: rowIndex % 2 === 0 ? 'lightgray' : 'white',
                  }}
                >
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
      </Box>
    </div>
  );
}
