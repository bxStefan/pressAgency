
# netPress

Monolithic .NET Core based WebAPI for press agency




[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)


## Features

- Scalar API Reference
- Docker support 
- Basic user auth via email
- Pessimistick locking system for safe post moderation


## Run Locally

Clone the project

```bash
  git clone https://github.com/bxStefan/pressAgency.git
```

Go to the project directory

```bash
  cd pressAgency
```

Add appsettings.json file to the project

```bash
  pressAgency/src/appsettings.json
```

Spin docker compose in project root

```bash
  docker compose up --build -d
```

Visit API reference

```bash
  http:localhost:5000/scalar
```

> Note: If you whish to run project locally, host for db is your local machine 127.0.0.1
## API Reference

Now when we have project up and running, we can consume APIs

#### Get all items

```http
  GET /api/v1/authors/authorId
```

| Parameter | Type     | Description                | Example |
| :-------- | :------- | :------------------------- | :------ |
| `X-User-Email` | `string` | **Required**. Your API key | john.doe@netpress.com |



## Authors

- [@bxStefan](https://github.com/bxStefan)

