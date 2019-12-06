# Serwis webowy uruchomiony w dockerze.

## Uruchomienie serwisu
Serwis składa się z dwóch warstw fronendu i backendu.

Aby go uruchomić należy nadać uprawnienia do uruchomienia dla pliku `start-docker.sh` przez polecenie `chmod +x start-docker.sh`.

Następnie należy uruchomić skrypt z uprawnieniami sudo przez polecenie `sudo ./start-docker.sh`.

Spowoduje to:
1. Zbudowanie obrazu backend-image z pliku `/backend/Dockerfile`,
2. Uruchomienie kontenera o nazwie backend-app z obrazu backend-image na porcie 8080,
3. Zbudowanie obrazu frontend-image z pliku `/frontend/Dockerfile`,
4. Uruchomienie kontenera o nazwie frontend-app z obraz frontend-image na porcie 80 podlinkowanego do kontenera backend-app.

Po zakończeniu tych operacji aplikacja jest dostępna pod adresem `localhost:80`.

## Opis serwisu
Warstwa frontendu jest to aplikacja angularowa działająca na serwerze nginx
Warstwa backendu jest to api napisane w javie z wykorzystaniem spring boota. 
