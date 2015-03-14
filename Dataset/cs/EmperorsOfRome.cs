
//  EmperorsOfRome.cs  (c) 2003 Kari Laitinen

using System ;

class Emperors
{
   string[] emperor_names  =  new  string[ 50 ] ;

   public string this[ int emperor_index ]
   {
      get
      {
         return  emperor_names[ emperor_index ] ;
      }

      set
      {
         emperor_names[ emperor_index ]  =  value ;
      }
   }
}

class EmperorTester
{
   static void Main()
   {
      Emperors  roman_emperors  =  new  Emperors() ;

      roman_emperors[ 0 ]  =  "Augustus (Octavianus)" ;
      roman_emperors[ 1 ]  =  "Tiberius I" ;
      roman_emperors[ 2 ]  =  "Gaius Caesar (Caligula)" ;
      roman_emperors[ 3 ]  =  "Claudius I" ;
      roman_emperors[ 4 ]  =  "Nero" ;

      Console.Write( roman_emperors[ 0 ] ) ;

   }
}



