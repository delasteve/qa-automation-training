using Brickweave.Cqrs;
using Quotey.Domain.Quotes.Models;

namespace Quotey.Domain.Quotes.Commands
{
    public class UpdateQuote : ICommand<ReadOnlyQuote>
    {
        public UpdateQuote(int id, string phrase, string attribution)
        {
            if (string.IsNullOrWhiteSpace(phrase))
            {
                throw new System.ArgumentException("Phrase cannot be empty", nameof(phrase));
            }

            if (string.IsNullOrWhiteSpace(attribution))
            {
                throw new System.ArgumentException("Attribution cannot be empty", nameof(attribution));
            }

            Id = id;
            Phrase = phrase;
            Attribution = attribution;
        }

        public int Id { get; set; }
        public string Phrase { get; }
        public string Attribution { get; }
    }
}
