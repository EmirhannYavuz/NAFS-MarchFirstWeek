using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class TechnologyService
{
    private readonly ITechnologyRepository _repository;

    public TechnologyService(ITechnologyRepository repository)
    {
        _repository = repository;
    }

    public void Add(Technology tech)
    {
        if (string.IsNullOrWhiteSpace(tech.Name))
            throw new ArgumentException("Teknoloji adı boş olamaz.");
        if (tech.ProgrammingLanguageId <= 0)
            throw new ArgumentException("Geçersiz programlama dili.");

        _repository.Add(tech);
    }

    public void Update(Technology tech)
    {
        if (tech.Id <= 0)
            throw new ArgumentException("Geçersiz ID.");

        _repository.Update(tech);
    }

    public void Delete(int id)
    {
        var tech = _repository.GetById(id);
        if (tech == null)
            throw new KeyNotFoundException("Teknoloji bulunamadı.");

        _repository.Delete(tech);
    }

    public List<Technology> GetAll()
    {
        return _repository.GetAll();
    }

    public Technology GetById(int id)
    {
        var tech = _repository.GetById(id);
        if (tech == null)
            throw new KeyNotFoundException("Teknoloji bulunamadı.");

        return tech;
    }
}