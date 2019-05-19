namespace E05_Date_Modifier
{
    using System;

    class StartUp
    {
        static void Main()
        {
            var date1 = Console.ReadLine();
            var date2 = Console.ReadLine();

            var dateModifier = new DateModifier();

            var difference = dateModifier.CalculateDifferenceOfDays(date1, date2);
            Console.WriteLine(difference);
        }
    }
}
