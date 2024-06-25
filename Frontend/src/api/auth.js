const getToken = () => {
  return sessionStorage.getItem("jwtToken");
};

const setToken = (token) => {
  sessionStorage.setItem("jwtToken", token);
};

const removeToken = () => {
  sessionStorage.removeItem("jwtToken");
};

export { getToken, setToken, removeToken };
