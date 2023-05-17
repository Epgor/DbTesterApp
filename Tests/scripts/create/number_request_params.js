export const BODY_JSON = require('./numbers.js');

export const BASE_URL = "https://localhost:7085"; // make sure this is not production
export const HEADERS = {
    'Content-Type': 'application/json',
    'accept': '*/*'
};
export const BODY = {
    id: "",
    name: "k6_author",
    value: "k6_price"
};

