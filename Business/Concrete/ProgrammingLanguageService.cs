using DataAccess.Abstract;
using Entities.Concrete;

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
            throw new ArgumentException("Programlama dili adı boş olamaz.");

        _repository.Add(language);
    }

    public void Update(ProgrammingLanguage language)
    {
        if (language.Id <= 0)
            throw new ArgumentException("Geçersiz ID.");

        _repository.Update(language);
    }

    public void Delete(int id)
    {
        var language = _repository.GetById(id);
        if (language == null)
            throw new KeyNotFoundException("Programlama dili bulunamadı.");

        _repository.Delete(language);
    }

    public List<ProgrammingLanguage> GetAll()
    {
        return _repository.GetAll();
    }

    public ProgrammingLanguage GetById(int id)
    {
        var language = _repository.GetById(id);
        if (language == null)
            throw new KeyNotFoundException("Programlama dili bulunamadı.");

        return language;
    }
}