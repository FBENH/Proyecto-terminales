using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_Compartidas;
namespace Logica
{
    public interface ILogicaCompañia
    {
        Compañia Buscar(string unaC);
        void Alta(Compañia unaC);
    }
}
