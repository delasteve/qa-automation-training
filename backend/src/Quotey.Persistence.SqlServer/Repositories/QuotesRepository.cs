using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quotey.Domain.Quotes.Models;
using Quotey.Domain.Quotes.Services;
using Quotey.Persistence.SqlServer.Entities;

namespace Quotey.Persistence.SqlServer.Repositories
{
    public class QuotesRepository : IQuotesRepository
    {
        private readonly QuoteyContext _dbContext;

        public QuotesRepository(QuoteyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ReadOnlyQuote>> GetAllQuotes()
        {
            var quotes = await _dbContext.Quotes
                .AsNoTracking()
                .ToListAsync();

            return quotes.Select(quote => quote.AsReadOnly());
        }

        public async Task<ReadOnlyQuote> GetQuote(int id)
        {
            var quote = await _dbContext.Quotes
                .AsNoTracking()
                .FirstAsync(q => q.Id == id);

            return quote.AsReadOnly();
        }

        public async Task<ReadOnlyQuote> CreateQuote(string phrase, string attribution)
        {
            var currentTime = DateTimeOffset.UtcNow;

            var entity = new Quote
            {
                Phrase = phrase,
                Attribution = attribution,
                CreatedAt = currentTime,
                UpdatedAt = currentTime
            };

            _dbContext.Quotes.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity.AsReadOnly();
        }

        public async Task<ReadOnlyQuote> UpdateQuote(ReadOnlyQuote quote)
        {
            var entity = await _dbContext.Quotes.FirstAsync(q => q.Id == quote.Id);

            entity.Phrase = quote.Phrase;
            entity.Attribution = quote.Attribution;
            entity.UpdatedAt = DateTimeOffset.UtcNow;

            await _dbContext.SaveChangesAsync();

            return entity.AsReadOnly();
        }

        public async Task DeleteQuote(int id)
        {
            var entity = await _dbContext.Quotes
                .AsNoTracking()
                .FirstAsync(q => q.Id == id);

            _dbContext.Quotes.Remove(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
