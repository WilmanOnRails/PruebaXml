using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace PruebaXml
{
    public class DataBase
    {

        private List<Cliente> listaClientes = new List<Cliente>();

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

            
            File.Encrypt(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataBaseUsers.xml"));
        }
    }
}
