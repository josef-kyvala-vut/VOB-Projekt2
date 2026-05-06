# VOB-Projekt2 - Steam slevy

Konzolová aplikace stahuje aktuální slevy her na Steamu z veřejného API (CheapShark) a dál je zpracovává.

Architektura:
Rozdělil jsem projekt do několika vrstev:
Models - GameDeal.cs: Mapuje data z JSONu.
Providers - CheapSharkProvider.cs a IDealProvider.cs: Stahují data z API. Interface umožňuje přidání dalších obchodů.
Logic - DealAnalyzer.cs: Oddělená logika pro zpracování dat.
UI - ConsoleInterface.cs: Stará se čistě o výpis do konzole.

Asynchronní zpracování:
Používám HttpClient a async/await. Stažení neblokuje hlavní vlákno a odpověď se rovnou asynchronně parsuje.

Zpracování dat:
Pomocí LINQ dělám s daty v C# další operace:
Třídění: Řadím seznam her podle hodnocení uživatelů na Steamu.
Filtrování: Vyhledávám hry s cenou 0 (100% sleva) a vypisuju je na začátek.

Výjimky a chybové stavy:
Stahování je v try-catch bloku. Pokud nastane chyba program nespadne, načte detail chyby a vypíše ho uživateli do konzole.
