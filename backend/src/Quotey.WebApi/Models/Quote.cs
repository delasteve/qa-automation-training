using System;

namespace Quotey.WebApi.Models
{
    public class Quote
    {
        public Quote(int id, string phrase, string attribution, DateTimeOffset createdAt, DateTimeOffset updatedAt)
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
        public DateTimeOffset CreatedAt { get; }
        public DateTimeOffset UpdatedAt { get; }
    }
}
