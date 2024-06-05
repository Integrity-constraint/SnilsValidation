

 bool IsValidSnils(string snils)
{
    if (snils.Length != 11) return false; // СНИЛС должен состоять из 11 символов

    int controlNumber = int.Parse(snils.Substring(9, 2)); // Контрольное число - последние две цифры СНИЛС
    int snilsNumber = int.Parse(snils.Substring(0, 9)); // Остальная часть СНИЛС

    if (snilsNumber <= 1001998) return true; // Если номер СНИЛС меньше или равен 001-001-998, контрольное число не проверяется

    int sum = 0;
    for (int i = 0; i < 9; i++)
    {
        sum += int.Parse(snils[i].ToString()) * (9 - i);
    }

    int calculatedControlNumber;
    if (sum < 100) calculatedControlNumber = sum;
    else if (sum > 101) calculatedControlNumber = sum % 101;
    else calculatedControlNumber = 0;

    return controlNumber == calculatedControlNumber;
}

 void CheckSnilsList(List<string> snilsList)
{
    Parallel.ForEach(snilsList, snils =>
    {
        bool isValid = IsValidSnils(snils);
        Console.WriteLine($"СНИЛС: {snils}, Валидность: {isValid}");
    });
}

List<string> snilsList = new List<string>
{
    "11223344595", // Валидный СНИЛС
    "12345678901", // Невалидный СНИЛС
    "00100199850"  // СНИЛС с номером меньше 001-001-998
};

CheckSnilsList(snilsList);
while (true)
{
    Console.WriteLine("Введите значения");
    string snils = Console.ReadLine();
    snilsList.Clear();
    snilsList.Add(snils);
    CheckSnilsList(snilsList);
}