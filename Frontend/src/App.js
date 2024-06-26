import * as React from "react";
import { BrowserRouter as Router } from "react-router-dom";
import { Authenticator } from "@aws-amplify/ui-react";
import { Amplify } from "aws-amplify";
import awsConfig from "./config/aws-config";
import "./App.css";
import "@aws-amplify/ui-react/styles.css";
import PermanentDrawerLeft from "./components/PermanentDrawerLeft";

Amplify.configure(awsConfig);

function App() {
  return (
    <Authenticator className="App" hideSignUp socialProviders={["google"]}>
      <Router>
        <PermanentDrawerLeft />
      </Router>
    </Authenticator>
  );
}

export default App;
