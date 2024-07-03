
export const calculateMonthlyProfit = (consumerHistory) => {
    const monthlyProfit = consumerHistory.reduce((acc, cur) => {
      const date = new Date(cur.purchasedDate);
      const year = date.getFullYear();
      const month = date.toLocaleString('default', { month: 'long' });
  
      const key = `${month} ${year}`;
      acc[key] = (acc[key] || 0) + cur.price;
  
      return acc;
    }, {});
  
    const sortedKeys = Object.keys(monthlyProfit).sort((a, b) => {
      const dateA = new Date(a);
      const dateB = new Date(b);
      return dateA - dateB;
    });
  
    const x = sortedKeys.map(key => key);
    const y = sortedKeys.map(key => monthlyProfit[key]);
  
    return {
      x: x,
      y: y,
    };
  };
  
  export const processAveragePriceData = (consumerHistory) => {
    const averagePricePerConsumer = consumerHistory.reduce((acc, cur) => {
      acc[cur.consumerId] = acc[cur.consumerId] || { total: 0, count: 0 };
      acc[cur.consumerId].total += cur.price;
      acc[cur.consumerId].count += 1;
      return acc;
    }, {});
  
    return {
      x: Object.keys(averagePricePerConsumer),
      y: Object.values(averagePricePerConsumer).map((val) => val.total / val.count),
    };
  };
  
  export const processPurchaseDistributionData = (consumerHistory) => {
    const purchaseDistributionData = consumerHistory.reduce((acc, cur) => {
      acc[cur.consumerId] = (acc[cur.consumerId] || 0) + 1;
      return acc;
    }, {});
  
    const sortedData = Object.entries(purchaseDistributionData)
      .sort((a, b) => b[1] - a[1])
      .map(([id, value]) => ({ id: Number(id), value, label: `Consumer ${id}` }));
  
    const top7Data = sortedData.slice(0, 5);
    const otherValue = sortedData.slice(5).reduce((acc, cur) => acc + cur.value, 0);
  
    if (otherValue > 0) {
      top7Data.push({ id: 0, value: otherValue, label: "Other" });
    }
  
    return top7Data;
  };
  
  export const unitsSoldPerMonth = (consumerHistory) => {
    const unitsSoldPerMonth = consumerHistory.reduce((acc, cur) => {
      const date = new Date(cur.purchasedDate);
      const year = date.getFullYear();
      const month = date.toLocaleString('default', { month: 'long' });
  
      const key = `${month} ${year}`;
      acc[key] = (acc[key] || 0) + 1;
  
      return acc;
    }, {});
  
    const sortedKeys = Object.keys(unitsSoldPerMonth).sort((a, b) => {
      const dateA = new Date(a);
      const dateB = new Date(b);
      return dateA - dateB;
    });
  
    const x = sortedKeys.map(key => key);
    const y = sortedKeys.map(key => unitsSoldPerMonth[key]);
  
    return {
      x: x,
      y: y,
    };
  };