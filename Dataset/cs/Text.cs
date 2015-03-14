
//  Text.cs  (c) 2003 Kari Laitinen

//  This program is an example in which a property and
//  an indexer is used. This program is not, however,
//  presented in the book.

using System ;

class Text
{
   string[] lines_of_text  =  new  string[ 200 ] ;

   int  number_of_lines_in_text  =  0 ;

   public void add_line( string  line_to_text )
   {
      lines_of_text[ number_of_lines_in_text ]  =  line_to_text ;

      number_of_lines_in_text  ++  ;
   }

   public int Length
   {
      get
      {
         return number_of_lines_in_text ;
      }
   }

   public string this[ int line_index ]
   {
      get
      {
         return  lines_of_text[ line_index ] ;
      }
   }
}

class TextWriter
{
   static void Main()
   {
      Text some_facts  =  new  Text() ;

      some_facts.add_line( "The freezing point of water is 0 Celsius" ) ;
      some_facts.add_line( "William Shakespeare lived 1564 - 1616 A.D.") ;
      some_facts.add_line( "A.D. means anno Domini (year of the Lord)" ) ;
      some_facts.add_line( "Mr. Laitinen is no Shakespeare." ) ;

      Console.Write( "\n HERE IS A TEXT: \n" ) ;

      for ( int line_index  =  0 ;
                line_index  <  some_facts.Length ;
                line_index  ++ )
      {
         Console.Write( "\n  "  +  some_facts[ line_index ] ) ;
      }
   }
}



