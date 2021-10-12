using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a Password!");
            string pass = Console.ReadLine();
            while (pass != "ACHILLESBG88")
            {
                 Console.WriteLine("wrong password\n\n Enter a CORRECT Password!!!!!!!");
                pass = Console.ReadLine();
            }
            Console.WriteLine("bravo\ntu as trouvé le mot de passe");
        }
    }
}