export const BODY_JSON = require('./workers.js');

export const BASE_URL = "https://localhost:7085"; // make sure this is not production
export const HEADERS = {
    'Content-Type': 'application/json',
    'accept': '*/*'
};
export const BODY = {
    id: "",
    workerName: "k6_workerName",
    salary: "k6_price",
    Category: "k6_category",
    Address: "k6_address"
};

