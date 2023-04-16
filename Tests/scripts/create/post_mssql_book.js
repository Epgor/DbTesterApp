import http from "k6/http";
import { sleep, group } from "k6";
import { simple_scenario } from "./scenarios.js";
import { BODY, BASE_URL, HEADERS } from "./request_params.js";

export let options = {
  discardResponseBodies: true,
  scenarios: {
    simple_mssql: simple_scenario,
  },
};

export default function () {
    var final_url = `${BASE_URL}/api/mssql/SqlBook`;

    http.post(final_url, JSON.stringify(BODY), { headers: HEADERS });
}
