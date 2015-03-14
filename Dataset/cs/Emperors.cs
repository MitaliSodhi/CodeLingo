
//  Emperors.cs  (c) 2003 Kari Laitinen

using System ;

class Emperors
{
   static void Main()
   {
      string[] array_of_emperors  =  new  string[ 10 ] ;

      array_of_emperors[ 0 ]  =  "Napoleon Bonaparte" ;

      string  first_emperor_of_rome   =  "Augustus (Octavianus)" ;
      string  last_emperor_of_russia  =  "Nicholas II" ;

      array_of_emperors[ 1 ]  =  first_emperor_of_rome ;
      array_of_emperors[ 2 ]  =  last_emperor_of_russia ;

      for ( int emperor_index  =  0 ;
                emperor_index  <  array_of_emperors.Length ;
                emperor_index  ++ )
      {
         Console.Write( "\n "  +  emperor_index  + ": "
                     +  array_of_emperors[ emperor_index ] ) ;
      }
   }
}



