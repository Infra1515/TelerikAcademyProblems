using System;

class ExceptionsProperties
{
    static void Main()
    {
        try
        {
            CauseFormatException();
        }
        catch (FormatException fe)
        {
            Console.Error.WriteLine("Exception caught: {0}", fe);
            Console.Error.WriteLine("\r\nMessage: {0}", fe.Message);
            Console.Error.WriteLine("\r\nStack Trace: {0}", fe.StackTrace);
        }
    }

    public static void CauseFormatException()
    {
        string s = "an invalid number";
        int.Parse(s);
    }
}
