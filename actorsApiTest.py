import requests, json, datetime

headers = {"content-type" : "application/json"}
url = "http://localhost:63273/api/actors"

print("####### (1) Get All Actors ###########")
r = requests.get(url, headers=headers)
print(r.status_code)
print(r.text)

print("####### (2) Get Actor by Id ###########")
r = requests.get(url+"/101", headers=headers)
print(r.status_code)
print(r.headers)
print(r.json())

print("####### (3) Add Actor  ###########")
actor = {"firstname": "hello", "lastname" : "world", "lastupdate" : "2018-12-10T19:53:28+11:00"}
r = requests.post(url, headers=headers, data = json.dumps(actor))
print(r.status_code)
print(r.headers)
print(r.text)

print("####### Checking the actor ###########")
r = requests.get(url+"/201", headers=headers)
print(r.status_code)
print(r.headers)
print(r.text)

print("####### (4) Update Actor by id ###########")
actor = {"actorid":202,"firstname": "New", "lastname" : "Method", "lastupdate" :  "2020-12-10T19:53:28+11:00"}
r = requests.put(url+"/202", headers=headers, data = json.dumps(actor))
print(r.status_code)
print(r.headers)
print(r.text)

print("####### Checking the actor ###########")
r = requests.get(url+"/202", headers=headers)
print(r.status_code)
print(r.headers)
print(r.json())

print("####### (5) Delete Actor by id ###########")
r = requests.delete(url+"/210", headers=headers)
print(r.status_code)
print(r.headers)
print(r.text)

print("####### Checking the actor ###########")
r = requests.get(url+"/210", headers=headers)
print(r.status_code)
print(r.headers)
print(r.text)
