using System;
using Quotey.Domain.Quotes.Models;

namespace Quotey.Persistence.SqlServer.Entities
{
    public class Quote
    {
        public int Id { get; set; }
        public string Phrase { get; set; }
        public string Attribution { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public ReadOnlyQuote AsReadOnly()
        {
            return new ReadOnlyQuote(Id, Phrase, Attribution, CreatedAt, UpdatedAt);
        }
    }
}
