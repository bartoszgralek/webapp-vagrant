docker build -t backend-image ./backend/
docker run --name backend-app -d -p 8081:8080 backend-image 

docker build -t frontend-image ./frontend/
docker run --name frontend-app -d -p 8080:80 frontend-image 
