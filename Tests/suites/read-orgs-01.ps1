. ./../variables.ps1

#Redis
$env:K6_INFLUXDB_BUCKET="r-org-redis-01"
./../k6 run -o $k6_output ./../scripts/read/redis/read_redis_organization_single.js

Start-Sleep -Seconds $timeout;

#MongoDB
$env:K6_INFLUXDB_BUCKET="r-org-mongo-01"
./../k6 run -o $k6_output ./../scripts/read/mongo/read_mongo_organization_single.js

Start-Sleep -Seconds $timeout;

#MSSQL
$env:K6_INFLUXDB_BUCKET="r-org-mssql-01"
./../k6 run -o $k6_output ./../scripts/read/mssql/read_mssql_organization_single.js

Start-Sleep -Seconds $timeout;