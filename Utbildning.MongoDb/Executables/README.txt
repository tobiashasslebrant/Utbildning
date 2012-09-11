mongod.exe
=========
Startar en mongoserver, startas från en commandoprompt.
Om man startart utan parameters så startar den en lokal instans.
Default så måste man ha en katalog som heter "C:/data/db/". Detta går dock att överstyra med parameters.

Alla dokument sparas som bson (serialiserad json)

mongo.exe
=========
Är en klient som kopplar upp sig mot en mongoserver, startas från en commandoprompt.
Om man startar utan parameters så går den mot en lokal instans.

Klienten använder sig av javascript som querymotor, och man har då tillgång till de flesta javascript funktioner.
Alla dokument är formaterade som json.

Tänk på att den är case-sensitive, även vid tex "use Vardguiden"


Exempel på hur man kan använda klienten.

________ navigering och visa information_______
>show dbs	
	=> listar alla databaser
>db
	=> skriver ut aktuell databas
>use vardguiden	
	=> ändrar aktuell databas till vardguiden. Om databasen inte finns kommer den att skapa den.
>show collections
	=> listar alla kollektioner (typ tabeller) i aktuell databas
>db.Guide.find
	=> visar information om funktionen "find" på kollektionen "Guide" i aktuell databas.

________ olika varianter på select_______
>db.Guide.find()
	=> listar alla dokument som json i kollektionen "Guide".
>db.Guide.find()[0]
	=> listar första dokumentet som json i kollektionen "Guide".
>db.Guide.find()[0].ChangedBy
	=> visar egenskapen "ChangedBy" på första dokumentet i kollektionen "Guide".
>db.Guide.find().forEach(function(f){print(f.CreatedBy);}) 
	=> visar egenskapen "ChangedBy" på alla dokument i kollektionen "Guide".

________ olika varianter på where_______
>db.Guide.find({"Status":1})
	=> listar alla dokument som har status == 1
>db.Guide.find({"Status":{$lt :2}})
	=> listar alla dokument som har status < 2
>db.Guide.find({"Status":{$gt :2}})
	=> listar alla dokument som har status > 2
>db.Guide.find({"Status":{$ne :2}})
	=> listar alla dokument som har status != 2




