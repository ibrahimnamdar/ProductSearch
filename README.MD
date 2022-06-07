# Product Search Case

## How to Run

For backend project: in root directory, run:

```
docker compose build
```

Then run:

```
docker compose up
```

> **Note**: If backend service starts before the db, 
> you may need to run 'docker compose up' again. Not enough time to add health checks.

For frontend project, in root directory:

1.
```
cd ./product-search
```

2.
```
yarn install
```

3.
```
yarn start
```

Frontend project url: http://localhost:3000

Backend project url: http://localhost:5000/swagger