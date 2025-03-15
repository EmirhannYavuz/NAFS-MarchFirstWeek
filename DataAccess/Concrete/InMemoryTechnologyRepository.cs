using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete;

public class InMemoryTechnologyRepository : ITechnologyRepository
{
    private List<Technology> _technologies = new();

    public void Add(Technology tech) => _technologies.Add(tech);
        
    public void Update(Technology tech)
    {
        var t = _technologies.FirstOrDefault(t => t.Id == tech.Id);
        if (t != null) t.Name = tech.Name;
    }

    public void Delete(Technology tech) => _technologies.Remove(tech);
        
    public Technology GetById(int id) => _technologies.FirstOrDefault(t => t.Id == id);
        
    public List<Technology> GetAll() => _technologies;
}