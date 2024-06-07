using System;
using System.Collections.Generic;
namespace Tp2AAT
{

public class Tienda
{
    public List<Producto> productos = new List<Producto>();
    public decimal DineroEnCaja = 0;
    public void MostrarDineroEnCaja()
    {
        Console.WriteLine(DineroEnCaja);
    }
    public void AgregarProducto(Producto producto)
    {
        productos.Add(producto);
    }

    public void EliminarProducto(string nombre)
    {
        int indiceAEliminar = -1;
        for (int i = 0; i < productos.Count; i++)
        {
            if (productos[i].Nombre == nombre)
            {
                indiceAEliminar = i;
                break;
            }
        }

        if (indiceAEliminar != -1)
        {
            productos.RemoveAt(indiceAEliminar);
            Console.WriteLine($"Producto '{nombre}' eliminado.");
        }
        else
        {
            Console.WriteLine($"Producto '{nombre}' no encontrado.");
        }
    }

    public void MostrarProductos()
    {
        foreach (var producto in productos)
        {
            Console.WriteLine(producto);
        }
    }

    public bool VenderProducto(Producto producto, int cantidad)
    {
        if (productos.Contains(producto) && producto.Stock >= cantidad)
        {
            producto.Stock -= cantidad;
            return true;
        }
        else
        {
            Console.WriteLine("No hay suficiente stock disponible.");
            return false;
        }
    }

    public decimal CobrarVenta(Carrito carrito, decimal montoPago){
        decimal subtotal = carrito.CalcularSubtotal();
        if (montoPago >= subtotal)
        {
            decimal vuelto = montoPago - subtotal;
            DineroEnCaja += subtotal;

            foreach (var item in carrito.carritoProds){
                item.producto.Stock -= item.cantidad;
            }

            carrito.carritoProds.Clear();
            Console.WriteLine("Venta realizada.");
            return vuelto;
        }
        else{
            Console.WriteLine("El monto ingresado es insuficiente.");
            return -1;

        }
    }
}
}