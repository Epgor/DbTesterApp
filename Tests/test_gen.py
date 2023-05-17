#cruds = ['create']
cruds = ['create', 'delete', 'update', 'read']
bases = ['redis', 'mongo', 'mssql']
models = ['book', 'worker', 'organization', 'library', 'number', 'point', 'vector']
quants = ['single', 'many']
options = """

export let options = {
  discardResponseBodies: true,
  scenarios: {
    scenario: simple_scenario,
  },
};
"""


def params_part(model="book"):
    base_imports = """import http from "k6/http";
import { sleep, group } from "k6";
import { simple_scenario } from "./../scenarios.js";
"""
    return base_imports+'import { BODY, BASE_URL, HEADERS }'+f' from "./../{model}_request_params.js";'

def function_part(database="mongo", full_model="MongoBook", method="post", quant=""):
    begin = """
export default function () {"""
    quantity = f'/{quant}' if quant == "many" else ""
    url = """
    var final_url = `${BASE_URL}"""+f"/api/{database}/{full_model}{quantity}`;"

    end = f"""
    http.{method}(final_url, JSON.stringify(BODY), """+"""{ headers: HEADERS });
}
    """
    return begin + url + end



def fill_scripts():
    for crud in cruds:
        for model in models:
            for base in bases:
                for quant in quants:
                    file_content = params_part(model)+options+function_part(base, base.capitalize()+model.capitalize(), crud, quant)
                    with open(f'scripts/{crud}/{base}/{crud}_{base}_{model}_{quant}.js', 'w') as file:
                        file.write(file_content)


fill_scripts()
