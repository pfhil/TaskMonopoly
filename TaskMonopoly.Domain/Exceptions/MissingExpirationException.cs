using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMonopoly.Domain.Entities;

namespace TaskMonopoly.Domain.Exceptions
{
    public class MissingExpirationException : Exception
    {
        public MissingExpirationException(Box box) : base($"Не указан ни срок годности, ни дата производства для коробки {box.Id}.")
        {

        }
    }
}
