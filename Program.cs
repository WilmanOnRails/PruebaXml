using PruebaXml;
using System.Xml.Linq;
using System.Text.RegularExpressions;

Productos p = new Productos();
p.productosPorDefecto();

// regex : (?<xdd>\w+:\\\w+)(?<xd>\\\w+)+\\\PruebaXml


//generarArchivo(p);
//Console.WriteLine(doc);

//Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
//Console.WriteLine(Directory.GetCurrentDirectory());

Regex r = new Regex(@"(?<path1>\w+:\\\w+)(?<path2>\\\w+)+(?<path3>\\PruebaXml)");

MatchCollection m = r.Matches(AppDomain.CurrentDomain.BaseDirectory);
GroupCollection g = null;
CaptureCollection c = null;
foreach (Match item in m)
{
    c = item.Groups[2].Captures;
    g = item.Groups;
}

string path = g["path1"].Value;

foreach (Capture item in c)
{
    path += item.Value;
}

path += g["path3"].Value;

Console.WriteLine(path);

//FileAttributes atributos = File.GetAttributes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"BaseProductos.xml"));
//File.SetAttributes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"BaseProductos.xml"),atributos | FileAttributes.Hidden );

//CargarArchivo();

// C:\Users\Wilman\source\repos\PruebaXml\bin\Debug\net6.0

static void generarArchivo(Productos pr)
{



    //esto solo es un comentario que no afecta en nada
    XDocument doc = new XDocument(new XComment("Lista_de_Productos"),
        //Este es el Root element (el que va de primero)
        new XElement("Productos",
        //usando linq para obtener los productos
        from produc in pr.obtenerProductos()
        select
        //creando elemento producto con su atributo
        new XElement("Producto", new XAttribute("Nombre_Producto", produc.Nombre),
        //creando elemento precio y el precio lo obtenemos de la clase
        new XElement("Precio", produc.Precio),
        //creando elemento cantidad y el precio lo obtenemos de la clase
        new XElement("Cantidad", produc.Cantidad)

        )));

    doc.Save(@"BaseProductos.xml");
}


static void CargarArchivo()
{
    //(?<xdd>\w+:\\\w+\\\w+)


    //Console.WriteLine(doc);
    Console.WriteLine("\nmateneme");
    //cargar el archivo

    var lol = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"BaseProductos.xml");
var path = @"BaseProductos.xml";
XDocument nose = XDocument.Load(lol);
   
//IEnumerable<string> productos = from produc in XDocument.Load(
//@"C:\Users\Wilman\source\repos\PruebaXml\BaseProductos.xml").Element("Productos")
//.Elements("Producto") select produc.Attribute("Nombre_Producto").Value;

IEnumerable<XElement> matenme = from productos in nose.Element("Productos").Elements("Producto")
                                where productos.Attribute("Nombre_Producto").Value == "Intel 12900k"
                                select productos;




foreach (var item in matenme)
{
    Console.WriteLine(item);
}

}
