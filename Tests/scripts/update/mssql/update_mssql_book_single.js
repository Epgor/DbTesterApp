import http from "k6/http";
import { sleep, group } from "k6";
import { simple_scenario } from "./../scenarios.js";
import { BODY_TEST, BASE_URL, HEADERS } from "../../create/book_request_params.js";


export let options = {
  discardResponseBodies: true,
  scenarios: {
    scenario: simple_scenario,
  },
};

export function setup() {
  var setup_url = `${BASE_URL}/api/mssql/MssqlBook/full`;
  //http.post(setup_url, JSON.stringify(BODY_TEST), { headers: HEADERS });
};

export default function () {
  var final_url = `${BASE_URL}/api/mssql/MssqlOrganization/generate/6`;
  http.get(final_url, { headers: HEADERS });
};

export function teardown() {
  var teardown_url = `${BASE_URL}/api/mssql/MssqlBook/${BODY_TEST.id}`;
  //http.del(teardown_url, { headers: HEADERS });
};

export function handleSummary(data) {
  console.log('Preparing the end-of-test summary...');

  return {
    'update-book-mssql-single.json': JSON.stringify(data)
  };
};