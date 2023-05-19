export const environment = {
  production: true,
  maxUploadFileSize: 5242880,

  apiRootUrl: 'https://muknt033.europe.ad.flextronics.com:PORT/api/',

  issuer:'https://flex.okta.com',
  redirectUri: `https://muknt033.europe.ad.flextronics.com:PORT/implicit/callback`,
  clientId: 'CLIENT_ID',
  scopes:['openid', 'email', 'profile'],
  pkce: true
};
