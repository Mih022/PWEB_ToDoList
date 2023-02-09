# PWEB_ToDoList
ToDo lista za kolegij Programiranje za web


Autor - Mihael Ladić

<br/>

Podatci u bazi se generiraju ako je baza prazna.

## Pražnjenje baze
- izbrisati bazu - pobrisati sve sqlite fileove
    - database.sqlite
    - database.sqlite-wal
    - database.sqlite-shm
- stvoriti novu bazu
    - u Package Manager Console pokrenuti naredbu Update-database (ili, ako to ne radi, 'EntityFrameworkCore\Update-Database)

## Ostale napomene
- u ASP.NET-u ne postoji routes datoteka
    - rute su ili implicirane ili 
    - definirane neposredno iznad metode u kontroleru (unutar uglatih zagrada)
- klasa za generiranje podataka - DataGenerator
- fakeri za klasu su definirani u datoteci od klase
    - osim za PersonalData, koji se generira zajedno sa UserDatom
- Za pokretanje u Visual Studiu potreban je Workload ASP.NET and web development
- u slučaju bilo kakvih pitanja, dostupan sam na uniri mailu