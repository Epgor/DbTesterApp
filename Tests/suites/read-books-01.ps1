. ./../variables.ps1

#Redis
$env:K6_INFLUXDB_BUCKET="r-book-redis-01"
./../k6 run -o $k6_output ./../scripts/read/redis/read_redis_book_single.js

Start-Sleep -Seconds $timeout;

#MongoDB
$env:K6_INFLUXDB_BUCKET="r-book-mongo-01"
./../k6 run -o $k6_output ./../scripts/read/mongo/read_mongo_book_single.js

Start-Sleep -Seconds $timeout;

#MSSQL
$env:K6_INFLUXDB_BUCKET="r-book-mssql-01"
./../k6 run -o $k6_output ./../scripts/read/mssql/read_mssql_book_single.js

Start-Sleep -Seconds $timeout;