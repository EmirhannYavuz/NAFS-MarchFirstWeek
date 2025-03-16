using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;

namespace Business.Concrete;

public class ProgrammingLanguageService
{
    private readonly IProgrammingLanguageRepository _repository;

    public ProgrammingLanguageService(IProgrammingLanguageRepository repository)
    {
        _repository = repository;
    }

    public void Add(ProgrammingLanguage language)
    {
        if (string.IsNullOrWhiteSpace(language.Name))
        {
            Console.WriteLine("Hata: Programlama dili adı boş olamaz.");
            return;
        }

        _repository.Add(language);
        Console.WriteLine("Programlama dili başarıyla eklendi.");
    }

    public void Update(ProgrammingLanguage language)
    {
        if (language.Id < 0)
        {
            Console.WriteLine("Hata: Geçersiz ID.");
            return;
        }

        _repository.Update(language);
        Console.WriteLine("Programlama dili başarıyla güncellendi.");
    }

    public void Delete(int id)
    {
        var language = _repository.GetById(id);
        if (language == null)
        {
            Console.WriteLine("Hata: Programlama dili bulunamadı.");
            return;
        }

        _repository.Delete(language);
        Console.WriteLine("Programlama dili başarıyla silindi.");
    }

    public List<ProgrammingLanguage> GetAll()
    {
        var languages = _repository.GetAll();
        if (languages.Count == 0)
        {
            Console.WriteLine("Uyarı: Programlama dili bulunamadı.");
        }
        
        return languages;
    }

    public ProgrammingLanguage? GetById(int id)
    {
        var language = _repository.GetById(id);
        if (language == null)
        {
            Console.WriteLine("Uyarı: Programlama dili bulunamadı.");
            return null;
        }

        return language;
    }
}