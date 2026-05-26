liczba_ocen = int(input("Podaj liczbę ocen: "))

suma_ocen = 0.0

for i in range(liczba_ocen):
    while True:
        ocena = float(input(f"Podaj ocenę {i + 1}: "))
        
        if ocena in [1, 2, 3, 4, 5, 6]:
            suma_ocen += ocena
            break 
        else:
            print("Błąd: Dozwolone są tylko oceny 1, 2, 3, 4, 5 lub 6. Spróbuj ponownie.")

if liczba_ocen > 0:
    srednia = suma_ocen / liczba_ocen
    
    print(f"Średnia: {srednia:.2f}")
    
    if srednia >= 3.0:
        print("Uczeń zdał.")
    else:
        print("Uczeń nie zdał.")
else:
    print("Brak ocen do obliczenia średniej.")
