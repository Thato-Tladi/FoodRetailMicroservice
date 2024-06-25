import React, { useEffect } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import HomePage from "./pages/HomePage";
import NotFoundPage from "./pages/NotfoundPage";
import { setToken } from "./api/auth"; // Import your token setting function
import { fetchAuthSession } from "aws-amplify/auth";

const AppRoutes = () => {
  useEffect(() => {
    const checkToken = async () => {
      try {
        const session = await fetchAuthSession();
        const token = session.tokens.accessToken.toString();
        setToken(token);
      } catch (error) {
        console.log("No session found");
      }
    };
    checkToken();
  }, []);

  return (
    <Router>
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </Router>
  );
};

export default AppRoutes;
