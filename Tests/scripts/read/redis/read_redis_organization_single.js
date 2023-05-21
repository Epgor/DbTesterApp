import http from "k6/http";
import { sleep, group } from "k6";
import { simple_scenario } from "./../scenarios.js";
import { BODY, BASE_URL, HEADERS } from "../../create/organization_request_params.js";

export let options = {
  discardResponseBodies: true,
  scenarios: {
    scenario: simple_scenario,
  },
};

export function setup() {
  var setup_url = `${BASE_URL}/api/redis/RedisOrganization/testobject`;
  http.post(setup_url, JSON.stringify(BODY), { headers: HEADERS });
};

export default function () {
  var final_url = `${BASE_URL}/api/redis/RedisOrganization/testobject`;
  http.get(final_url, { headers: HEADERS });
};

export function handleSummary(data) {
  console.log('Preparing the end-of-test summary...');

  return {
    'read-org-redis-single.json': JSON.stringify(data)
  };
};