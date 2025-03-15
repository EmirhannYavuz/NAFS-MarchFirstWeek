using Entities.Concrete;

namespace DataAccess.Abstract;

public interface ITechnologyRepository
{
    void Add(Technology tech);
    void Update(Technology tech);
    void Delete(Technology tech);
    Technology GetById(int id);
    List<Technology> GetAll();
}