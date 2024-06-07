using System;
using System.Collections.Generic;


namespace Tp2AAT
{
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Tienda tienda = new Tienda();
            Producto producto1 = new Producto("Frutilla", 20, 50);
            Producto producto2 = new Producto("Banana", 35, 30);
            Producto producto3 = new Producto("Pera", 8, 55);
            Producto producto4 = new Producto("Durazno", 12, 40);
            tienda.AgregarProducto(producto1);
            tienda.AgregarProducto(producto2);
            tienda.AgregarProducto(producto3);
            tienda.AgregarProducto(producto4);
            Carrito carrito = new Carrito();
    
            while (true)
            {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Mostrar productos disponibles de la Tienda");
                Console.WriteLine("2. Agregar producto a la Tienda");
                Console.WriteLine("3. Eliminar producto de la Tienda");
                Console.WriteLine("4. Agregar producto al carrito");
                Console.WriteLine("5. Eliminar producto del carrito");
                Console.WriteLine("6. Mostrar productos en el carrito");
                Console.WriteLine("7. Cobrar compra");
                Console.WriteLine("8. Ver dinero en caja");
                Console.WriteLine("9. Salir");
    
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
    
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Productos disponibles:");
                        tienda.MostrarProductos();
                        break;
    
                    case "2":
                        Console.Write("Ingrese el nombre del nuevo producto: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese el costo del nuevo producto: ");
                        decimal costo = decimal.Parse(Console.ReadLine());
                        Console.Write("Ingrese el stock del nuevo producto: ");
                        int stock = int.Parse(Console.ReadLine());
                        Producto nuevoProducto = new Producto(nombre, costo, stock);
                        tienda.AgregarProducto(nuevoProducto);
                        break;
    
                    case "3":
                        Console.Write("Ingrese el nombre del producto a eliminar: ");
                        string nombreAEliminar = Console.ReadLine();
                        tienda.EliminarProducto(nombreAEliminar);
                        break;
    
                    case "4":
                    Console.WriteLine("Ingrese el nombre del producto que desea agregar al carrito: ");
                    string nombreProducto = Console.ReadLine();
    
                    Console.WriteLine("Ingrese la cantidad que desea comprar: ");
                    int cantidad;
                    if (!int.TryParse(Console.ReadLine(), out cantidad))
                    {
                        Console.WriteLine("La cantidad ingresada no es válida.");
                        break;
                    }
                    int flag=0;
                        foreach (var producto in tienda.productos)
                        {
                            if (producto.Nombre == nombreProducto)
                            {
                                carrito.AgregarProducto( producto, cantidad,tienda);
                                flag = 1;
                                break;
                            } 
                        }
                    if (flag==0) {
                            Console.WriteLine("Ese producto no esta disponible");
                            }
                        break;
    
    
    
                    case "5":
                        Console.WriteLine("Ingrese el nombre del producto que desea eliminar del carrito: ");
                        string nombreProductoEliminar = Console.ReadLine();
                        Console.WriteLine("Ingrese la cantidad que desea eliminar del carrito: ");
                        int cantidadEliminar = int.Parse(Console.ReadLine());
                    foreach ((Producto producto, int cantidadCarrito) in carrito.carritoProds)
                    {
                        if (producto.Nombre == nombreProductoEliminar)
                        {
                            carrito.EliminarProducto(producto, cantidadEliminar);
                            Console.WriteLine($"{cantidadEliminar} {producto.Nombre}(s) eliminado(s) del carrito.");
                            break;
                        }
                    }
    
                        break;
    
                    case "6":
                        carrito.MostrarProductos();
                        break;
    
                    case "7":
                    if (carrito.carritoProds.Count == 0){
                        Console.WriteLine("El carrito está vacío");
                    } else {
                        Console.WriteLine("Ingrese el monto de pago: ");
                        decimal montoPago = decimal.Parse(Console.ReadLine());
                        decimal vuelto = tienda.CobrarVenta(carrito, montoPago);
                        if (vuelto != -1)
                        {
                            Console.WriteLine($"Venta realizada. Vuelto: {vuelto}");
                        }
                    }
                    break;
    
                    case "8":
                        tienda.MostrarDineroEnCaja();
                       break;
                    case "9":
                        Console.WriteLine("¡Gracias por su visita!");
                        break;
                    default:    
                        Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                       return;
                }
            }
        }
    }
}