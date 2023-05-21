. ./../variables.ps1

#Redis
$env:K6_INFLUXDB_BUCKET="u-org-redis-01"
./../k6 run -o $k6_output ./../scripts/update/redis/update_redis_organization_single.js

Start-Sleep -Seconds $timeout;

#MongoDB
$env:K6_INFLUXDB_BUCKET="u-org-mongo-01"
./../k6 run -o $k6_output ./../scripts/update/mongo/update_mongo_organization_single.js

Start-Sleep -Seconds $timeout;

#MSSQL
$env:K6_INFLUXDB_BUCKET="u-org-mssql-01"
./../k6 run -o $k6_output ./../scripts/update/mssql/update_mssql_organization_single.js

Start-Sleep -Seconds $timeout;

