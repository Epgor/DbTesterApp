export let simple_scenario = {
        executor: "ramping-arrival-rate",
        //startRate: 30,
        timeUnit: '1m',
        preAllocatedVUs: 10,
        maxVUs: 500,
        stages: [
          { duration: '5s', target: 30 },
          { duration: '5s', target: 1000 },    
          { duration: '20s', target: 10000 },
          { duration: '40s', target: 100000 },
          { duration: '5s', target: 100 },
        ],
        gracefulStop: "1s",
      }
//spike
export let simple_scenario_2 = {
        executor: "ramping-arrival-rate",
        //startRate: 30,
        timeUnit: '1m',
        preAllocatedVUs: 10,
        maxVUs: 3000,
        stages: [
          { duration: '10s', target: 30 },
          { duration: '40s', target: 100000 },
          { duration: '10s', target: 100 },    
          { duration: '40s', target: 300000 },
          { duration: '10s', target: 100 },
          { duration: '40s', target: 600000 },
          { duration: '10s', target: 100 },
          { duration: '40s', target: 900000 },
          { duration: '10s', target: 100 },
          { duration: '40s', target: 1800000 },
          { duration: '10s', target: 100 },
        ],
        gracefulStop: "1s",
      }
//load     
export let simple_scenario_3 = {
        executor: "ramping-arrival-rate",
        //startRate: 10,
        timeUnit: '1m',
        preAllocatedVUs: 10,
        maxVUs: 2500,
        stages: [
          { duration: '30s', target: 300 },
          { duration: '5m', target: 300000 },    
          { duration: '30s', target: 300 }
        ],
        gracefulStop: "1s",
      }
//stress - break it
export let simple_scenario_4 = {
        executor: "ramping-arrival-rate",
        //startRate: 30,
        timeUnit: '1m',
        preAllocatedVUs: 10,
        maxVUs: 10000,
        stages: [
          { duration: '5s', target: 30 },   
          { duration: '20s', target: 10000 },
          { duration: '10m', target: 100000000 },
        ],
        gracefulStop: "1s",
      }