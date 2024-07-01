import React, { useEffect, useState } from "react";
import { Navigate } from "react-router-dom";
import { isAdmin } from "../api/auth";

const ProtectedRoute = ({ children }) => {
  const [isLoading, setIsLoading] = useState(true);
  const [isUserAdmin, setIsUserAdmin] = useState(false);

  useEffect(() => {
    const checkAdminStatus = async () => {
      const adminStatus = await isAdmin();
      setIsUserAdmin(adminStatus);
      setIsLoading(false);
    };
    checkAdminStatus();
  }, []);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (!isUserAdmin) {
    return <Navigate to="/waiting-for-access" />;
  }

  return children;
};

export default ProtectedRoute;
