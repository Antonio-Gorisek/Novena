# Novena

**Novena** je testni zadatak napravljen prije nekoliko godina za privremeni posao. Projekt je izrađen u vrlo kratkom roku (2 dana) i predstavlja osnovnu implementaciju audio playera i prikaza medijskih sadržaja.  
<p align="center" style="display:flex; gap:2px; justify-content:center;">
  <img src="https://github.com/user-attachments/assets/507f4696-f045-4568-9eaa-aec3abb6f7e2" width="33%" />
  <img src="https://github.com/user-attachments/assets/1e7c830e-ac4f-474d-a521-a4632929d1b3" width="32%" />
  <img src="https://github.com/user-attachments/assets/5081bf77-fd61-48fc-9641-7b91fe20158e" width="33.35%" />
</p>


## Opis projekta

- Reproducira audio zapise koji su definirani u JSON datotekama.
- Prikazuje slike povezane s temama iz JSON-a i automatski ih prebacuje.
- Sadrži jednostavan dizajn i osnovne UI funkcionalnosti.
- Svi elementi (audio, slike i tekstovi) učitavaju se preko Unity `Resources` foldera i json filea.

## Struktura projekta

- **Scripts**
  - `JsonManager.cs` – učitava podatke iz JSON datoteka i pruža metode za dohvat tema, medija i audio datoteka.
  - `AudioManager.cs` – kontrolira reprodukciju audio zapisa, UI slider i play/pause funkcionalnost.
  - `PlayPageData.cs` – prikazuje naslov i broj stranice, te rotira slike povezane s odabranom temom.
  - `LoadContent.cs` – dinamički stvara UI elemente za sve teme i dodaje listener-e na tipke.
  - `MenuManager.cs` – kontrolira navigaciju između glavne liste i stranice za prikaz sadržaja.

## Napomena

Projekt je napravljen minimalno, isključivo za demonstraciju osnovnih funkcionalnosti. Dizajn i interakcije su jednostavni kao i kod.
