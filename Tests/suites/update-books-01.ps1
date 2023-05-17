. ./../variables.ps1

#Redis
$env:K6_INFLUXDB_BUCKET="u-book-redis-01"
./../k6 run -o $k6_output ./../scripts/update/redis/update_redis_book_single.js

Start-Sleep -Seconds $timeout;

#MongoDB
$env:K6_INFLUXDB_BUCKET="u-book-mongo-01"
./../k6 run -o $k6_output ./../scripts/update/mongo/update_mongo_book_single.js

Start-Sleep -Seconds $timeout;

#MSSQL
$env:K6_INFLUXDB_BUCKET="u-book-mssql-01"
./../k6 run -o $k6_output ./../scripts/update/mssql/update_mssql_book_single.js



