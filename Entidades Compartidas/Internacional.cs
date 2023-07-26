using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_Compartidas
{
    public class Internacional : Terminal
    {
        private string _pais;

        public string Pais
        {
            get { return _pais; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("Debe saberse el pais");
                else if (value.Length > 20)
                    throw new Exception("Máximo 20 carácteres para el país.");
                else
                    _pais = value;
            }
        }
        public Internacional (string pCodigo, string pCiudad, string pPais)
            :base(pCodigo,pCiudad)
        {
            Pais = pPais;
        }

    }
}
