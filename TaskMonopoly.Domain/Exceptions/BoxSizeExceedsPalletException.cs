using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMonopoly.Domain.Entities;

namespace TaskMonopoly.Domain.Exceptions
{
    public class BoxSizeExceedsPalletException : Exception
    {
        public BoxSizeExceedsPalletException(Box box, Pallet pallet) : base($"Коробка {box.Id}, не может превышать по размерам паллету {pallet.Id}")
        {

        }
    }
}
