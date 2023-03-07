using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace PruebaXml
{
   [Serializable] public class DataBase
    {

        private List<Cliente> listaClientes = new List<Cliente>();
        private static List<Productos> listaProductos;

        static DataBase()
        {
            listaProductos = new();
        }

        public void CrearDocumento()
        {
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataBaseUsers.xml")))
            {
                XDocument documento = new(new XComment("DataBase of Clients"), 
                    new XElement("Clientes",from cliente in listaClientes.ToArray()

                    select new XElement("Cliente", 
                    new XAttribute("IdCliente", cliente.Id),
                    new XElement("Nombre", cliente.Name),
                    new XElement("Origen", cliente.Origen))));

                documento.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataBaseUsers.xml"));
                return;
            }

            Console.WriteLine("el documento ya existe");
            editarDocumento();
        }

        public void AgegarCliente(string nombre, string origen)
        {
            listaClientes.Add(new() { Name=nombre ,Origen=origen});
        }


        private void editarDocumento()
        {
            XDocument edit = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataBaseUsers.xml"));
            /* Editar de esta manera sin incrementar el Id del cliente (siempre sera 1 el id)
            edit.Element("Clientes").Add(from cliente in listaClientes.ToArray() select new 
                    XElement("Cliente", new XAttribute("IdCliente", cliente.Id),
                    new XElement("Nombre", cliente.Name),
                    new XElement("Origen", cliente.Origen)));
            */

            int tamaño = edit.Element("Clientes").Elements("Cliente").Count();

            edit.Element("Clientes").Elements("Cliente").Where
                (x => (int)x.Attribute("IdCliente") == tamaño).FirstOrDefault().
                AddAfterSelf(from cliente in listaClientes.ToArray() select new
                    XElement("Cliente", new XAttribute("IdCliente", tamaño+1),
                    new XElement("Nombre", cliente.Name),
                    new XElement("Origen", cliente.Origen)));
            
                
            edit.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataBaseUsers.xml"));
        }

        public void MostrarClientes()
        {
            var clientes = from cliente in XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataBaseUsers.xml")).
                           Descendants("Cliente")
                           select cliente;

            foreach (var item in clientes)
             Console.WriteLine($"nombre del cliente: {item.Element("Nombre").Value}, id del cliente: {item.Attribute("IdCliente").Value} , lugar de origen: {item.Element("Origen").Value}" );
        }


        public void asegurarArchivo()
        {
            Console.WriteLine("encriptando...");
            //  File.SetAttributes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataBaseUsers.xml"),  FileAttributes.Hidden);

            Productos p = new Productos(12, 10, "wilman");

            Cliente c = p;

            // esto da error --->   c.Apellido = "lul";

            var sth = getTupla("Hola", p); 

    

            File.Encrypt(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataBaseUsers.xml"));
        }

        public void reflectClient(Cliente c)
        {
            var reflectedClient = typeof(Cliente).GetProperties();

            foreach (var item in reflectedClient)
            {
                Console.WriteLine($"Nombre: {item.Name}, tipo: {item.GetType().ToString()}," +
                    $" valor: {item.GetValue(c)?.ToString()}");
                Console.WriteLine($"es mayor {longitudCaracteres(item.Name)}");
            }

        }

        private string longitudCaracteres(string name) => name.Length switch
        {
            > 0 and <= 1 => "un caracter",
            > 1 and <= 10 => "longitud normal",
            > 10 and <= 15 => "Grande",
            > 15 => "ENORME",
            _ => ""
        };
        

        public (Action<string> print,Action<Productos> increment) getTupla(string s,Productos p)
        {
            

            Action<string> a = s => Console.WriteLine(s);
            Action<Productos> pe = p => listaProductos.Add(p);
            return (a,pe);
        }
    }
}
