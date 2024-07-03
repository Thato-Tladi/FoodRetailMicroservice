import React, { useEffect, useState } from 'react';
import BasicTable from '../components/BasicTable';
import { getConsumerHistory } from '../api/api';

const columns = [
  { id: 'ConsumerHistoryId', label: 'Consumer History ID' },
  { id: 'ConsumerId', label: 'Consumer ID', align: 'right' },
  { id: 'PurchasedDate', label: 'Date Of Purchase', align: 'right' },
  { id: 'Price', label: 'Price (BBDough)', align: 'right' },
];

const ConsumerHistoryPage = () => {
  const [rows, setRows] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchConsumerHistory = async () => {
      try {
        const data = await getConsumerHistory();
        const formattedData = data.map(item => ({
          ConsumerHistoryId: item.consumerHistoryId,
          ConsumerId: item.consumerId,
          PurchasedDate: new Date(item.purchasedDate).toLocaleDateString('en-GB'),
          Price: item.price,
        }));
        setRows(formattedData);
      } catch (error) {
        console.error('Error fetching consumer history data:', error);
      } finally {
        setLoading(false);
      }
    };

    fetchConsumerHistory();
  }, []);

  return (
    <div>
      <h1>Consumer History</h1>
      <BasicTable columns={columns} rows={rows} loading={loading} />
    </div>
  );
};

export default ConsumerHistoryPage;
