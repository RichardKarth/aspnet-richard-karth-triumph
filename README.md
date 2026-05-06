# CoreFitness Club

Projektet är en tränings/hemsida där användare kan:

- Skapa konto
- Logga in
- Hantera medlemskap
- Uppdatera sin profil
- Se information om gym och träning

## Tekniker

Projektet är byggt med:

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- HTML & CSS
- xUnit
- Moq

## Starta projektet lokalt

### 1. Klona projektet

```bash
git clone https://github.com/RichardKarth/aspnet-richard-karth-triumph.git
```

### 2. Öppna solutionen

Öppna projektet i Visual Studio.

### 3. Uppdatera databasen

Öppna Package Manager Console och kör:

```powershell
Update-Database
```

### 4. Starta projektet

Tryck på:

```txt
CTRL + F5
```

eller kör:

```bash
dotnet run
```

## Tester

Projektet innehåller enhetstester med xUnit och Moq.

Kör tester med:

```bash
dotnet test
```
