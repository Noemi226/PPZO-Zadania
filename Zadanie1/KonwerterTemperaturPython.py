#strip usuwa puste znaki a upper interpretuje litere z malej na duza
wybor = input("Wybierz konwersję (C - z Celsjusza na Fahrenheita, F - z Fahrenheita na Celsjusza): ").strip().upper()       

if wybor in ['C', 'F']:
    temp = float(input("Podaj temperaturę: "))
    
    if wybor == 'C':
        wynik = temp * 1.8 + 32
        
        if temp.is_integer(): temp = int(temp)
        if isinstance(wynik, float) and wynik.is_integer(): wynik = int(wynik)
            
        print(f"{temp}°C = {wynik}°F")
        
    elif wybor == 'F':
        wynik = (temp - 32) / 1.8
        
        if temp.is_integer(): temp = int(temp)
        if isinstance(wynik, float) and wynik.is_integer(): wynik = int(wynik)
            
        print(f"{temp}°F = {wynik}°C")
else:
    print("Błąd! Wpisz C lub F.")

