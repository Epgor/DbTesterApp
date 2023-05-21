. ./../variables.ps1


#Redis
$env:K6_INFLUXDB_BUCKET="d-org-redis-01"
./../k6 run -o $k6_output ./../scripts/delete/redis/delete_redis_organization_single.js

Start-Sleep -Seconds $timeout;

#MongoDB
$env:K6_INFLUXDB_BUCKET="d-org-mongo-01"
./../k6 run -o $k6_output ./../scripts/delete/mongo/delete_mongo_organization_single.js

Start-Sleep -Seconds $timeout;

#MSSQL
$env:K6_INFLUXDB_BUCKET="d-org-mssql-01"
./../k6 run -o $k6_output ./../scripts/delete/mssql/delete_mssql_organization_single.js

Start-Sleep -Seconds $timeout;