import sys
import json

input_file = sys.argv[1]
output_file = sys.argv[2]
print(input_file, '-', output_file)

temp_json = {}

with open(input_file, 'r') as file:
    temp_json = json.loads(file.read())

with open(output_file, 'w') as file:
    file.writelines('export const BODY_JSON = [\n')
    for index, item in enumerate(temp_json):
        file.writelines('{\n')

        for key, value in enumerate(item.items()):
            file.writelines(f'   {value[0]}: "{value[1]}"')
            if key != len(item.items()) - 1:
                file.writelines(',\n')
            else:
                file.writelines('\n')

        file.writelines('}')

        if index != len(temp_json) - 1:
            file.writelines(',\n')
        else:
            file.writelines('\n')
    file.writelines(']\n')