using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete;

public class TechnologyService
{
    private readonly ITechnologyRepository _repository;
    private readonly ProgrammingLanguageService _languageService;

    public TechnologyService(ITechnologyRepository repository, ProgrammingLanguageService languageService)
    {
        _repository = repository;
        _languageService = languageService;
    }

    public void Add(Technology tech)
    {
        if (string.IsNullOrWhiteSpace(tech.Name))
        {
            Console.WriteLine("Hata: Teknoloji adı boş olamaz.");
            return;
        }
        
        var programmingLanguage = _repository.GetById(tech.ProgrammingLanguageId);

        if (programmingLanguage == null)
        {
            Console.WriteLine("Uyarı: Geçersiz Programlama dili ID'si.");
            return;
        }
        
        _repository.Add(tech);
        Console.WriteLine($"{tech.Name} başarıyla eklendi.");
    }

    public void Update(Technology tech)
    {
        if (tech.Id < 0)
        {
            Console.WriteLine("Hata: Geçersiz ID.");
            return;
        }

        var existingLanguage = _languageService.GetById(tech.ProgrammingLanguageId);
        if (existingLanguage == null)
        {
            Console.WriteLine("Hata: Geçersiz programlama dili ID.");
            return;
        }

        _repository.Update(tech);
        Console.WriteLine("Teknoloji başarıyla güncellendi.");
    }

    public void Delete(int id)
    {
        var tech = _repository.GetById(id);
        if (tech == null)
        {
            Console.WriteLine("Hata: Teknoloji bulunamadı.");
            return;
        }

        _repository.Delete(tech);
        Console.WriteLine("Teknoloji başarıyla silindi.");
    }

    public List<Technology> GetAll()
    {
        var techList = _repository.GetAll();
        if (techList.Count == 0)
        {
            Console.WriteLine("Uyarı: Hiç teknoloji bulunamadı.");
        }
        
        return techList;
    }

    public Technology? GetById(int id)
    {
        var tech = _repository.GetById(id);
        if (tech == null)
        {
            Console.WriteLine("Uyarı: Teknoloji bulunamadı.");
            return null;
        }

        return tech;
    }
}
