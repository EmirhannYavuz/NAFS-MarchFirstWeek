using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using DataAccess.Abstract;

class Program
{
    static void Main(string[] args)
    {
        IProgrammingLanguageRepository languageRepository = new InMemoryProgrammingLanguageRepository();
        ITechnologyRepository technologyRepository = new InMemoryTechnologyRepository();
        ProgrammingLanguageService languageService = new ProgrammingLanguageService(languageRepository);
        TechnologyService technologyService = new TechnologyService(technologyRepository);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("- Yazılım Teknolojileri Yönetimi -");
            Console.WriteLine("1. Programlama Dilleri İşlemleri");
            Console.WriteLine("2. Teknoloji İşlemleri");
            Console.WriteLine("3. Çıkış");
            Console.Write("Seçiminizi giriniz: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ProgrammingLanguageMenu(languageService);
                    break;
                case "2":
                    TechnologyMenu(technologyService, languageService);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim yapıldı.");
                    break;
            }

            Console.WriteLine("Devam etmek için herhangi bir tuşa basın...");
            Console.ReadKey();
        }
    }

    static void ProgrammingLanguageMenu(ProgrammingLanguageService languageService)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("- Programlama Dilleri İşlemleri -");
            Console.WriteLine("1. Tüm Dilleri Listele");
            Console.WriteLine("2. Yeni Dil Ekle");
            Console.WriteLine("3. Dil Güncelle");
            Console.WriteLine("4. Dil Sil");
            Console.WriteLine("5. ID'ye Göre Dil Getir");
            Console.WriteLine("0. Ana Menüye Dön");
            Console.Write("Seçiminiz: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    List<ProgrammingLanguage> languages = languageService.GetAll();
                    foreach (var lang in languages)
                    {
                        Console.WriteLine($"ID: {lang.Id} - Ad: {lang.Name}");
                    }
                    break;

                case "2":
                    Console.Write("Dil Adı: ");
                    string name = Console.ReadLine();
                    languageService.Add(new ProgrammingLanguage { Name = name });
                    Console.WriteLine("Dil başarıyla eklendi.");
                    break;

                case "3":
                    Console.Write("Güncellenecek Dilin ID'si: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Yeni Ad: ");
                    string newName = Console.ReadLine();
                    languageService.Update(new ProgrammingLanguage { Id = updateId, Name = newName });
                    Console.WriteLine("Dil başarıyla güncellendi.");
                    break;

                case "4":
                    Console.Write("Silinecek Dilin ID'si: ");
                    int deleteId = Convert.ToInt32(Console.ReadLine());
                    languageService.Delete(deleteId);
                    Console.WriteLine("Dil başarıyla silindi.");
                    break;

                case "5":
                    Console.Write("Getirilecek Dilin ID'si: ");
                    int getId = Convert.ToInt32(Console.ReadLine());
                    var language = languageService.GetById(getId);
                    Console.WriteLine($"ID: {language.Id} - Ad: {language.Name}");
                    break;

                case "0":
                    return;
            }

            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }

    static void TechnologyMenu(TechnologyService technologyService, ProgrammingLanguageService languageService)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("- Teknoloji İşlemleri -");
            Console.WriteLine("1. Tüm Teknolojileri Listele");
            Console.WriteLine("2. Yeni Teknoloji Ekle");
            Console.WriteLine("3. Teknoloji Güncelle");
            Console.WriteLine("4. Teknoloji Sil");
            Console.WriteLine("5. ID'ye Göre Teknoloji Getir");
            Console.WriteLine("0. Ana Menüye Dön");
            Console.Write("Seçiminiz: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    List<Technology> technologies = technologyService.GetAll();
                    foreach (var tech in technologies)
                    {
                        Console.WriteLine($"ID: {tech.Id} - Ad: {tech.Name} - Programlama Dili ID: {tech.ProgrammingLanguageId}");
                    }
                    break;

                case "2":
                    Console.WriteLine("Mevcut Programlama Dilleri:");
                    List<ProgrammingLanguage> languages = languageService.GetAll();
                    foreach (var lang in languages)
                    {
                        Console.WriteLine($"ID: {lang.Id} - Ad: {lang.Name}");
                    }

                    Console.Write("Teknoloji Adı: ");
                    string techName = Console.ReadLine();
                    Console.Write("Programlama Dili ID: ");
                    int langId = Convert.ToInt32(Console.ReadLine());
                    technologyService.Add(new Technology { Name = techName, ProgrammingLanguageId = langId });
                    Console.WriteLine("Teknoloji başarıyla eklendi.");
                    break;

                case "3":
                    Console.Write("Güncellenecek Teknolojinin ID'si: ");
                    int techUpdateId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Yeni Ad: ");
                    string techNewName = Console.ReadLine();
                    Console.Write("Yeni Programlama Dili ID: ");
                    int newLangId = Convert.ToInt32(Console.ReadLine());
                    technologyService.Update(new Technology { Id = techUpdateId, Name = techNewName, ProgrammingLanguageId = newLangId });
                    Console.WriteLine("Teknoloji başarıyla güncellendi.");
                    break;

                case "4":
                    Console.Write("Silinecek Teknolojinin ID'si: ");
                    int techDeleteId = Convert.ToInt32(Console.ReadLine());
                    technologyService.Delete(techDeleteId);
                    Console.WriteLine("Teknoloji başarıyla silindi.");
                    break;

                case "5":
                    Console.Write("Getirilecek Teknolojinin ID'si: ");
                    int techGetId = Convert.ToInt32(Console.ReadLine());
                    var technology = technologyService.GetById(techGetId);
                    Console.WriteLine($"ID: {technology.Id} - Ad: {technology.Name} - Programlama Dili ID: {technology.ProgrammingLanguageId}");
                    break;

                case "0":
                    return;
            }

            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}
