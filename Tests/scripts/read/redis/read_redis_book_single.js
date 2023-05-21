import http from "k6/http";
import { sleep, group } from "k6";
import { simple_scenario } from "./../scenarios.js";
import { BODY_TEST, BASE_URL, HEADERS } from "./../../create/book_request_params.js";


export let options = {
  discardResponseBodies: true,
  scenarios: {
    scenario: simple_scenario,
  },
};

export function setup() {
  var setup_url = `${BASE_URL}/api/redis/RedisBook/testobject`;
  http.post(setup_url, JSON.stringify(BODY_TEST), { headers: HEADERS });
};

export default function () {
  var final_url = `${BASE_URL}/api/redis/RedisBook/testobject`;
  http.get(final_url, { headers: HEADERS });
};

export function handleSummary(data) {
  console.log('Preparing the end-of-test summary...');

  return {
    'read-book-redis-single.json': JSON.stringify(data)
  };
};