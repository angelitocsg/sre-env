# .NET Web API + Prometheus + Grafana

## Prerequisites

- Docker Desktop

## Access links

|             |                               |
| ----------- | ----------------------------- |
| Application | http://localhost:5000/swagger |
| Prometheus  | http://localhost:9090         |
| Grafana     | http://localhost:9099         |

### Grafana

    User: admin
    Pass: grafana

    Import dashboard: 10427

## K6 Load test

https://k6.io/

### Run

```
cd app/MyApi.LoadTest
k6 run script.js
```
