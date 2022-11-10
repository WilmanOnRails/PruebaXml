using PruebaXml;
using System.Xml.Linq;

Productos p = new Productos();
p.productosPorDefecto();


                    //esto solo es un comentario que no afecta en nada
XDocument doc = new XDocument(new XComment("Lista_de_Productos"),
    //Este es el Root element (el que va de primero)
    new XElement("Productos",
    //usando linq para obtener los productos
    from produc in p.obtenerProductos()
    select
    //creando elemento producto con su atributo
    new XElement("Producto", new XAttribute("Nombre_Producto", produc.Nombre),
    //creando elemento precio y el precio lo obtenemos de la clase
    new XElement("Precio", produc.Precio),
    //creando elemento cantidad y el precio lo obtenemos de la clase
    new XElement("Cantidad", produc.Cantidad)

    )));

doc.Save(Path.Combine(Directory.GetCurrentDirectory(), "BaseProductoass.xml"));
Console.WriteLine(doc);

/*
//Console.WriteLine(doc);
Console.WriteLine("\nmateneme");
//cargar el archivo

var path =  @"BaseProductos.xml";
XDocument nose = XDocument.Load(path);

//IEnumerable<string> productos = from produc in XDocument.Load(
//@"C:\Users\Wilman\source\repos\PruebaXml\BaseProductos.xml").Element("Productos")
//.Elements("Producto") select produc.Attribute("Nombre_Producto").Value;

IEnumerable<XElement> matenme = from productos in nose.Element("Productos").Elements("Producto")
                                select productos;


foreach (var item in matenme)
{
    Console.WriteLine(item.Element("Precio").Value);
}
*/