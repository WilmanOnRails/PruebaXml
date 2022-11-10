using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaXml
{
    public class BaseDeDatos
    {
        private List<Productos> listaProductos;

        public BaseDeDatos()
        {
            listaProductos = new List<Productos>();
        }

        public void agregarProductos(Productos p)
        {
            listaProductos.Add(p);
        }

        public Productos[] obtenerProductos()
        {
            return listaProductos.ToArray();
        }

        public void productosPorDefecto()
        {
            listaProductos.Add(new Productos(13, 5, "ryzen 3800x"));
            listaProductos.Add(new Productos(20, 13, "Rtx 4090"));
            listaProductos.Add(new Productos(36, 9, "ssd m.2 250gb"));
            listaProductos.Add(new Productos(99, 10, "Case gamer gigabyte"));
        }

    }
}
