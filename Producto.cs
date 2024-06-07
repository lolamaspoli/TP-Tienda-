using System;
using System.Collections.Generic;
namespace Tp2AAT
{
    public class Producto
    {
        public string Nombre { get; }
        private decimal Costo { get; }
        public decimal PrecioVenta { get; }
        public int Stock { get; set; }

        public Producto(string nombre, decimal costo, int stock)
        {
            if (string.IsNullOrWhiteSpace(nombre) || costo <= 0)
            {
                throw new ArgumentException("Nombre y costo inválidos.");
            }

            Nombre = nombre;
            Costo = costo;
            PrecioVenta = costo * 1.3m;
            Stock = stock;
        }

        public override string ToString()
        {
            return $"{Nombre} - Precio: ${PrecioVenta} - Stock: {Stock}";
        }
    }

}