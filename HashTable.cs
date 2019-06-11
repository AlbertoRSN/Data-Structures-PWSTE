using System;
class hashTable
{
  public const int sizeOfArr = 97;
  
  static void Main ()
  {

    string[]hashed = new string[sizeOfArr];
    string name;
    string[] cities = new string[]
    {
    "Berlin", "London", "Rome", "Madrid", "Chicago", "Venice",
	"Warsow", "Paris", "Oslo", "New York", "Marsilia"};//, "Barcelona", "Jaroslaw"};
    int hashVal;
    for (int i = 0; i < 11; i++)
      {
	    name = cities[i];
	    //hashVal = SimpleHash(name, hashed);
	    hashVal = SimpleHash2(name);
	    hashed[hashVal] = name;
	    //Console.WriteLine(SimpleHash2(name));
      }
      
    
    PrintOut (hashed);
  }
  
  static int SimpleHash (string s, string[]arr)
  {
    int tot = 0;
    char[] cname;
    cname = s.ToCharArray ();
    for (int i = 0; i <= cname.GetUpperBound (0); i++)
      tot += (int) cname[i];
    return tot % arr.GetUpperBound (0);
  }
  
  static int SimpleHash2(string s)
  {
      int tot = 0;
      Random rnd = new Random();
      int num = rnd.Next(1, 100);  // creates a number between 1 and 100
      int sum = rnd.Next(1,10);
      
      tot = (int)s[0] * num;
      
      if(tot % 2 == 0){
          tot += sum;
      }
      
      if(tot => sizeOfArr){
          tot -= sum;
      }
      
      return tot % sizeOfArr;
  }
  static void PrintOut (string[]arr)
  {
    for (int i = 0; i <= arr.GetUpperBound (0); i++)
      if (arr[i] != null)
	    Console.WriteLine (i + " " + arr[i]);
  }


}

// https://www.geeksforgeeks.org/hashing-set-1-introduction/
//https://docs.microsoft.com/en-us/dotnet/api/system.collections.hashtable?view=netframework-4.8








