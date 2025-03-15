using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;

var languageRepository = new InMemoryProgrammingLanguageRepository();
var technologyRepository = new InMemoryTechnologyRepository();

var languageService = new ProgrammingLanguageService(languageRepository);
var technologyService = new TechnologyService(technologyRepository);

while (true)
{
    Console.Clear();
    Console.WriteLine("Programlama Dili Yönetimi");
    Console.WriteLine("1. Programlama Dili Ekle");
    Console.WriteLine("2. Programlama Dili Listele");
    Console.WriteLine("3. Teknoloji Ekle");
    Console.WriteLine("4. Teknolojileri Listele");
    Console.WriteLine("5. Çıkış");
    Console.Write("Bir seçenek girin: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Programlama dili adını girin: ");
            var languageName = Console.ReadLine();
            var programmingLanguage = new ProgrammingLanguage { Name = languageName };
            languageService.Add(programmingLanguage);
            Console.WriteLine("Programlama dili eklendi.");
            break;

        case "2":
            var languages = languageService.GetAll();
            Console.WriteLine("Programlama Dilleri:");
            foreach (var lang in languages)
            {
                Console.WriteLine($"ID: {lang.Id}, Ad: {lang.Name}");
            }

            break;

        case "3":
            Console.Write("Teknoloji adını girin: ");
            var techName = Console.ReadLine();
            Console.Write("Teknolojiye ait programlama dili ID'sini girin: ");
            int langId = Convert.ToInt32(Console.ReadLine());
            var technology = new Technology { Name = techName, ProgrammingLanguageId = langId };
            technologyService.Add(technology);
            Console.WriteLine("Teknoloji eklendi.");
            break;

        case "4":
            var technologies = technologyService.GetAll();
            Console.WriteLine("Teknolojiler:");
            foreach (var tech in technologies)
            {
                Console.WriteLine($"ID: {tech.Id}, Ad: {tech.Name}, Programlama Dili ID: {tech.ProgrammingLanguageId}");
            }

            break;

        case "5":
            // Çıkış
            return;

        default:
            Console.WriteLine("Geçersiz seçenek.");
            break;
    }

    Console.WriteLine("\nDevam etmek için bir tuşa basın...");
    Console.ReadKey();
}