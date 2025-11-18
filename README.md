# 📘 KlasseAuto.Blazor

**KlasseAuto.Blazor** ist ein *Lern- und Schulprojekt*, das ein bestehendes C#-Klassenprojekt in eine moderne  
**Blazor WebAssembly Web-App** überträgt.

Die Anwendung ermöglicht das Erfassen, Speichern, Anzeigen und Sortieren von:

- Fahrer-Daten  
- Kunden-Daten  
- Fahrzeug-Daten  
- Wetterdaten (modernisiert & sortierbar)

Alle Daten laufen vollständig **clientseitig** im Browser per WebAssembly.

---

## 🚗 Funktionen

### 🔹 Fahrzeugverwaltung
- Fahrer eingeben (Vorname, Nachname, Führerschein vorhanden)
- Kunde eingeben (Vorname, Nachname)
- Auto eingeben (Marke, Besitzer)
- Mehrere Fahrzeuge hinzufügen
- Fahrzeuge anzeigen
- Fahrzeuge sortieren (Name, Besitzer, Marke usw.)

### 🔹 Wetterseite (erneuert)
- Modernisierte Weather-Seite
- Aktualisieren-Button
- Sortierbare Tabellen (Datum, °C, °F, Summary)

### 🔹 Allgemein
- Moderne Benutzeroberfläche (Blazor / Razor Components)
- Läuft komplett im Browser (WebAssembly)
- Keine Backend-Server nötig

---

## 📁 Projektstruktur

```plaintext
KlasseAuto.Blazor/
│
├── Models/
│   ├── Person.cs
│   ├── Fahrer.cs
│   ├── Kunde.cs
│   ├── Auto.cs
│   └── ViewModel.cs
│
├── Pages/
│   ├── Fahrzeug.razor          → Fahrzeug-Eingabe, Liste & Sortierung
│   ├── Weather.razor           → Neue Wetterseite mit Sortierung
│   ├── Index.razor
│   └── Counter.razor (falls Standard)
│
├── Shared/
│   ├── MainLayout.razor
│   └── NavMenu.razor
│
├── wwwroot/
│   ├── css/
│   ├── favicon.ico
│   ├── index.html              → wichtig für GitHub Pages (<base href="...">)
│   └── appsettings.json (wenn vorhanden)
│
├── App.razor                   → Routing
├── Program.cs                  → Blazor-Konfiguration
├── KlasseAuto.Blazor.csproj    → Projekt-Datei
└── README.md                   → Projektdokumentation


---

## ▶️ Projekt starten

### 🔧 Mit .NET CLI

```bash
dotnet restore
dotnet build
dotnet run
