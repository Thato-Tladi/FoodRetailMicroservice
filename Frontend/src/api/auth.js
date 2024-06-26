import { fetchAuthSession } from "aws-amplify/auth";
const getToken = async () => {
  try {
    const session = await fetchAuthSession();
    const idToken = session.tokens?.idToken?.toString();
    return idToken;
  } catch (error) {
    console.error("Error fetching token:", error);
    return null;
  }
};

export { getToken };
