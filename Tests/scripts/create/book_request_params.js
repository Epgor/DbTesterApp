export const BODY_JSON = require('./books.js');

export const BASE_URL = "https://localhost:7085"; // make sure this is not production
export const HEADERS = {
    'Content-Type': 'application/json',
    'accept': '*/*'
};
export const BODY = {
    price: "k6_price",
    category: "k6_category",
    author: "k6_author",
    id: "",
    bookName: "k6_bookName"
};
export const BODY_TEST = {
    price: "k6_price",
    category: "k6_category",
    author: "k6_author",
    id: "100000000000000000000001",
    bookName: "k6_bookName"
};
export const BODY_TEST_2 = {
    price: "k6_updated_price",
    category: "k6_updated_category",
    author: "k6_updated_author",
    id: "100000000000000000000001",
    bookName: "k6_updated_bookName"
};

