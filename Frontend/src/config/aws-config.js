const oauthConfig = {
  domain: "food-retailer.auth.eu-west-1.amazoncognito.com",
  scopes: ["email", "phone", "openid"],
  responseType: "code",
  redirectSignIn: ["https://master.d1lz8960oywmlc.amplifyapp.com"],
  redirectSignOut: ["https://master.d1lz8960oywmlc.amplifyapp.com"],
};

const awsConfig = {
  Auth: {
    Cognito: {
      mandatorySignIn: true,
      region: "eu-west-1",
      userPoolId: "eu-west-1_JhHnzjXba",
      userPoolClientId: "1k3lj2hbvm593mdp1ib1ino0mj",
      loginWith: {
        oauth: oauthConfig,
      },
    },
  },
};

export default awsConfig;
