import React from "react";
import { Authenticator } from "@aws-amplify/ui-react";
import { Amplify } from "aws-amplify";
import awsConfig from "./config/aws-config.js";
import "./App.css";
import "@aws-amplify/ui-react/styles.css";
import AppRoutes from "./routes";

Amplify.configure(awsConfig);

function App() {
  return (
    <Authenticator className="App" hideSignUp socialProviders={["google"]}>
      <AppRoutes />
    </Authenticator>
  );
}

export default App;
