### Start application
#### In Docker
```bash

dotnet compose up
```
---
#### Locally
```bash

docker compose up db -d
dotnet run --project=./Up.Api/Up.Api.csproj
```
and
```bash

dotnet run --project=./Up.Client/Up.Client.csproj
```
---
P.S. Search has an autocomplete feature, although, sadly, 
it didn't work for me in all browsers.