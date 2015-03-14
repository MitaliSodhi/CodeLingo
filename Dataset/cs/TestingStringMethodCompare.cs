
//  TestingStringMethodCompare.cs (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  12.09.2004  C# file created.
//  12.09.2004  Last modification

using System ;

class TestingStringMethodCompare
{
   static void Main()
   {
      int  comparison_result  =  0 ;

      comparison_result  =  String.Compare( "aaa", "aab" ) ;

      if ( comparison_result  <  0 )
      {
         Console.Write( "\n   \"aaa\" is smaller than \"aab\"  \n" ) ;
      }
      else
      {
         Console.Write( "\n   \"aaa\" is not smaller than \"aab\"  \n" ) ;
      }

      comparison_result  =  String.Compare( "baa", "abb" ) ;

      if ( comparison_result  <  0 )
      {
         Console.Write( "\n   \"baa\" is smaller than \"abb\"  \n" ) ;
      }
      else
      {
         Console.Write( "\n   \"baa\" is not smaller than \"abb\"  \n" ) ;
      }

      comparison_result  =  String.Compare( "aaA", "aaa" ) ;

      if ( comparison_result  <  0 )
      {
         Console.Write( "\n   \"aaA\" is smaller than \"aaa\"  \n" ) ;
      }
      else
      {
         Console.Write( "\n   \"aaA\" is not smaller than \"aaa\"  \n" ) ;
      }

      Console.Write( "\n   Give first string to compare:   " ) ;

      string first_string  =  Console.ReadLine() ;


      Console.Write( "\n   Give second string to compare:  " ) ;

      string second_string  =  Console.ReadLine() ;

      comparison_result  =  String.Compare( first_string, second_string ) ;

      if ( comparison_result  <  0 )
      {
         Console.Write( "\n   \""  +  first_string  
                     +  "\" is smaller than \"" 
                     +  second_string  +  "\"  \n" ) ;
      }
      else if ( comparison_result  >  0 )
      {
         Console.Write( "\n   \""  +  first_string  
                     +  "\" is greater than \"" 
                     +  second_string  +  "\"  \n" ) ;
      }
      else
      {
         Console.Write( "\n   \""  +  first_string  
                     +  "\" is equal to \"" 
                     +  second_string  +  "\"  \n" ) ;
      }

   }
}



