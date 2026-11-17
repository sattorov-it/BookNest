using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AuthorRepository(ApplicationDbContext appDbContext) : IAuthorRepository
{
    private readonly ApplicationDbContext _context = appDbContext;

    public async Task<bool> AddAuthorAsync(Author author)
    {
        _context.Authors.Add(author);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
        if (author == null) return false;
        _context.Authors.Remove(author);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> UpdateAuthorAsync(Author author)
    {
        var a = await _context.Authors.FirstOrDefaultAsync(x => x.Id == author.Id);
        if (a == null) return false;
        a.Fullname = author.Fullname;
        a.Country = author.Country;
        a.BirthYear = author.BirthYear;
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Author> GetAuthorAsync(int id)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
        return author!;
    }

    public async Task<List<Author>> GetAuthorsAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<int> GetAuthorsAmountAsync()
    {
        return await _context.Authors.CountAsync();
    }
}