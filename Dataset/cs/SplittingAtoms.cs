
//  SplittingAtoms.cs  (c) 2003 Kari Laitinen

using System ;

class SplittingAtoms
{
   static void Main()
   {
      string  atomic_text  = 
               "\n Atoms consist of protons, neutrons, and electrons." ;

      Console.Write( atomic_text  +  "\n" ) ;

      char[]  separator_characters  =  { '\n', ',' } ; 

      string[]  substrings_from_text  = 
                         atomic_text.Split( separator_characters ) ;

      for ( int  substring_index  =  0 ;
                 substring_index  <  substrings_from_text.Length ;
                 substring_index  ++ )
      {
         Console.Write( "\n" + substring_index  +  ":" 
                     +  substrings_from_text[ substring_index ] ) ;
      }

      atomic_text  =  String.Join( "", substrings_from_text ) ;

      Console.Write( "\n\n"  +  atomic_text  +  "\n" ) ;

      separator_characters  =  new char[ 1 ] { ' ' } ;

      substrings_from_text  =  atomic_text.Split( separator_characters ) ;

      for ( int  substring_index  =  0 ;
                 substring_index  <  substrings_from_text.Length ;
                 substring_index  ++ )
      {
         Console.Write( "\n" + substring_index  +  ":" 
                     +  substrings_from_text[ substring_index ] ) ;
      }
   }
}



