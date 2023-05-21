. ./../variables.ps1


#Redis
$env:K6_INFLUXDB_BUCKET="d-book-redis-01"
./../k6 run -o $k6_output ./../scripts/delete/redis/delete_redis_book_single.js

Start-Sleep -Seconds $timeout;

#MongoDB
$env:K6_INFLUXDB_BUCKET="d-book-mongo-01"
./../k6 run -o $k6_output ./../scripts/delete/mongo/delete_mongo_book_single.js

Start-Sleep -Seconds $timeout;

#MSSQL
$env:K6_INFLUXDB_BUCKET="d-book-mssql-01"
./../k6 run -o $k6_output ./../scripts/delete/mssql/delete_mssql_book_single.js

Start-Sleep -Seconds $timeout;