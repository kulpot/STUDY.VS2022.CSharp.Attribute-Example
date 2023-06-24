//ref link:https://www.youtube.com/watch?v=gcpcyEZb-GM&list=PLRwVmtr-pp05brRDYXh-OTAIi-9kYcw3r&index=4
// Attribute Example

/*
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.Common;


[Serializable]
class Cow
{
    public string Name;
    public int Weight;
}

class MainClass
{
    static void Main()
    {
        var betsy = new Cow { Name = "Betsy", Weight = 500 };
        var formatter = new BinaryFormatter();
        var memoryStream = new MemoryStream();
        formatter.Serialize(memoryStream, betsy); //[Serializable]
        memoryStream.Seek(0, SeekOrigin.Begin); // rewind 
        var betsysClone = formatter.Deserialize(memoryStream) as Cow;
        Console.WriteLine(betsysClone.Name);
        Console.WriteLine(betsysClone.Weight);
    }
}*/

/*
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

class MeContext : DbContext
{
    public DbSet<Person> People { get; set; }
}

[Table("MeDatabse")] // Attribte for database table
class Person
{
    public int ID { get; set; }
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

class MainClass
{
    static void Main()
    {
        var db=new MeContext();
        foreach(var peron in db.People)
            Console.WriteLine(person.FirstName);
    }
}*/

using System;
using System.ServiceModel;

[ServiceContract] // attribute WCF
interface ICow
{
    //[OperationContract]
    void Moo();
    [OperationContract]
    void Goo();
}

class MeCow : ICow
{
    public void Moo()
    {
        Console.WriteLine("Moooooooooooooo");
    }
    public void Goo()
    {

    }
}

class MainClass
{
    static void Main()
    {
        var host = new ServiceHost(typeof(MeCow));
        host.AddServiceEndpoint(typeof(ICow), new WSHttpBinding(), "http://localhost:1234");
        host.Open();

        // At some other end of the globe:
        var cow = ChannelFactory<ICow>.CreateChannel(new WSHttpBinding(), new EndpointAddress("http://localhost:1234"));
        cow.Moo();
    }
}