import sys
import json

input_file = sys.argv[1]
#input_file = 'suites/create-book-redis-single.json'
file_json = {}

with open(input_file, 'r') as file:
    file_json = json.loads(file.read())

vus = file_json["metrics"]["vus"]["values"]

print("VUS:")
print("Value", vus["value"])
print("Min", vus["min"])
print("Max", vus["max"])
print("-------------------")

iterations = file_json["metrics"]["http_reqs"]["values"]["count"]
dropped = file_json["metrics"]["dropped_iterations"]["values"]["count"]
#rate = file_json["metrics"]["dropped_iterations"]["values"]["rate"]
#{round(rate, 3)} &
req_dur = file_json["metrics"]["http_req_duration"]["values"]

print("http_req_duration in latex table row:")
print("dropped", "http_reqs","rate" ,"avg", "min", "med", "p(90)", "p(95)", "max")
print(f'{dropped} & {iterations} & {round(req_dur["avg"], 2)} & {round(req_dur["min"], 2)} & {round(req_dur["med"], 2)} & \
{round(req_dur["p(90)"], 2)} & {round(req_dur["p(95)"], 2)} & {round(req_dur["max"], 2)} \\\\')