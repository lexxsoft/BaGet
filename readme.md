# BaGet :baguette_bread:

> This is a fork of https://github.com/loic-sharma/BaGet.

This fork retargets the runtime from `netcoreapp3.1` to `net10.0` and was
primarily created to build `linux/amd64` and `linux/arm64` Docker images (the
original repository did not publish an `arm64` variant).

Docker Hub image: https://hub.docker.com/r/lexxsoft/baget

## Docker Image (docker-compose)

Create a `docker-compose.yml`:

```yaml
services:
  baget:
    image: lexxsoft/baget:latest
    container_name: baget
    restart: unless-stopped
    environment:
      - TZ=Europe/Vilnius
      - ApiKey=your-push-key-change-me
      - Storage__Type=FileSystem
      - Storage__Path=/var/baget/packages
      - Database__Type=Sqlite
      - Database__ConnectionString=Data Source=/var/baget/baget.db
    volumes:
      - ./data:/var/baget
    ports:
      - "5555:8080"
```

Make sure to change the `ApiKey` value to a secure key.

Then start the service:

```bash
docker compose up -d
```

Browse `http://localhost:5555/`.

## Original documentation

Visit https://github.com/loic-sharma/BaGet for the original documentation.