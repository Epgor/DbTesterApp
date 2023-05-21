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
  //var delete_url = `${BASE_URL}/api/mssql/MssqlOrganization/testdelete`;
  var delete_url=`${BASE_URL}/api/mssql/MssqlOrganization/generate/3`;
  http.get(delete_url, { headers: HEADERS });
};

export function handleSummary(data) {
  console.log('Preparing the end-of-test summary...');

  return {
    'delete-org-mssql-single.json': JSON.stringify(data), // Transform summary and save it as a JUnit XML...
  };
};
    
