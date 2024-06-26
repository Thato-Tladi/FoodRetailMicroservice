import React, { useEffect } from "react";
import { getData1 } from "../api/api"; // Import your API functions

const HomePage = () => {
  // useEffect(() => {
  //   const fetchData = async () => {
  //     try {
  //       const data1 = await getData1();
  //     } catch (error) {
  //       console.error("Error fetching data:", error);
  //     }
  //   };

  //   fetchData();
  // }, []);

  return (
    <div>
      <h1>Home</h1>
      <p>Welcome to the home page.</p>
    </div>
  );
};

export default HomePage;
