// DataAccess/Concrete/InMemoryTechnologyRepository.cs
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete;

public class InMemoryTechnologyRepository : ITechnologyRepository
{
    private readonly List<Technology> _technologies = new();
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

    public InMemoryTechnologyRepository(IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
    }

    public List<Technology> GetAll()
    {
        return _technologies;
    }

    public Technology GetById(int id)
    {
        return _technologies.FirstOrDefault(t => t.Id == id);
    }

    public void Add(Technology technology)
    {
        var programmingLanguage = _programmingLanguageRepository.GetById(technology.ProgrammingLanguageId);
        if (programmingLanguage == null)
            throw new Exception("Geçersiz Programlama dili ID'si.");

        if (technology.Id <= 0)
        {
            technology.Id = _technologies.Any() ? _technologies.Max(t => t.Id) + 1 : 1;
        }
        _technologies.Add(technology);
    }

    public void Update(Technology technology)
    {
        var existingTechnology = _technologies.FirstOrDefault(t => t.Id == technology.Id);
        if (existingTechnology != null)
        {
            existingTechnology.Name = technology.Name;
            existingTechnology.ProgrammingLanguageId = technology.ProgrammingLanguageId;
        }
    }

    public void Delete(Technology technology)
    {
        _technologies.Remove(technology);
    }

    public void Delete(int id)
    {
        var technology = GetById(id);
        if (technology != null)
        {
            Delete(technology);
        }
    }
}