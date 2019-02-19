using System;

namespace Quotey.Domain.Quotes.Models
{
    public class ReadOnlyQuote
    {
        public ReadOnlyQuote(int id, string phrase, string attribution, DateTimeOffset createdAt, DateTimeOffset updatedAt)
        {
            Id = id;
            Phrase = phrase;
            Attribution = attribution;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public int Id { get; }
        public string Phrase { get; }
        public string Attribution { get; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
