using System;
class hashTable
{
    static void Main()
    {

        string[] hashed = new string[101];
        string name;
        string[] cities = new string[]{"Berlin",
        "London", "Rome", "Madrid", "Chicago", "Venice",
        "Warsow", "Paris", "Oslo", "New York", "Jaroslaw", "Rzeszow", "Przemysl"};
        int hashVal;
        
        for (int i = 0; i < cities.Length; i++)
        {
            name = cities[i];
            hashVal = SimpleHash(name, hashed);
            hashed[hashVal] = name;
        }
        PrintOut(hashed);
               
        /*
        for (int i = 0; i < cities.Length; i++)
        {
            name = cities[i];
            hashVal = BetterHash(name, hashed);
            hashed[hashVal] = name;
        }
        PrintOut(hashed);
        */

        String lookFor = "Berlin";

        if (InHash(lookFor, hashed))
            Console.WriteLine(lookFor + " found! ");
        else Console.WriteLine(lookFor + " NOT found! ");

    } //main
    static int SimpleHash(string s, string[] arr)
    {
        int tot = 0;
        char[] cname;
        cname = s.ToCharArray();
        for (int i = 0; i <= cname.GetUpperBound(0); i++)
            tot += (int)cname[i];
        return tot % arr.GetUpperBound(0);
    }

    //Horner’s rule to computer the polynomial function(of 37)
    static int BetterHash(string s, string[] arr)   
    {
        long tot = 0;
        char[] cname;
        cname = s.ToCharArray();
        for (int i = 0; i <= cname.GetUpperBound(0); i++)
            tot += 37 * tot + (int)cname[i];
        tot = tot % arr.GetUpperBound(0);
        if (tot < 0)
            tot += arr.GetUpperBound(0);
        return (int)tot;
    }


    static bool InHash(string s, string[] arr)
    {
        int hval = BetterHash(s, arr);
        if (arr[hval] == s)
            return true;
        else
            return false;
    }

    static void PrintOut(string[] arr)
    {
        int j = 1;
        for (int i = 0; i <= arr.GetUpperBound(0); i++)
            if (arr[i] != null)
                Console.WriteLine(i + " " + arr[i] + " -> " + j++);
    }


}



