using System;
using System.Collections.Generic;

namespace Tp2AAT

{
    public class Carrito
      {
          public List<(Producto producto, int cantidad)> carritoProds = new List<(Producto producto, int cantidad)>();

          public void AgregarProducto(Producto producto, int cantidad, Tienda tienda)
          {
              if (producto.Stock < cantidad)
              {
                  Console.WriteLine("No hay suficiente stock disponible.");
                  return;
              }

              bool productoExistente = false;
              for (int i = 0; i < carritoProds.Count; i++)
              {
                  if (carritoProds[i].producto.Nombre == producto.Nombre)
                  {
                      Console.WriteLine($"{cantidad} {producto.Nombre}(s) agregado(s) al carrito.");
                    carritoProds[i] = (carritoProds[i].producto, carritoProds[i].cantidad + cantidad);
                      productoExistente = true;
                      break;
                  }
              }

              if (!productoExistente)
              {
                  carritoProds.Add((producto, cantidad));
              }
          }

        public void EliminarProducto(Producto producto, int cantidad)
        {
            for (int i = 0; i < carritoProds.Count; i++)
            {
                if (carritoProds[i].producto == producto)
                {
                    if (cantidad >= carritoProds[i].cantidad)
                    {
                        carritoProds.RemoveAt(i);
                    }
                    else
                    {
                        carritoProds[i] = (carritoProds[i].producto, carritoProds[i].cantidad - cantidad);
                    }
                    break;
                }
            }
        }
              public decimal CalcularSubtotal()
              {
                  decimal subtotal = 0;
                  foreach (var item in carritoProds)
                  {
                      subtotal += item.producto.PrecioVenta * item.cantidad;
                  }
                  return subtotal;
              }

        public void MostrarProductos()
        {
            if (carritoProds.Count != 0){
                foreach ((Producto productoCarrito, int cantidad) in carritoProds)
                {
                Console.WriteLine($"Producto: {productoCarrito.Nombre}, Cantidad: {cantidad}");
                }
            } else
            { Console.WriteLine("No hay productos en el carrito.");

            }
        }
    }

}