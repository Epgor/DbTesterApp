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

export default function () {
  //var delete_url = `${BASE_URL}/api/mongo/MongoOrganization/testdelete`;
  var delete_url=`${BASE_URL}/api/mongo/MongoOrganization/generate/4`;
  http.get(delete_url, { headers: HEADERS });
};
    
export function handleSummary(data) {
  console.log('Preparing the end-of-test summary...');

  return {
    'delete-org-mongo-single.json': JSON.stringify(data)
  };
};
    