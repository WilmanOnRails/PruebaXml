using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaXml
{
    public class Productos
    {
        private int precio;
        private string nombre;
        private int cantidad;
        private List<Productos> listaProductos;
        public Productos(int precio,int cantidad,string nombre)
        {
            this.precio = precio;
            this.cantidad = cantidad;
            this.nombre = nombre;
            this.listaProductos = new List<Productos>();          
        }

        public int Precio { get { return precio; } }
        public string Nombre { get { return nombre; } }
        public int Cantidad { get { return cantidad; } }


        public void productosPorDefecto()
        {
            listaProductos.Add(new Productos(13, 5, "ryzen 3800x"));
            listaProductos.Add(new Productos(20, 13, "Rtx 4090"));
            listaProductos.Add(new Productos(36, 9, "ssd m.2 250gb"));
            listaProductos.Add(new Productos(99, 10, "Case gamer gigabyte"));
        }

        public Productos() { listaProductos = new List<Productos>(); }
        public Productos[] obtenerProductos()
        {
            return listaProductos.ToArray();
        }

    }
}
