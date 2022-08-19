using System;
using swed32;

namespace AssaultCubeCheat
{
    class Program
    {
        static void Main(string[] args)
        {

            swed lib = new swed();

            lib.GetProcess("ac_client");
            var baseaddr = lib.GetModuleBase(".exe");

            var ptrhealth = lib.ReadPointer(baseaddr, 0x017E0A8);
       //      var addrhealth = lib.ReadBytes(ptrhealth, 0xEC, 4);

            var ptrammos = lib.ReadPointer(baseaddr, 0x0195404);

            var ptrfrags = lib.ReadPointer(baseaddr, 0x017E0A8);

            var localplayerY = lib.ReadPointer(baseaddr, 0x0195404);
      //      var localplayerX = lib.ReadPointer(baseaddr, 0x018AC00); 2C

            Console.WriteLine("AssaultCubeCheat loaded! by Ficello.zip");

            var hax = Console.ReadLine();
            
            if(hax == "Fly")
            {       
                Console.WriteLine("Fly Enabled!");
                while(true)
                {
                    lib.WriteBytes(localplayerY, 0x30, BitConverter.GetBytes(1082130432));
                }
            } 
            if(hax == "Inf")
            {
                Console.WriteLine("Infinite stuff Enabled!");
                while (true)
                {
                    lib.WriteBytes(ptrfrags, 0x144, BitConverter.GetBytes(2000));
                    lib.WriteBytes(ptrammos, 0x140, BitConverter.GetBytes(2000));
                    lib.WriteBytes(ptrhealth, 0xEC, BitConverter.GetBytes(2000));
                }
            }
            if (hax == "all")
            {
                Console.WriteLine("Everythings is enabled!");
                while (true)
                {
                    lib.WriteBytes(localplayerY, 0x30, BitConverter.GetBytes(1082130432));
                    lib.WriteBytes(ptrfrags, 0x144, BitConverter.GetBytes(2000));
                    lib.WriteBytes(ptrammos, 0x140, BitConverter.GetBytes(2000));
                    lib.WriteBytes(ptrhealth, 0xEC, BitConverter.GetBytes(2000));
                }
            }
        }
    }
}
