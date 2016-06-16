IP serwera: 52.28.249.181

URL: [https://tapfinderapp.tk](https://tapfinderapp.tk)

### Baza
Stworzenie LocalDb:
```
sqllocaldb create pubapp
sqllocaldb start pubapp
sqlcmd -S "(localdb)\pubapp" -Q "create database pubapp"
```

### Migracje
Polecenia w Package Manager Console:
```
new-migration [Name]
```
Uruchomienie migracji do LocalDb:
```
start-migrations
```
lub lepiej z cmd (builduje i uruchamia testy wczesniej)
```
./build.cmd migrate
```

## License
```
Copyright 2016 Marcin Chudy, Grzegorz Czarnocki

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
```
