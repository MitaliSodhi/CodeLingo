
//  MarilynSolution_8_7.cs (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-31  File created.
//  2004-10-31  Last modification.

using System ;

class MarilynSolution_8_7
{
   static void Main()
   {
      string  name_to_be_known  =  "Marilyn Monroe" ;

      Console.Write( "\n Who played the main role in the movies:"
                  +  "\n\n   \"How To Marry a Millionaire\" (1953)"
                    +  "\n   \"The Seven Year Itch\" (1955)"
                    +  "\n   \"The Misfits\" (1961) \n\n   ? " ) ;

      string  name_from_keyboard  =  Console.ReadLine() ;

      name_to_be_known    =  name_to_be_known.ToLower() ;
      name_from_keyboard  =  name_from_keyboard.ToLower() ;

      if ( name_to_be_known.IndexOf( name_from_keyboard )  !=  -1 )
      {
         Console.Write( "\n   Yes, that is correct.\n" ) ;
      }
      else
      {
         Console.Write( "\n   No, it\'s Marilyn Monroe.\n" ) ;
      }
   }
}



