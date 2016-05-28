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
