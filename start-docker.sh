docker build -t backend-image ./backend/
docker run --name backend-app -d -p 8080:8080 backend-image

docker build -t frontend-image ./frontend/
docker run --name frontend-app -d -p 80:80 --link backend-app frontend-image
