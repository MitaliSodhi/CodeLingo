
//  Fullname.cs  (c) 2003 Kari Laitinen

using System ;

class Fullname
{
   static void Main()
   {
      string  first_name ;
      string  last_name ;

      Console.Write( "\n Please, type in your first name: " ) ;
      first_name  =  Console.ReadLine() ;
      Console.Write( "\n Please, type in your last name:  " ) ;
      last_name   =  Console.ReadLine() ;

      Console.Write( "\n Your full name is "
                  +  first_name  +  " "  +  last_name  +  ".\n" ) ;
   }
}


