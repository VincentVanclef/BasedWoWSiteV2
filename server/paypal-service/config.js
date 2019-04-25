const config = {
  auth: {
    connectionLimit: 10,
    host: "localhost",
    user: "root",
    password: "root",
    database: "auth",
    port: 3306
  },
  website: {
    connectionLimit: 10,
    host: "localhost",
    user: "root",
    password: "root",
    database: "website",
    port: 3306
  },

  // Paypal Settings
  HOME_URL: "http://localhost:8080/#/user/profile",
  RETURN_URL: "http://localhost:8080/#/user/donate/success",
  CANCEL_URL: "http://localhost:8080/#/user/donate/cancel",
  CLIENT_ID: "AXvSB74SknpAC2j0aycLMksXnDiMO60TU8aN265fcY-PZHHRnfC_C0Y3x22JqZC7xNm4jrseCUJyqaLI",
  SECRET_ID: "ECE_gBkNy7N6ffeTT_K2Fz7kUM4RvkLI-BoIukC7zGHH9rZXy27pyGQAwc4_Rkb2nKMXMXW5ofub5YSK"
};

module.exports = config;
