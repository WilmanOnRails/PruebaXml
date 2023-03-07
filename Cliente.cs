using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaXml
{
    public class Cliente
    {
        private int id;

        [Obsolete("El apellido ya no es necesario en las nuevas versiones",true)]
        public string Apellido { get; set; }
       
        public int Id { get => id; }

        public string Name { get; set; }
        
        public string Origen { get; set; }

        

        private DataBase db;

        public Cliente() => id++;
  

        public async Task<bool> AsynchacerTarea()
        {

            Console.WriteLine("Empezar a hacer la tarea asincrona");


            int i = await getData();

            Console.WriteLine("Termino de hacer la tarea asincrona");
            return true;
        }

        public void hacerTarea()
        {
            Console.WriteLine("Empezar a hacer la tarea");
            Thread.Sleep(2000);
            Console.WriteLine("Termino de hacer la tarea");
        }

        private async Task<int> getData()
        {
            int j=0;



            Thread.Sleep(15000);

            for (int i = 0; i < 100; i++)
                j = i;

            return j;


        }

        //asignando valores de un producto mediante una referencia
        public static implicit operator Cliente(Productos p)
        {
            return new Cliente { id = p.Cantidad , Name = p.Nombre , Origen = p.Precio.ToString() };
        }


        public static Cliente operator +(Cliente c1, Productos c2)
        {
            c1 = new Cliente { id = c2.Cantidad, Name = c2.Nombre, Origen = c2.Precio.ToString() };
            return c1;
        }
        
    }



  
}
