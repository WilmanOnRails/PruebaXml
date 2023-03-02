using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaXml
{
    public class Cliente
    {
        private static int id;

        public int Id { get => id; }

        public string Name { get; set; }
        
        public string Origen { get; set; }

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
        
    }



  
}
