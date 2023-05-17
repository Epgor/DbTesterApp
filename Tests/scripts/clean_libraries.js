const axios = require('axios');
const https = require('https');
const https_agent = new https.Agent(
    {
        rejectUnauthorized: false
    });
const base_url = "https://localhost:7085";
const endpoints = ["mongo/MongoLibrary", 
                   "redis/RedisLibrary", 
                   "mssql/MssqlLibrary"]

endpoints.forEach(endpoint => 
        axios.delete(`${base_url}/api/${endpoint}`,
        {
            httpsAgent: https_agent
        })
);
