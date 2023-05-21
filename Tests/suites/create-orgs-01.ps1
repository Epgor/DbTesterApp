. ./../variables.ps1

#CleanUp
node ./../scripts/clean_organizations.js

#Redis
$env:K6_INFLUXDB_BUCKET="c-org-redis-01"
./../k6 run -o $k6_output ./../scripts/create/redis/create_redis_organization_single.js

Start-Sleep -Seconds $timeout;

#MongoDB
$env:K6_INFLUXDB_BUCKET="c-org-mongo-01"
./../k6 run -o $k6_output ./../scripts/create/mongo/create_mongo_organization_single.js

Start-Sleep -Seconds $timeout;

#MSSQL
$env:K6_INFLUXDB_BUCKET="c-org-mssql-01"
./../k6 run -o $k6_output ./../scripts/create/mssql/create_mssql_organization_single.js

Start-Sleep -Seconds $timeout;