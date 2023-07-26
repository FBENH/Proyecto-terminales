using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades_Compartidas
{
    public abstract class Terminal
    {
        private string _codigo;
        private string _ciudad;

        public string Codigo
        {
            get { return _codigo; }
            set
            {
                if (!Regex.IsMatch(value,"[a-zA-Z]{6}"))
                    throw new Exception("El código debe estar compuesto por 6 letras.");
                else
                    _codigo = value;
            }
        }
        public string Ciudad
        {
            get { return _ciudad; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("Debe saberse la ciudad");
                else if (value.Length > 30)
                    throw new Exception("Máximo 30 carácteres para ciudad.");
                else
                    _ciudad = value;
            }
        }
        public Terminal (string pCodigo, string pCiudad)
        {
            Codigo = pCodigo;
            Ciudad = pCiudad;
        }
    }
}
