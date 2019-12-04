docker build -t frontend-image ./frontend/
docker run --name frontend-app -d -p 8080:80 frontend-image 
