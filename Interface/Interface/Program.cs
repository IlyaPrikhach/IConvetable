using System;

namespace Interface
{
    class Program
    {
        static ProgramHelper p1 = new ProgramHelper();
        static ProgramConverter p2 = new ProgramHelper();
        static ProgramConverter p3 = new ProgramConverter();
        static ProgramConverter p4 = new ProgramConverter();


        static void Main()
        {

            string lan = "";
            string code = "";
            try
            {
                Console.WriteLine("Введите язык: (CSharp/VB)");
                lan = Console.ReadLine();
                if (lan != "CSharp" && lan != "VB")
                {
                    Console.WriteLine("Возможно вы ввели неверный язык, попробуйте снова");
                    Main();
                }
                Console.WriteLine("Введите команду кода");
                code = Console.ReadLine();
                
            }
            catch
            {
                Console.WriteLine("Возможно вы ввели данные неверно, попробуйте снова");
                Main();
            }

            object[] mass = new object[4];
            mass[0] = p1;
            mass[1] = p2;
            mass[2] = p3;
            mass[3] = p4;
            for (int i = 0; i < mass.Length; i++)
            {
                ProgramHelper pp = mass[i] as ProgramHelper;
                ProgramConverter pv = mass[i] as ProgramConverter;
                if(mass[i] is ICodeChecker)
                {
                    Console.WriteLine("Реализуется");
                    if(check(lan, code, pp) == true)
                    {
                        convert(lan, code, pp);
                    }
                    Console.WriteLine("\n-------------------------------------------");
                }
                else
                {
                    Console.WriteLine("Не реализуется");
                    pv.ConvertToCSharp(lan, code);
                    pv.ConvertToVB(lan, code);
                    Console.WriteLine("\n-------------------------------------------");
                }

            }

            Console.ReadLine();
        }



        static bool check(string lan, string code, ProgramHelper pp)
        {
            bool x = pp.CheckCodeSyntax(lan, code);
            Console.WriteLine(x);
            return x;
        }

        static void convert(string lan, string code, ProgramHelper pp)
        {

            if(lan == "VB")
            {
                pp.ConvertToCSharp(lan, code);
            }
            if (lan == "CSharp")
            {
                p1.ConvertToVB(lan, code);
            }
        }
    }

    interface ICodeChecker
    {
        bool CheckCodeSyntax(string lan, string code);
    }
    interface IConvertible
    {
        void ConvertToCSharp(string lan, string code);
        void ConvertToVB(string lan, string code);
    }

    class ProgramConverter : IConvertible
    {
        public void ConvertToCSharp(string lan, string code)
        {
            Console.WriteLine("Код конвертирован в CSharp");
        }
        public void ConvertToVB(string lan, string code)
        {
            Console.WriteLine("Код конвертирован в VB");
        }
    }

    class ProgramHelper : ProgramConverter, ICodeChecker
    {
        public bool CheckCodeSyntax(string lan, string code)
        {
            bool result;
            if(code.Contains("using") && lan == "CSharp")
            {
                result = true;
            }
            else if (code.Contains("Module") && lan == "VB")
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}

