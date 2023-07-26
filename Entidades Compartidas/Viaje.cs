using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_Compartidas
{
    public class Viaje
    {
        private int _codigo;
        private DateTime _fechaHoraP;
        private DateTime _fechaHoraD;
        private int _maxPasajeros;
        private decimal _precio;
        private int _anden;
        Empleado _unEmp;
        Compañia _unaComp;
        List<PasaPor> _coleccion;

        public int Codigo //autogenerado por eso no tiene código defensivo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public DateTime FechaHoraP
        {
            get { return _fechaHoraP; }
            set { _fechaHoraP = value;}
        }
        public DateTime FechaHoraD
        {
            get { return _fechaHoraD; }
            set
            {
                if (value < _fechaHoraP)
                   throw new Exception("La fecha de llegada debe ser mayor a la fecha de partida");                    
                else
                   _fechaHoraD = value;               
            } 
        }
        public int MaxPasajeros
        {
            get { return _maxPasajeros; }
            set
            {
                if (value >= 1 && value <= 50)
                    _maxPasajeros = value;
                else
                    throw new Exception("Pasajeros entre 1-50");
            }
        }
        public decimal Precio
        {
            get { return _precio; }
            set
            {
                if (value > 0)
                    _precio = value;
                else
                    throw new Exception("Precio debe ser mayor a 0");
            }
        }
        public int Anden
        {
            get { return _anden; }
            set
            {
                if (value >= 1 && value <= 35)
                    _anden = value;
                else
                    throw new Exception("Anden entre 1-35");
            }
        }
        public Empleado UnEmp
        {
            set
            {
                if (value != null)
                    _unEmp = value;
                else
                    throw new Exception("Falta Empleado");
            }
            get { return _unEmp; }
        }
        public Compañia UnaComp
        {
            set
            {
                if (value != null)
                    _unaComp = value;
                else
                    throw new Exception("Falta Compañia");
            }
            get { return _unaComp; }
        }
        public List<PasaPor> Coleccion
        {
            get { return _coleccion; }
            set
            {
                if (value == null)
                    throw new Exception("Error, no existe colección");
                if (value.Count == 0)
                    throw new Exception("No hay Terminales asociadas a este viaje");

                _coleccion = value;
            }
        }
        public Viaje(int pCodigo, DateTime pFechaHoraP, DateTime pFechaHoraD,
                int pMaxPasajeros, decimal pPrecio, int pAnden, List<PasaPor> pColeccion, Empleado pUnEmp, Compañia pUnaComp)
        {
            Codigo = pCodigo;
            FechaHoraP = pFechaHoraP;
            FechaHoraD = pFechaHoraD;
            MaxPasajeros = pMaxPasajeros;
            Precio = pPrecio;
            Anden = pAnden;
            Coleccion = pColeccion;
            UnEmp = pUnEmp;
            UnaComp = pUnaComp;
        }
    }
}
