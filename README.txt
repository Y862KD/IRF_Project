Termelő vállalatunk vevői megrendelések teljesítésének nyomonkövetésére vállalatírányitási rendszerünket összekötötte a kiszállításokat végző fuvarozócég rendszerével, mely visszacsatolást tud küldeni a kézbesítések állapotáról.

Rendszerváltoztatások miatt megszakadt a kapcsolat, melynek javítása a tervezettnél hosszabb időt vesz igénybe. A központi ellátás lánc osztály feladata így megnehezedett, hogy egységes képet kapjon a megrendelések és kiszállítások állapotáról, befolyásolva a számlázást.

Lehetséges CSV fájlokba kiexportálni az adatokat, így az ellátási lánc osztály egy egyszerű alkalmazást igényelt mely segít egyeztetni az adatokat. A fájlok tartalmazzák az alábbi adatokat.

warehouse.csv (Vevői kód,Megrendelésszám, Fuvarlevél, Felvétel napja)
forwarder.csv (Fuvarlevél, Státusz, Kiszállítási napja)

A fuvarozó a futárok visszajelzése alapján akár naponta többször is tud visszajelzést küldeni. Ezért lehetővé kell tenni az automatikus frissítést bizonyos időközönként a fájlok forrásmappájából.

A pénzügyi osztály igazolást kér a számlázható tételekről, így Excel generálást is lehetővé kell tenni.

-------

Adatok importálása
A) Olvasás CSV fájlból

Adatfeldolgozás
C) Adott tulajdonságú elemek törlése egy listából

Adatok exportálása / megjelenítése
B) Formázott Excel létrehozása a rendelkezésre álló adatokból

Általános elemek
D) Timer használata