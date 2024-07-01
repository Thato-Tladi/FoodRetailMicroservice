import { fetchAuthSession } from "aws-amplify/auth";
import { jwtDecode } from "jwt-decode";

export const getToken = async () => {
  try {
    const session = await fetchAuthSession();
    const idToken = session.tokens?.idToken?.toString();
    return idToken;
  } catch (error) {
    console.error("Error fetching token:", error);
    return null;
  }
};

export const isAdmin = async () => {
  const token = await getToken();
  if (token) {
    const decodedToken = jwtDecode(token);
    const groups = decodedToken["cognito:groups"] || [];
    return groups.includes("Admin");
  }
  return false;
};
