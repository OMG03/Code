namespace Playground
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();

            list.Add(11);

            list.Add(12);

            Console.WriteLine(list[0] + list[1]);

            foreach (var item in list)
            {

                Console.WriteLine(item);
            }
        }
    }
}
