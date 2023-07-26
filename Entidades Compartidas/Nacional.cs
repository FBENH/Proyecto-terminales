using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_Compartidas
{
    public class Nacional : Terminal
    {
        private bool _taxi;

        public bool Taxi // si alguno sabe que codigo defensivo va por aqui mejor
        {
            get { return _taxi; }
            set { _taxi = value; }
        }
        public Nacional(string pCodigo, string pCiudad, bool pTaxi) 
            :base(pCodigo,pCiudad)
        {
            Taxi = pTaxi;
        }
    }
}
