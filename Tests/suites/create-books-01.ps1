. ./../variables.ps1

#CleanUp
node ./../scripts/clean_books.js

#Redis
$env:K6_INFLUXDB_BUCKET="c-book-redis-01"
./../k6 run -o $k6_output ./../scripts/create/redis/create_redis_book_single.js

Start-Sleep -Seconds $timeout;

#MongoDB
$env:K6_INFLUXDB_BUCKET="c-book-mongo-01"
./../k6 run -o $k6_output ./../scripts/create/mongo/create_mongo_book_single.js

Start-Sleep -Seconds $timeout;

#MSSQL
$env:K6_INFLUXDB_BUCKET="c-book-mssql-01"
./../k6 run -o $k6_output ./../scripts/create/mssql/create_mssql_book_single.js

Start-Sleep -Seconds $timeout;