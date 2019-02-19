using Brickweave.Cqrs;

namespace Quotey.Domain.Quotes.Commands
{
    public class DeleteQuote : ICommand
    {
        public DeleteQuote(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
