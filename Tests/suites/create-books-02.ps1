. ./../variables.ps1

#CleanUp
node ./scripts/clean_books.js

#Redis
$env:K6_INFLUXDB_BUCKET="c-book-redis-01"
./../k6 run -o $k6_output ./scripts/create/mongo/post_redis_book_many.js

Start-Sleep -Seconds $timeout;

#MongoDB
$env:K6_INFLUXDB_BUCKET="c-book-mongodb-02"
./../k6 run -o $k6_output ./scripts/create/mongo/post_mongodb_book_many.js

Start-Sleep -Seconds $timeout;

#MSSQL
$env:K6_INFLUXDB_BUCKET="c-book-mssql-01"
./../k6 run -o $k6_output ./scripts/create/mongo/post_mssql_book_many.js