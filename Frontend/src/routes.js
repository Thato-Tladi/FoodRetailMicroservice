// src/routes/index.js
import React from "react";
import { Routes, Route } from "react-router-dom";
import HomePage from "./pages/ConsumerHistoryPage";
import NotFoundPage from "./pages/NotfoundPage";
import StatsPage from "./pages/StatsPage";
import WaitingForAccessPage from "./pages/WaitingForAccessPage";
import ProtectedRoute from "./components/protectedRoute";

const AppRoutes = () => {
  return (
    <Routes>
      <Route
        path="/"
        element={
          <ProtectedRoute>
            <HomePage />
          </ProtectedRoute>
        }
      />
      <Route
        path="/stats"
        element={
          <ProtectedRoute>
            <StatsPage />
          </ProtectedRoute>
        }
      />
      <Route path="/waiting-for-access" element={<WaitingForAccessPage />} />
      <Route path="*" element={<NotFoundPage />} />
    </Routes>
  );
};

export default AppRoutes;
