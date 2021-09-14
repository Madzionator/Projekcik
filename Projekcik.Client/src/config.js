// API
const devUseLocal = true;

const localBaseUrl = "https://localhost:5001/";
const prodBaseUrl = "https://boar-api.rumsoft.lol/";
const isDev = process.env === "dev";
let baseUrl = isDev && devUseLocal ? localBaseUrl : prodBaseUrl;

// export settings
export default {
  env: process.env,
  baseUrl: baseUrl,
  isDevelopment: isDev,
  isProduction: !isDev,
};
