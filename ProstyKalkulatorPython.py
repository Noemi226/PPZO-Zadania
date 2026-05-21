l1 = float(input("Podaj pierwszą liczbę: "))
l2 = float(input("Podaj drugą liczbę: "))
opcja = input("Operatory arytmetyczne \n Dodawanie + \n Odejmowanie - \n Mnożenie * \n Dzielenie / \n Wybierz operację: ")

if opcja == '+':
    wynik = l1 + l2

elif opcja == '-':
    wynik = l1 - l2

elif opcja == '*':
    wynik = l1 * l2

elif opcja == '/':
    if l2 == 0:
        wynik = "Błąd (Nie dzieli się przez zero)"
    else:
        wynik = l1 / l2

else:
    wynik = "Nie rozpoznano operatora"


#usuwanie zer po przecinku
if isinstance(wynik, float) and wynik.is_integer():     
    wynik = int(wynik)

print(f"Wynik: {wynik}")
