
//  MiscellaneousArrayList.cs (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  Compile: csc MiscellaneousArrayList.cs Date.cs

using System ;
using System.Collections ;

class MiscellaneousArrayList
{
   static void Main()
   {
      ArrayList  miscellaneous_objects  =  new  ArrayList() ;

      miscellaneous_objects.Add( 555 ) ;
      miscellaneous_objects.Add( 66.77 ) ;
      miscellaneous_objects.Add( "This is a string literal." ) ;
      miscellaneous_objects.Add( new  Date( "03.02.2004" ) ) ;

      Console.Write( "\n Substring is: "  +

            ((string) miscellaneous_objects[ 2 ]).Substring( 0, 3 ) 

            +  "\n" ) ;


      for ( int object_index  =  0 ;
                object_index  <  miscellaneous_objects.Count ;
                object_index  ++ )
      {
         Console.Write( "\n " +  miscellaneous_objects[ object_index ] ) ;
      }

      Console.Write( "\n" ) ;
   }
}





