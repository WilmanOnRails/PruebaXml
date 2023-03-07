using PruebaXml;
using System.Xml.Linq;
using System.Text.RegularExpressions;



tarea:
Task.Run(async () =>
{
    Cliente C = new();

    var t = C.AsynchacerTarea();

    C.hacerTarea();

    bool f = await t;

}).GetAwaiter().GetResult();

switch (new Random().Next(0, 5))
{
    case 1: Console.WriteLine("ekisde"); break;
    case 2: Console.WriteLine("lmao"); goto case 1;
    case 3: Console.WriteLine("no se"); goto tarea;

    default:
        break;
}










static void xddd(Task t) => Console.WriteLine("xd");
static void metodopool(object o) => Console.WriteLine("estoy dentro del pool en la vuelta " + (int)o);
static void paralelo(int i) => Console.WriteLine(i);

// el threadpool crea una cantidad de hilos en dependencia de la tarea para lograr la mejor optimizacion
for (int i = 0; i < 50; i++)
    ThreadPool.QueueUserWorkItem(metodopool,i);


var taskCompleted = new TaskCompletionSource<bool>();

var hiloPrincipal = new Thread(() =>
{
    Console.WriteLine("xd");
    taskCompleted.SetResult(true);
} );
 
hiloPrincipal.Start();

// verificanado si el hilo termino su ejecucion
var start = taskCompleted.Task.Result;

// la siguiente task se ejecutara solo si el hilo termino su ejecucion 
var hilo = Task.Run(() =>
{
    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("Hilo 1");
        Thread.Sleep(1000);
    }
});

// esta task se ejecutara SOLO cuando el task anterior ha terminado
// el parametro es el metodo a ejecutar y ese metodo debe tomar como parametro un task
var hilo1 = hilo.ContinueWith(xddd);

// es igual al .join() de los hilos (este task es ejecutado sobre el resto hasta que termine su tarea)
hilo.Wait();
// las siguientes task esperan hasta que todos las task terminen su ejecucion
Task.WaitAll(hilo1);
// las siguientes task esperan hasta que alguno de los tas terminen su ejecucion
Task.WaitAny();


// ejecuta el metodo de manera iterada por una cantidad correspondiente de tasks
// el metodo que debe recibir un int o un long
Parallel.For(0,100,paralelo);




/*
Console.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataBaseUsers.xml"));
Console.WriteLine("ingrese el nombre");
string nombre = Console.ReadLine();
Console.WriteLine("ingrese el origen");
string origen = Console.ReadLine();


DataBase baseD = new();

baseD.AgegarCliente(nombre,origen);


baseD.CrearDocumento();
baseD.MostrarClientes();
baseD.asegurarArchivo();


xd compare = new xd((a,b) => a>b);
Console.WriteLine(compare(5,9));
Func<int,bool> esPrimo = (d) => d % 2 != 0;
Console.WriteLine(esPrimo(4));

List<string> l= new List<string>();
List<string> r= new List<string>();                 

l.Exists((d) => d == "kevin");

dynamic xd = from a in l join b in r on a
             equals b  where a == "paco" 
             select a;





Console.WriteLine(lol.suma(1,2,3) + $"este es el numero e={new lol().num}");
*/
public class lol
{

    double num = Math.E;
    public string elemao = "kkk";

    public static int suma(int n1, int n2) => n1 + n2;
    public static int suma(int n1, int n2, int n3 = 0) => n1 + n2 + n3;

}




delegate bool xd(int x,int y);





