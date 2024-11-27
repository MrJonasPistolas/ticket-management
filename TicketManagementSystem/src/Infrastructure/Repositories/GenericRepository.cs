using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    internal readonly IdentityDbContext _context;

    public GenericRepository(IdentityDbContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public T GetByIdAsync(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public List<T> ListAll()
    {
        return _context.Set<T>().ToList();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }
}
