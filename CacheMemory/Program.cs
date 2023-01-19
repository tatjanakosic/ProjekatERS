using DumpingBufferProject;
using ReaderProject;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WriterProject;

namespace CacheMemory
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        static void Main(string[] args)
        {

            DumpingBuffer db = new DumpingBuffer();
            Thread thread = new Thread(new ThreadStart(db.SendToHistorical));
            thread.Start();


            Writer writer = new Writer(db);

            Reader reader = new Reader(db.Historical);

            for (; ; ) 
            {
                Console.WriteLine("Unesi id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Unesi adresu: ");
                string adresa= Console.ReadLine();

                Console.WriteLine("Unesi mesec: ");
                string mesec = Console.ReadLine();

                Console.WriteLine("Unesi potrosnju: ");
                double potrosnja = double.Parse(Console.ReadLine());

                writer.SendData(id, potrosnja, adresa, mesec);

                db.On = true;
                db.CheckState();

                Console.WriteLine("Prikaz podataka? da/ne");
                string prikaz = Console.ReadLine();

                if(prikaz.ToLower().Equals("da"))
                {
                    Console.WriteLine("Citanje po kriterujumu?");
                    Console.WriteLine("1 - Po mesecu");
                    Console.WriteLine("2 - Po gradu");
                    Console.WriteLine("3 - Po korisniku");
                    Console.WriteLine("4 - Ispis svih");
                    string odgovor = Console.ReadLine();

                    switch (odgovor.ToLower())
                    {
                        case "1":
                            Console.WriteLine("Unesite naziv mesecu: ");
                            string mesecu = Console.ReadLine();
                            reader.WriteDataByMesec(mesecu);
                            break;
                        case "2":
                            Console.WriteLine("Unesite naziv grada: ");
                            string adresau = Console.ReadLine();
                            reader.WriteDataByAdresa(adresau);
                            break;
                        case "3":
                            Console.WriteLine("Unesite id korisnika: ");
                            int idu = int.Parse(Console.ReadLine());
                            reader.WriteDataById(idu);
                            break;
                        case "4":
                            reader.WriteAllData();
                            break;
                    }
                    db.On = false;
                }
            }
        }
    }
}
