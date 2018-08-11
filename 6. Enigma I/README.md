# Projekty ENIGMA

W tym folderze znajdziesz wszelkie wersje odnośnie programu działającego na wzór Engimy.
__Poniżej znajdują się opisy do każdej wersji, czym się różnią, co wprowadzają itd..__

### Projekt Enigma(wersja - sol1, v1.14A) ###
Pierwsza wersja Enigmy. Niestety niezbyt skuteczna gdyż jej wadą jest to, że szyfruje
1) przypadkowo
2) w zależności od podanego klucza kodowania tzn. podaliśmy klucz kodowania np. ABC
to jeżeli podaliśmy słowo AMEBA to zakodował jakoś tam załóżmy COKTA, gdy podaliśmy
klucz kodowania ten sam i inne słowo np. PIES to litery były kodowane tak samo jak |
w przypadku słowa AMEBA czyli otrzymalibyśmy COKT.

Ta wersja nie była wystarczająco satysfakcjonująca więc zdecydowałem się na stworzenie
kolejnej od zupełnego zera - niż próbując przerobić wersję 1.14A i z zastosowaniem innego
pomysłu na rozwiązanie kwestii szyfrowania liter wirnikami(rotorami)

### Projekt Enigma(wersja - sol2, v1.65) ###
#### 
Autorska wersja Enigmy charakteryzująca się przede wszytkim tym, że wyeliminowano w 
niej wszelkie problemy, które zawierała Enigma w pierwszej wersji. Problem szyfrowania
rozwiązany został w sprytny sposób stworzenia tablicy znaków przechowującej wszystkie
litery alfabetu(bez polskich znaków). Ta tablica rozpoczynała tak jak alfabet czyli 
od A...Z. W momencie gdy został obrócony jakiś wirnik to elementy w tej tablicy były
również przesuwane. Czyli mając 3 wirniki(pierwszy, drugi i trzeci) - jeżeli pierwszy
wirnik osiągnął pełny obrót, zostawał resetowany do pozycji 0 i zezwalał wirnikowi2 na
zakodowanie znaku. Następnie zostaje __dodatkowo__ obrócona tablica znaków. Jeżeli wirnik2
z kolei osiągnął pełny obrót, zezwalał wirnikowi3 na zakodowanie przekazanego znaku po
czym również przesunął znaki w tablicy. Wersja v1.65 o wiele lepiej oddała charakterystykę
działania Enigmy na trzech wirnikach jednak nie była doskonała. Wiemy, że Enigma nigdy nie
szyfrowała litery w samą siebie np. A -> A co było jedną z jej największych wad. Ta wersja
w niezależnie jakim słowie czy kluczu kodowania szyfruje drugą literę w samą siebie.. Z 
racji, że dużo czasu poświęciłem na wersję v1.65 to zamiast ją poprawiać postanowiłem
rozbudować ją w kolejnej wersji czyli v2.00.


Widok z konsoli                                   |   Przykładowy efekt(widok słowny)
:------------------------------------------------:|:------------------------------------------------:
![error](https://github.com/trolit/Kryptosystemy/blob/master/images/enigma_menu.PNG) | ![error](https://github.com/trolit/Kryptosystemy/blob/master/images/enigma_szyfr01.PNG)
Pokaz działania badania programu                  |   Przykładowy efekt(widok strzałkowy)
![error](https://github.com/trolit/Kryptosystemy/blob/master/images/enigma_gif.gif) | ![error](https://github.com/trolit/Kryptosystemy/blob/master/images/enigma_szyfr02.PNG)


### Projekt Enigma(wersja - sol3, v2.0) ###
Autorska wersja __ulepszonej__ Enigmy w której rozwiązany został problem kodowania drugiej 
litery w samą siebie. Na pomysł wpadłem w trakcie tworzenia projektu w Unity zupełnie przypadkowo.
Mianowicie, w wersji 2.0 został zaimplementowany system, który liczy odległość pierwszego znaku
podanego do klucza kodowania od pierwszej litery alfabetu(czyli A). Odległość ta jest wykorzystywana
do tego aby przed rozpoczęciem jakiegokolwiek szyfrowania wiadomości obrócić tablicę zawierającą
znaki. Znaki w tablicy są przemieszczane tyle razy ile wyniosła odległość. Na ten moment zostało
wprowadzone profilaktyczne rozwiązanie sprawy kodowania litery w samą siebie. Jeżeli tak się 
wydarzy program dostanie rozkaz aby dodatkową przesunąć zakodowaną literę o jeden dalej.

Widok z konsoli                                   |   Przykładowy efekt(widok słowny)
:------------------------------------------------:|:------------------------------------------------:
![error](https://github.com/trolit/Kryptosystemy/blob/master/images/eni_sol3menu.PNG) | ![error](https://github.com/trolit/Kryptosystemy/blob/master/images/eni_sol3example1.PNG)