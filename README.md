# CRMCallCenter

System CRM dla call center z obsługą zespołów sprzedażowych w różnych lokalizacjach (fizycznych i wirtualnych). Aplikacja umożliwia zarządzanie użytkownikami, zespołami, klientami, transakcjami oraz połączeniami telefonicznymi.

## Technologie

- **.NET 8** (ASP.NET Core Web API)
- **Entity Framework Core** (ORM)
- **PostgreSQL** (baza danych)
- **JWT (JSON Web Tokens)** – autoryzacja i uwierzytelnianie
- **BCrypt** – bezpieczne hashowanie haseł
- **Swagger (Swashbuckle)** – dokumentacja API
- **Fork** + **GitHub** – kontrola wersji

## Struktura projektu

CRMCallCenter/
│
├── Controllers/ # Endpointy API (Auth, Klienci, Zespoły itd.)
├── Data/
│ ├── ApplicationDbContext.cs
│ └── ApplicationDbContextFactory.cs
│
├── DTO/ # Obiekty typu Request / Response
│ ├── Uzytkownicy/
│ ├── Zespoly/
│ └── Klienci/
│
├── Models/ # Modele encji EF (Uzytkownik, Klient, Transakcja itd.)
│
├── Services/ # Warstwa serwisowa z logiką biznesową
│
├── Interfaces/ # Interfejsy do warstw serwisowych
│
├── Program.cs # Konfiguracja aplikacji (Swagger, JWT, DI, DbContext)
├── appsettings.json # Ustawienia aplikacji (połączenie z DB, JWT itd.)
└── .gitignore # Plik ignorujący niechciane pliki w repo


## Role użytkowników

- `Sprzedawca call center` – dostęp tylko do swoich klientów
- `Sprzedawca terenowy` – dostęp do klientów przypisanych do niego
- `Manager` – dostęp do klientów przypisanych do jego zespołów
- `Manager regionalny` – dostęp do wszystkich klientów managerów z danego regionu
- `Manager krajowy` – dostęp do wszystkich danych

## Główne funkcje

- ✅ Rejestracja i logowanie użytkowników
- ✅ Obsługa JWT z rolami użytkowników
- ✅ Dodawanie i zarządzanie zespołami
- ✅ Przypisywanie pracowników do zespołów
- ✅ Obsługa klientów i transakcji
- ✅ Historia połączeń telefonicznych
- ✅ Wsparcie dla różnych lokalizacji (biura, regiony wirtualne)

## Baza danych

- PostgreSQL z pełną obsługą migracji EF Core
- Relacje:
  - Użytkownik → Rola
  - Użytkownik → Zespół
  - Klient → Zespół
  - Transakcja → Klient + Użytkownik
  - Połączenie → Klient + Użytkownik
  - Użytkownik → Przełożony (self-FK)

## Jak uruchomić projekt

1. Sklonuj repo:
   git clone https://github.com/twoj-login/CRMCallCenter.git
   cd CRMCallCenter

2. Skonfiguruj appsettings.json:
	Połączenie do PostgreSQL
	Klucz JWT (min. 128 bitów!)

3. Zainstaluj paczki:	
	dotnet restore

4. Zastosuj migracje:
	dotnet ef database update

5. Uruchom aplikację:
	dotnet run

6. Przejdź do:
	https://localhost:7012/swagger


## Bezpieczeństwo
- Hasła są przechowywane z użyciem BCrypt
- Uwierzytelnianie i autoryzacja oparte o JWT
- Role są nadawane przez administratora lub system

## Planowane funkcje (Roadmap)
 - Frontend SPA (np. React/Angular/Vue)
 - System notyfikacji i statusów
 - Zaawansowane filtrowanie i eksport CSV
 - Dashboard managera
 - Raporty miesięczne i wykresy

## Autor
Paweł Markieta
Projekt tworzony w ramach rozwoju systemu CRM dla zespołów sprzedażowych.