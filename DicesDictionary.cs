
// C# code to create a Dictionary 
using System; 
using System.Collections.Generic; 
  
class Program { 
    
    static int SimpleHash (string s, string[]arr)
    {
        int tot = 0;
        char[] cname;
        cname = s.ToCharArray ();
        for (int i = 0; i <= cname.GetUpperBound (0); i++)
            tot += (int) cname[i];
            
        return tot % arr.GetUpperBound (0);
  }
  
    // Driver code 
    public static void Main() 
    { 
        
        int numberOfThrows = 1000;
        Random rnd = new Random();
        int result1, result2, result;

        int[] dices = new int[13];
        
        for(int i=2; i<=12; i++){
            dices[i] = 0;
        }
        
        for(int i=0; i<numberOfThrows; i++){
            result1 = rnd.Next(1,7);
            result2 = rnd.Next(1,7);
            result = result1 + result2;
            dices[result]++;
        }
        
        for(int i=0; i<=12; i++){
            Console.WriteLine(i + " - " + dices[i] + " ");
        }
        
        
        /*
        // To get count of key/value pairs in myDict 
        Console.WriteLine("Total key/value pairs"+ 
              " in dices are : " + dices.Count); 
  
        // Displaying the key/value pairs in myDict 
        Console.WriteLine("\nThe key/value pairs"+ 
                           " in dices are : "); 
  
        foreach(KeyValuePair<int, int> kvp in dices) 
        { 
            Console.WriteLine("Key = {0,2}, \tValue = {1,2}", 
                              kvp.Key, kvp.Value); 
        } */
    }  
} 

