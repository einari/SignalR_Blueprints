using System;
using Bifrost.Commands;
using Bifrost.Domain;

namespace Web.Domain.Accounts
{
    public class CommandHandlers : IHandleCommands
    {
        IAggregateRootRepository<Transaction> _repository;

        public CommandHandlers(IAggregateRootRepository<Transaction> repository)
        {
            _repository = repository;
        }

        public void Handle(Transfer transfer)
        {
            var transferring = _repository.Get(Guid.NewGuid());
            transferring.Transfer(transfer.From, transfer.To, transfer.Amount);
        }
    }
}