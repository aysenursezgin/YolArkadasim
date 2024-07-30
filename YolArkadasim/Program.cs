using System.Globalization;

while (true)
{
    // Lokasyon seçimi
    string location = GetLocation();
    int locationCost = GetLocationCost(location);

    // Kişi sayısı
    int personCount = GetPersonCount();

    // Ulaşım seçeneği
    (string transportMode, int transportCost) = GetTransportation();

    // Özet bilgiyi göster
    PrintSummary(location, locationCost, personCount, transportMode, transportCost);

    // Toplam maliyeti hesapla
    int totalCost = CalculateTotalCost(locationCost, personCount, transportCost);
    Console.WriteLine($"\nToplam Maliyet: {totalCost} TL");

    // Başka bir tatil planı isteği
    Console.Write("\nBaşka bir tatil planlamak ister misiniz? (E/H): ");
    string anotherPlan = Console.ReadLine().Trim().ToUpper();
    if (anotherPlan != "E")
    {
        Console.WriteLine("İyi günler!");
        break;
    }
}
    

    static string GetLocation()
{
    while (true)
    {
        Console.Write("Gitmek istediğiniz lokasyonu giriniz (Bodrum, Marmaris, Çeşme): ");
        string input = Console.ReadLine().Trim().ToLower();
        switch (input)
        {
            case "bodrum":
            case "marmaris":
            case "çeşme":
                return input;
            default:
                Console.WriteLine("Geçersiz lokasyon! Lütfen 'Bodrum', 'Marmaris' ya da 'Çeşme' giriniz.");
                break;
        }
    }
}

static int GetLocationCost(string location)
{
    switch (location)
    {
        case "bodrum": return 4000;
        case "marmaris": return 3000;
        case "çeşme": return 5000;
        default: throw new ArgumentException("Geçersiz lokasyon.");
    }
}

static int GetPersonCount()
{
    while (true)
    {
        Console.Write("Kaç kişi için tatil planlıyorsunuz?: ");
        if (int.TryParse(Console.ReadLine(), out int personCount) && personCount > 0)
        {
            return personCount;
        }
        else
        {
            Console.WriteLine("Geçersiz giriş! Lütfen pozitif bir sayı giriniz.");
        }
    }
}

static (string, int) GetTransportation()
{
    while (true)
    {
        Console.Write("Ulaşım tercihinizi seçiniz (1: Kara yolu, 2: Hava yolu): ");
        string choice = Console.ReadLine().Trim();
        switch (choice)
        {
            case "1":
                return ("Kara yolu", 1500);
            case "2":
                return ("Hava yolu", 4000);
            default:
                Console.WriteLine("Geçersiz seçenek! Lütfen '1' ya da '2' giriniz.");
                break;
        }
    }
}

static void PrintSummary(string location, int locationCost, int personCount, string transportMode, int transportCost)
{
    Console.WriteLine($"\nSeçilen Lokasyon: {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(location)}");
    Console.WriteLine($"Lokasyon Maliyeti: {locationCost} TL");
    Console.WriteLine($"Kişi Sayısı: {personCount}");
    Console.WriteLine($"Ulaşım Tercihi: {transportMode}");
    Console.WriteLine($"Ulaşım Maliyeti (kişi başı): {transportCost} TL");
}

static int CalculateTotalCost(int locationCost, int personCount, int transportCost)
{
    return (locationCost + transportCost) * personCount;
}
