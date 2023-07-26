using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_Compartidas
{
    public class PasaPor
    {
        private int _orden;
        private Terminal _ter;

        public int Orden
        {
            get { return _orden; }
            set
            {
                if (value <= 0)
                    throw new Exception("Debe saberse el orden");
                else
                    _orden = value;
            }
        }
        public Terminal Ter
        {
            set
            {
                if (value != null)
                    _ter = value;
                else
                    throw new Exception("Falta Terminal");
            }
            get { return _ter; }
        }
        public PasaPor(int pOrden, Terminal pTer)
        {
            Orden = pOrden;
            Ter = pTer;
        }
    }
}
