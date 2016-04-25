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