# Implementacija i upotreba CQRS obrasca u .NET aplikaciji
📜 ## Sadržaj:
- [Uvod](#uvod)
- [CQRS (Command Query Responsibility Segregation) obrazac](#cqrs-command-query-responsibility-segregation-obrazac)
- [Clean Architecture](#clean-architecture)
- [MediatR biblioteka](#mediatr-biblioteka)
- [Implementacija operacija pisanja (Commands)](#implementacija-operacija-pisanja-commands)
- [Implementacija operacija čitanja (Queries)](#implementacija-operacija-čitanja-queries)
- [Integracija CQRS obrasca sa MediatR bibliotekom](#integracija-cqrs-obrasca-sa-mediatr-bibliotekom)
- [Pokretanje i demonstracija rada aplikacije](#pokretanje-i-demonstracija-rada-aplikacije)
- [Prednosti i mane CQRS pristupa](#prednosti-i-mane-cqrs-pristupa)
- [Zaključak](#zaključak)
- [Mogućnosti daljeg razvoja](#mogućnosti-daljeg-razvoja)
## 📖 Uvod 
Razvoj savremenih softverskih sistema zahteva jasno strukturisanu arhitekturu koja omogućava jednostavno održavanje, proširivost i razdvajanje odgovornosti između pojedinih delova aplikacije. Jedan od arhitektonskih obrazaca koji se često koristi u takvim sistemima je CQRS (Command Query Responsibility Segregation), čija je osnovna ideja razdvajanje operacija koje menjaju stanje sistema od operacija koje služe za čitanje podataka.

U okviru ovog projekta realizovana je .NET aplikacija za upravljanje narudžbinama sa ciljem demonstracije praktične primene CQRS obrasca. Aplikacija omogućava osnovne CRUD operacije nad entitetom narudžbine, pri čemu su operacije pisanja implementirane korišćenjem komandi, dok su operacije čitanja realizovane putem upita. Za komunikaciju između kontrolera i poslovke logike korišćena je MediatR biblioteka, čime je postignuto dodatno razdvajanje slojeva i smanjena direktna zavisnost između komponenti sistema.

Projekat je organizovan u skladu sa principima Clean Architecture, kroz jasno definisane slojeve domena, aplikacione logike, infrastrukture i API sloja. Pristup bazi podataka realizovan je korišćenjem Entity Framework Core tehnologije, uz primenu migracija za upravljanje strukturom baze. Na ovaj način obezbeđena je čista separacija poslovke logike od tehničkih detalja implementacije.

Cilj rada je da se prikaže način implementacije CQRS obrasca u .NET okruženju, kao i da se ukaže na prednosti i izazove ovakvog pristupa u razvoju aplikacija srednje složenosti. Kroz praktičan primer demonstrirano je kako se CQRS može efikasno kombinovati sa MediatR bibliotekom i principima čiste arhitekture radi izgradnje održivog i proširivog softverskog rešenja.
## 🏛️ CQRS (Command Query Responsibility Segregation) obrazac
### Šta je CQRS?
CQRS je skraćenica od Command Query Responsibility Segregation (Razdvajanje odgovornosti za komande i upite). To je softverski arhitektonski obrazac koji uvodi jasno razdvajanje između operacija pisanja (commands) i operacija čitanja (queries) podataka.

U CQRS arhitekturi, operacije pisanja i operacije čitanja se obrađuju odvojeno, koristeći različite modele optimizovane za svaku vrstu operacije. Ovakvo razdvajanje može dovesti do jednostavnijih, fleksibilnijih i skalabilnijih arhitektura, naročito u složenim sistemima u kojima se obrasci čitanja i pisanja značajno razlikuju.
### Razlika od tradicionalnog CRUD pristupa
Tradicionalni arhitektonski obrasci često koriste isti model podataka ili isti DTO (Data Transfer Object) za operacije čitanja i pisanja. Iako ovakav pristup može biti adekvatan za osnovne CRUD operacije (kreiranje, čitanje, ažuriranje i brisanje), on postaje ograničavajući kada aplikacije rastu i zahtevi postaju složeniji.

U praktičnim scenarijima često postoji razlika između struktura podataka koje se koriste za čitanje i onih koje se koriste za pisanje. Na primer, za ažuriranje podataka mogu biti potrebna dodatna svojstva koja nisu relevantna prilikom čitanja. Korišćenje jednog istog DTO-a tokom celog životnog ciklusa aplikacije može ograničiti arhitekturu sistema, osim ako se ne uvedu dodatni modeli, što može povećati složenost.

Osnovna ideja CQRS obrasca jeste omogućavanje rada sa različitim modelima podataka za različite svrhe. U praksi, to znači postojanje posebnog modela za umetanje zapisa, drugog za ažuriranje zapisa i trećeg za izvršavanje upita nad podacima. Ovakav pristup omogućava veću fleksibilnost u obradi složenih scenarija i efikasniju i precizniju obradu podataka.
## 🏗️ Clean Architecture
## 🚚 MediatR biblioteka
## 📝 Implementacija operacija pisanja (Commands)
## 🔎 Implementacija operacija čitanja (Queries)
## Integracija CQRS obrasca sa MediatR bibliotekom
## 🚀 Pokretanje i demonstracija rada aplikacije
## Prednosti i mane CQRS pristupa
### 🛠️ Problemi koje CQRS rešava
- Pojednostavljeni objekti za prenos podataka - CQRS obrazac pojednostavljuje model podataka aplikacije korišćenjem odvojenih modela za svaku vrstu operacije, čime povećava flekisbilnost i smanjuje složenost.
- Skalabilnost - Odvajanjem operacija čitanja i pisanja, CQRS omogućava lakšu skalabilnost. Moguće je nezavisno skalirati stranu za čitanje i stranu za pisanje aplikacije kako bi se efikasno obradili različiti nivoi opterećenja.
- Poboljšanje performansi - S obzirom na to da operacija čitanja učestalije od operacije pisanja, CQRS omogućava optimizaciju performansi čitanja primenom mehanizma keširanja, kao što su Redis ili MongoDB. Ovaj obrazac prirodno podržava tavke optimizacije, što doprinosti boljim ukupnim performansama sistema
- Poboljšana konkurentnost i paralelizam - Korišćenjem posebnih modela za različite tipove operacija, CRS obezbeđuje bezbedno izvršavanje paralelnih operacija uz očuvanje integriteta podataka. Ovo je naročito značajno u sistemima u kojima se veliki broj operacija izvršava istovremeno.
- Povećana bezbednost - Razdvojeni pristup koji CQRS primenjuje doprinosti boljoj kontroli pristupa podacima. Jasno definisane granice između operacije čitanja i pisanja omogućavaju implementaciju preciznijih mehanizama autorizacije, čime se unapređuje ukupna bezbednost aplikacije.
### ⚠️ Nedostaci CQRS obrasca
- Povećana složenost i obim koda – Implementacija CQRS obrasca često dovodi do povećanja složenosti sistema i količine potrebnog koda. Ovaj nedostatak proizilazi iz potrebe za održavanjem odvojenih modela i handler-a za operacije čitanja i pisanja, što može otežati razvoj, testiranje i otklanjanje grešaka.

- Veća složenost arhitekture – Uvođenje CQRS obrasca zahteva pažljivo planiranje i koordinaciju između različitih komponenti sistema, što može biti izazov u manjim timovima ili jednostavnijim projektima.

Iako CQRS povećava složenost, mnoge aplikacije opravdavaju ovaj nedostatak kroz prednosti poput nezavisne optimizacije za čitanje i pisanje, skalabilnosti i dugoročne održivosti sistema.

## Zaključak
