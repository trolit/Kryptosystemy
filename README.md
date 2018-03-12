# Kryptosystemy
## #############################################

**szyfrowanie** to po prostu metoda zapisu tekstu jawnego w taki sposób, 
by stał się on nieczytelny dla osób trzecich i jednocześnie z powrotem 
jawny po właściwej weryfikacji. ~**securelist.pl**

> We wszystkich systemach szyfrów stosuje się założenie, iż wiadomość została przechwycona. 
Zatem celem staje się uniemożliwienie lub jak największe utrudnienie czy rozciągnięcie w czasie odszyfrowania wiadomości.



**złośliwe/szkodliwe oprogramowanie** to aplikacje i skrypty mające szkodliwe lub przestępcze działanie
w stosunku do systemu komputerowego lub jego użytkownika.



> 1. Szyfr Cezara(szyfr przesuwający):

Jeden z najstarszych szyfrów. Jest zbudowany na zasadzie że, każdą literę tekstu niezaszyfrowanego zastępujemy inną przesuniętą
względem litery kodowanej o stałą liczbę pozycji w alfabecie. Na przykład dla litery „a” (kod ASCII 97) przy przesunięciu o 2,
literą kodowaną będzie „c” (kod ASCII 99) itd.... Nie gwarantuje on obecnie żadnego bezpieczeństwa. 



> 2. Szyfr Homofoniczny(inspiracja od szyfru Beale'a):

Szyfr homofoniczny to szyfr podstawieniowy, w którym każdej literze tekstu jawnego odpoiwada inny zbiór symboli
kryptogramu(homofonów). Liczba homofonów powinna być zależna od częstotliwości występowania danej litery w tekście
do zaszyfrowania. Przy każdym szyfrowaniu litery wybierany jest losowo jeden z jej homofonów. W ten sposób zostaje
spłaszczony histogram kryptogramu, a wielokrotne szyfrowanie tego samego tekstu daje za kazdym razem inny wynik.
Cechy te znaczaco utrudniaja kryptoanalizę. ~źródło: **Wikipedia**



> 3. Szyfr ROT13(szyfr przesuwający):

Szyfrowanie to polega na przesuwaniu każdej litery tekstu jawneg o 13 pozycji do przodu. Działanie zatem jest bardzo
proste co powoduje, że sam szyfr jest mało bezpieczny. Mechanizm ten jest bardzo podobny do szyfru Cezara. ROT13 
różni się jedynie wartością o jaką przesuwane są litery. ~źródło: **securelist**



> 4. Szyfr ROT47:

zamienia każdy znak ASCII z przedziału 33-126 na znak znajdujący się 47 pozycji dalej, ale nie dalej niż do 126 pozycji.
Podobnie jak ROT13 jest on samoodwracalny, tzn: **rot47(rot47(m))** ~źródło: **Wikipedia**



> 5. Szyfr ADFGVX:

używany przez Niemcy podczas I Wojny Światowej, szyfr ten jest udoskonaleniem ADFGX. Dzialanie szyfru opiera sie na nadaniu
kazdej literze pary liter A D F G V X. Tworzona jest tabela i zaszyfrowane slowo. Bez tabeli nie mozna odczytac co dane kombinacje
liter oznaczaja. Dla utrudnienia dzieli sie zaszyfrowane slowo po 6 pozycji (czyli ADFGVX itd...) ~źródło: **securelist**

> 6. Enigma:

niemiecka maszyna szyfrująca opracowana przez Artura Scherbiusa w 1918 roku **~warto zajrzeć:** http://www.lootwock.pl/zal1.pdf (dokładnie opisana zasada działania)
Zasada działania jest następująca, mamy do dyspozycji tzw. wirniki i "odwracacz". Wirniki każdy kolejno przesuwał kodowaną
literę a następnie po przejściu na odwracacz, zmieniał pozycje ustawienia wirnika tak aby kolejnym razem litera np. A została zakodowana w inny
sposób. 


> 7. Szyfr Quagmire II

jedna z czterech wariancji szyfru podstawieniowego Quagmire. Do szyfrowania używane jest hasło oraz
słowo kluczowe. Połączenie te zwiększa skutecznosć szyfrowania. Implementacja ze strony: http://mattomatti.com/pl/a35bv?plang=cs#elcode0


> 8. C#-owy Keylogger

Keylogger to oprogramowanie, które pozwala rejestrować klawisze naciskane przez użytkownika. Może posłużyć do zbierania haseł, poufnych danych
albo jako kontrola aktywności pracowników przez pracodawcę. Możemy spotkać keylogger'y w oprogramowaniu ale i także specjalne wersje sprzętowe
które podpina się jak zwykłą pamięć FLASH. W przypadku keylogger'a w oprogramowaniu jeżeli nie nazwany odpowiednio - łatwo go można wykryć w 
menedrzeże zadań. Jeśli obawiamy się "podsłuchu" przez keylogger'a jest masa stron na temat jak wyśledzić takie oprogramowanie oraz jak temu
zaradzić. Historia kliknięć znajduje się w pliku log ~źródło: https://null-byte.wonderhowto.com/how-to/create-simple-hidden-console-keylogger-c-sharp-0132757/

Atak na algorytmy szyfrujące(rodzaje):
- atak w oparciu o słabość algorytmu
- atak brute force;
- ataki statystyczne
- meet in the middle
- atak przez analizę różnicową;
- atak urodzinowy;
- atak algebraiczny;