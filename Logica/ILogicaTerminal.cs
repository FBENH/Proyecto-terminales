using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_Compartidas;

namespace Logica
{
    public interface ILogicaTerminal
    {
        Terminal BuscarTA(string TActiva);
        void Alta(Terminal unaTer);
        void Modificar(Terminal unaTer);
        void Baja(Terminal unaTer);
    }
}
