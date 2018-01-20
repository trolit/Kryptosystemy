# Kryptosystemy
## #############################################

**szyfrowanie** to po prostu metoda zapisu tekstu jawnego w taki sposób, 
by stał się on nieczytelny dla osób trzecich i jednocześnie z powrotem 
jawny po właściwej weryfikacji. ~securelist.pl

> 1. Szyfr Cezara(szyfr przesuwający):

Jeden z najstarszych szyfrów. Jest zbudowany na zasadzie że, każdą literę tekstu niezaszyfrowanego zastępujemy inną przesuniętą
względem litery kodowanej o stałą liczbę pozycji w alfabecie. Na przykład dla litery „a” (kod ASCII 97) przy przesunięciu o 2,
literą kodowaną będzie „c” (kod ASCII 99) itd.... Nie gwarantuje on obecnie żadnego bezpieczeństwa. 



> 2. Szyfr Homofoniczny(inspiracja od szyfru Beale'a):

Szyfr homofoniczny to szyfr podstawieniowy, w którym każdej literze tekstu jawnego odpoiwada inny zbiór symboli
kryptogramu(homofonów). Liczba homofonów powinna być zależna od częstotliwości występowania danej litery w tekście
do zaszyfrowania. Przy każdym szyfrowaniu litery wybierany jest losowo jeden z jej homofonów. W ten sposób zostaje
spłaszczony histogram kryptogramu, a wielokrotne szyfrowanie tego samego tekstu daje za kazdym razem inny wynik.
Cechy te znaczaco utrudniaja kryptoanalizę. ~źródło: Wikipedia



> 3. Szyfr ROT13(szyfr przesuwający):

Szyfrowanie to polega na przesuwaniu każdej litery tekstu jawneg o 13 pozycji do przodu. Działanie zatem jest bardzo
proste co powoduje, że sam szyfr jest mało bezpieczny. Mechanizm ten jest bardzo podobny do szyfru Cezara. ROT13 
różni się jedynie wartością o jaką przesuwane są litery. ~źródło: securelist



Atak na algorytmy szyfrujące(rodzaje):
- atak w oparciu o słabość algorytmu
- atak brute force;
- ataki statystyczne
- meet in the middle
- atak przez analizę różnicową;
- atak urodzinowy;
- atak algebraiczny;