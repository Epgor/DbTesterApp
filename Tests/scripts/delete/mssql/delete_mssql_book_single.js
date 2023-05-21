import http from "k6/http";
import { sleep, group } from "k6";
import { simple_scenario } from "./../scenarios.js";
import { BASE_URL, HEADERS } from "../../create/book_request_params.js";

export let options = {
  discardResponseBodies: true,
  scenarios: {
    scenario: simple_scenario,
  },
};

export default function () {
  //var delete_url = `${BASE_URL}/api/mssql/MssqlBook/testdelete`;
  //http.get(delete_url, { headers: HEADERS });
  var delete_url = `${BASE_URL}/api/mssql/MssqlBook/testdelete`;
  http.post(delete_url, { headers: HEADERS });
};

export function handleSummary(data) {
  console.log('Preparing the end-of-test summary...');

  return {
    'delete-book-mssql-single.json': JSON.stringify(data)
  };
};