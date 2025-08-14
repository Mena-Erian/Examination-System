using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentExamination_System
{
    [Flags]
    public enum AlertType
    {
        None = 1, Massege = 2, throwException = 4, boolean = 8
    }
    public static class Helper
    {
        public static TimeOnly GetTimeOnlyByMinutes(string Msg, bool isMainMsg = true, int minutes = 0)
        {
            if (minutes == 0) minutes = GetIntFromUser(Msg, isMainMsg);

            int hours = minutes / 60;
            minutes %= 60;

            return new TimeOnly(hours, minutes);
        }
        public static TEnum GetFromUserByType<TEnum>(string? MsgToUser, bool isMainMsg = true) where TEnum : Enum
            => (TEnum)Enum.ToObject(typeof(TEnum), GetIntFromUser(MsgToUser, isMainMsg));

        public static IFormatProvider DefaultformatProvider = CultureInfo.CurrentCulture;
        public static List<T> GetArrFormUser<T>(string dataName, int arrSize,
                    IFormatProvider? formatProvider, char[]? seperators = null) where T : IParsable<T>
        {

            List<T> arr = new List<T>(arrSize);
            Console.Write($"Please Enter {dataName}: ");

            bool isValidInput = false;
            string userinput;
            string[] splitTheInputUser;
            do
            {
                userinput = Console.ReadLine() ?? "";//"3 3 "
                splitTheInputUser = userinput.Split(seperators ?? [' '], StringSplitOptions.RemoveEmptyEntries);
                if (splitTheInputUser.Length != arrSize) Console.Write("Count of Array is not true Please Try Again: ");
                else isValidInput = true;
            }
            while (!isValidInput);


            for (int i = 0; i < splitTheInputUser.Length; i++)
            {
                isValidInput = T.TryParse(splitTheInputUser[i], formatProvider, out T value);
                if (!isValidInput || value is null) throw new Exception("YOUR INPUT is NOT VALID");
                arr.Add(value);
            }

            return arr;
        }
        public static List<T> GetArrFormUser<T>(int arrSize,
            IFormatProvider? formatProvider) where T : IParsable<T>
        {

            List<T> arr = new List<T>(arrSize);

            bool isValidInput = false;
            string userinput;
            string[] splitTheInputUser;
            do
            {
                userinput = Console.ReadLine() ?? "";//"3 3 "
                splitTheInputUser = userinput.Split(" ");
                if (splitTheInputUser.Length != arrSize) Console.WriteLine("Your Input is Not Valid");
                else isValidInput = true;
            }
            while (!isValidInput);


            for (int i = 0; i < splitTheInputUser.Length; i++)
            {
                isValidInput = T.TryParse(splitTheInputUser[i], formatProvider, out T value);
                if (!isValidInput || value is null) throw new Exception("YOUR INPUT is NOT VALID");
                arr.Add(value);
            }

            return arr;
        }
        public static List<T> GetArrFormUser<T>(int arrSize, AlertType @alertType,
            IFormatProvider? formatProvider) where T : IParsable<T>
        {
            List<T> arr = new List<T>(arrSize);

            bool isValidInput = false;
            string userinput;
            string[] splitTheInputUser;
            switch (alertType)
            {
                /// I Should Handle another cases but i don't have time,
                /// i will make it later (becouse this not requrment task) Thanks:)
                case (AlertType)6:
                    //Massege and Throw Exception
                    do
                    {
                        userinput = Console.ReadLine() ?? "";//"3 3 "
                        splitTheInputUser = userinput.Split(" ");
                        if (splitTheInputUser.Length != arrSize) Console.WriteLine("Your Input is Not Valid");
                        else isValidInput = true;
                    }
                    while (!isValidInput);
                    for (int i = 0; i < splitTheInputUser.Length; i++)
                    {
                        isValidInput = T.TryParse(splitTheInputUser[i], formatProvider, out T value);
                        if (!isValidInput || value is null) throw new Exception("YOUR INPUT is NOT VALID");
                        else arr.Add(value);
                    }
                    break;
                case AlertType.boolean:
                    do
                    {
                        userinput = Console.ReadLine() ?? "";//"3 3 "
                        splitTheInputUser = userinput.Split(" ");
                        if (splitTheInputUser.Length != arrSize) Console.WriteLine("NO");
                        else isValidInput = true;
                    }
                    while (!isValidInput);
                    for (int i = 0; i < splitTheInputUser.Length; i++)
                    {
                        isValidInput = T.TryParse(splitTheInputUser[i], formatProvider, out T? value);
                        if (!isValidInput || value is null)
                        {
                            Console.WriteLine("NO");
                            break;
                        }
                        else arr.Add(value);
                    }
                    if (isValidInput && splitTheInputUser.Length == arrSize) Console.Write("YES");
                    break;
                default:
                    goto case (AlertType)6;
            }
            return arr;
        }

        public static int GetIntFromUser(string? massageToUser, bool isMainMsg = true)
        {
            int number = 0;
            if (massageToUser != null)
            {
                switch (isMainMsg)
                {
                    case true:
                        do
                        {
                            Console.Write(massageToUser);
                        }
                        while (!int.TryParse(Console.ReadLine(), out number));
                        break;
                    case false:
                        do
                        {
                            Console.Write($"Please Enter {massageToUser}: ");
                        }
                        while (!int.TryParse(Console.ReadLine(), out number));
                        break;
                }
            }
            else
            {
                do
                {

                }
                while (!int.TryParse(Console.ReadLine(), out number));
            }

            return number;
        }
        public static decimal GetDecimalFromUser(string massageToUser, bool isMainMsg = true)
        {
            decimal number = 0;
            switch (isMainMsg)
            {
                case true:
                    do
                    {
                        Console.Write(massageToUser);
                    }
                    while (!decimal.TryParse(Console.ReadLine(), out number));
                    break;
                case false:
                    do
                    {
                        Console.WriteLine($"Please Enter the {massageToUser}: ");
                    }
                    while (!decimal.TryParse(Console.ReadLine(), out number));
                    break;
            }

            return number;
        }
        public static string GetStringFromUser(string dataName)
        {
            string str = string.Empty;
            do
            {
                Console.Write($"Please Enter {dataName}: ");
                str = Console.ReadLine() ?? string.Empty;
            }
            while (str == string.Empty || int.TryParse(str, out _));

            return str;
        }
        public static void Print<T>(this T value) => Console.WriteLine(value);
        public static void Print<T>(this IEnumerable<T> values) where T : IEnumerable
        {
            foreach (T item in values) Console.WriteLine(item);
        }
        public static void PrintAll<T>(this ICollection<T> values)
        {
            foreach (T item in values) Console.WriteLine(item);
        }
        public static void PrintAll<T>(this ICollection values)
        {
            foreach (T item in values) Console.WriteLine(item);
        }
        public static void PrintAllArray<T>(this ICollection<T> values)
        {
            Console.Write("[");
            foreach (T item in values) Console.Write($"{item}, ");
            Console.Write("]");
        }


    }
}
