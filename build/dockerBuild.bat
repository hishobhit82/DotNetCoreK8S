::Up one directory to make the working directory where dockerfile is present
cd..

::execute the docker build command 
docker build -t dockerregistry/aspnetcorePersonsWebApi:1.0 .

:: for azure container registry
az acr build --registry $ACR_NAME --image dotnetcorewebapi:v1.0 --platform windows --file Dockerfile .

:: after successfully building the image you can run the container with the below command, 
:: note that the port mapping has to be unique on the host 
:: i.e. if the port is already used on the host we cant use it else it will throw the error and container wont start
docker run --name personsWebApi1 -d -p 8999:8080 aspnetcorePersonsWebApi:1.0

:: this command will give you the ipaddress 
:: contrary to .net framework the aspnet core on linux does not require ip addres of the container.
:: localhost would do with the host port assigned in the docker run command above.

:: the url to try the endpoints
http://localhost:8999/swagger, http://localhost:8999/Person/Ping, http://localhost:8999/Person/GetPersons/5