import React from "react";
import { Routes, Route } from "react-router-dom";
import HomePage from "./pages/ConsumerHistoryPage";

const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/Consumer History" element={<HomePage />} />
      <Route path="*" element={<HomePage />} />
    </Routes>
  );
};

export default AppRoutes;
