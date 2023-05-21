import http from "k6/http";
import { sleep, group } from "k6";
import { simple_scenario } from "./../scenarios.js";
import { BODY, BASE_URL, HEADERS } from "./../book_request_params.js";
import { BODY_JSON } from "../books.js";

export let options = {
  discardResponseBodies: true,
  scenarios: {
    scenario: simple_scenario,
  },
};

export default function () {
    var final_url = `${BASE_URL}/api/redis/RedisBook/many/fast`;
    http.post(final_url, JSON.stringify(BODY_JSON), { headers: HEADERS });
};

export function handleSummary(data) {
  console.log('Preparing the end-of-test summary...');

  return {
    'create-book-redis-many.json': JSON.stringify(data)
  };
};