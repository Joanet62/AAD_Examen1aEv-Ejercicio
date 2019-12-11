using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apuestas.Models
{
    public class Cuentas
    {
        public Cuentas(int iD, string numcuenta, string banco, decimal saldoactual, int idusuario)
        {
            ID = iD;
            this.numcuenta = numcuenta;
            this.banco = banco;
            this.saldoactual = saldoactual;
            this.idusuario = idusuario;
            
        }
        public Cuentas()
        {

        }

        [Key]
        public int ID { get; set; }
        public string numcuenta { get; set; }
        public string banco { get; set; }
        public decimal saldoactual { get; set; }
        //depediente uno a uno primero se generar la tabla usuario, despues la de cuenta...
        public int idusuario { get; set; }
        public Login Usuario { get; set; }
    }
}