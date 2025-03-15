using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete;

public class InMemoryProgrammingLanguageRepository : IProgrammingLanguageRepository
{
    private List<ProgrammingLanguage> _programmingLanguages = new();

    public void Add(ProgrammingLanguage language) => _programmingLanguages.Add(language);
        
    public void Update(ProgrammingLanguage language)
    {
        var lang = _programmingLanguages.FirstOrDefault(l => l.Id == language.Id);
        if (lang != null) lang.Name = language.Name;
    }
        
    public void Delete(ProgrammingLanguage language) => _programmingLanguages.Remove(language);
        
    public ProgrammingLanguage GetById(int id) => _programmingLanguages.FirstOrDefault(l => l.Id == id);
        
    public List<ProgrammingLanguage> GetAll() => _programmingLanguages;
}