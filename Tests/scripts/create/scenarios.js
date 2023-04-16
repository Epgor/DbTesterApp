export let simple_scenario = {
        executor: "ramping-arrival-rate",
        startRate: 30,
        timeUnit: '1m',
        preAllocatedVUs: 30,
        maxVUs: 250,
        stages: [
          { duration: '5s', target: 30 },
          { duration: '5s', target: 1000 },    
          { duration: '20s', target: 10000 },
          { duration: '40s', target: 100000 },
          { duration: '5s', target: 100 },
        ],
        gracefulStop: "1s",
      }
