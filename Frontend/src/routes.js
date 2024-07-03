// src/routes/index.js
import React from "react";
import { Routes, Route } from "react-router-dom";
import HomePage from "./pages/ConsumerHistoryPage";
import NotFoundPage from "./pages/NotfoundPage";
import StatsPage from "./pages/StatsPage";

const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/" element={<HomePage />} />
      <Route path="/stats" element={<StatsPage />} />
      <Route path="*" element={<NotFoundPage />} />
    </Routes>
  );
};

export default AppRoutes;
