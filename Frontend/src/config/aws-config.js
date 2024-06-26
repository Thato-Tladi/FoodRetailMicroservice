const oauthConfig = {
  domain: process.env.REACT_APP_COGNITO_DOMAIN,
  scopes: process.env.REACT_APP_COGNITO_SCOPES.split(","),
  responseType: process.env.REACT_APP_COGNITO_RESPONSE_TYPE,
  redirectSignIn: process.env.REACT_APP_COGNITO_REDIRECT_SIGNIN,
  redirectSignOut: process.env.REACT_APP_COGNITO_REDIRECT_SIGNOUT,
};

const awsConfig = {
  Auth: {
    Cognito: {
      mandatorySignIn: true,
      region: process.env.REACT_APP_COGNITO_REGION,
      userPoolId: process.env.REACT_APP_COGNITO_USER_POOL_ID,
      userPoolClientId: process.env.REACT_APP_COGNITO_USER_POOL_CLIENT_ID,
      loginWith: {
        oauth: oauthConfig,
      },
    },
  },
};

export default awsConfig;
