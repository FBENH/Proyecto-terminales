using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Entidades_Compartidas
{
    public class Empleado
    {
        private string _usuario;
        private string _pass;
        private string _nomCompleto;

        public string Usuario
        {
            get { return _usuario; }
            set
            {
                if (value.Trim().Length != 8)
                    throw new Exception("Ingresa exactamente 8 caracteres");
                else
                    _usuario = value;
            }
        }
        public string Pass
        {
            get { return _pass; }
            set
            {
                if (!Regex.IsMatch(value, @"^(?=(.*[a-z]){3})(?=(.*\d){3})[a-z0-9]{6}$"))    //3 letras y 3 numeros en cualquier orden
                {
                    throw new Exception("La contraseña debe estar compuesta por 3 letras y 3 números");
                }

                else
                {
                    _pass = value;
                }

        }
        }
        public string NomCompleto
        {
            get { return _nomCompleto; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("Debe saberse el Nombre Completo");
                else if (value.Length > 30)
                    throw new Exception("Máximo 30 carácteres para el nombre completo.");
                else
                    _nomCompleto = value;
            }
        }

        public Empleado(string pPass, string pUsuario, string pNomCompleto)
        {
            Pass = pPass;
            Usuario = pUsuario;
            NomCompleto = pNomCompleto;
        }
    }
}
