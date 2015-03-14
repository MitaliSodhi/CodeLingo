
//  Marilyn.cs (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  04.06.2003  C# file created.
//  06.07.2004  Last modification

using System ;

class Marilyn
{
   static void Main()
   {
      string  name_to_be_known  =  "Marilyn Monroe" ;

      Console.Write( "\n Who played the main role in the movies:"
                  +  "\n\n   \"How To Marry a Millionaire\" (1953)"
                    +  "\n   \"The Seven Year Itch\" (1955)"
                    +  "\n   \"The Misfits\" (1961) \n\n   ? " ) ;

      string  name_from_keyboard  =  Console.ReadLine() ;

      if ( String.Compare( name_from_keyboard,
                           name_to_be_known ) == 0 )
      {
         Console.Write( "\n   Yes, that is correct.\n" ) ;
      }
      else
      {
         Console.Write( "\n   No, it\'s Marilyn Monroe.\n" ) ;
      }
   }
}



