namespace E05_Date_Modifier
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class DateModifier
    {
        //private string firstDate;
        //private string secondDate;

        //public DateModifier(string firstDate, string secondDate)
        //{
        //    this.FirstDate = firstDate;
        //    this.SecondDate = secondDate;
        //}
        //public string FirstDate
        //{
        //    get { return this.firstDate; }
        //    set { this.firstDate = value; }
        //}

        //public string SecondDate
        //{
        //    get { return this.secondDate; }
        //    set { this.secondDate = value; }
        //}

        public int CalculateDifferenceOfDays(string firstDate,string secondDate)
        {
            var firstDateArgs = firstDate
                .Split()
                .Select(int.Parse)
                .ToArray();
            DateTime dateTimeFirst = new DateTime(firstDateArgs[0], firstDateArgs[1], firstDateArgs[2]);

            var secondDateArgs = secondDate
                .Split()
                .Select(int.Parse)
                .ToArray();
            DateTime dateTimeSecond = new DateTime(secondDateArgs[0], secondDateArgs[1], secondDateArgs[2]);

            return Math.Abs((dateTimeFirst - dateTimeSecond).Days);
        }
    }
}
