using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_Compartidas
{
    public class Compañia
    {
        private string _nombre;
        private string _direccion;
        private int _tel;

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("Debe saberse el Nombre de la compañia");
                else if (value.Length > 50)
                    throw new Exception("Máximo 50 carácteres para el nombre de la compañía");
                else
                    _nombre = value;
            }
        }
        public string Direccion
        {
            get { return _direccion; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("Debe saberse la dirección");
                else if (value.Length > 100)
                    throw new Exception("Máximo 100 carácteres para la dirección");
                else
                    _direccion = value;
            }
        }
        public int Tel
        {
            get { return _tel; }
            set
            {
                if (value <= 0 )
                    throw new Exception("Debe saberse el telefono");
                else
                    _tel = value;
            }
        }
        public Compañia (string pNombre, string pDireccion, int pTel)
        {
            Nombre = pNombre;
            Direccion = pDireccion;
            Tel = pTel;
        }
    }
}
