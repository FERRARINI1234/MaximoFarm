using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Core.Messages
{
    public interface IValidation
    { 
        public bool ValidarComando(Command command);
    }
}
