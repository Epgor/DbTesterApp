. ./../variables.ps1
<#
#Redis
$env:K6_INFLUXDB_BUCKET="r-book-redis-01"
./../k6 run -o $k6_output ./../scripts/read/redis/read_redis_book_single.js

Start-Sleep -Seconds $timeout;

#Redis
$env:K6_INFLUXDB_BUCKET="r-book-redis-01"
./../k6 run -o $k6_output ./../scripts/read/redis/read_redis_book_single_2.js

Start-Sleep -Seconds $timeout;

#Redis
$env:K6_INFLUXDB_BUCKET="r-book-redis-01"
./../k6 run -o $k6_output ./../scripts/read/redis/read_redis_book_single_3.js

Start-Sleep -Seconds $timeout;
#>
#Redis
$env:K6_INFLUXDB_BUCKET="r-book-redis-01"
./../k6 run -o $k6_output ./../scripts/read/redis/read_redis_book_single_4.js