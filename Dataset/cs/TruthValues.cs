
//  TruthValues.cs  (c) 2003 Kari Laitinen

//  This program shows how the truth values of three
//  relational expressions change when a loop is
//  executed.

using System ;

class TruthValues
{
   static void Main()
   {
      int left_integer  =  4 ;

      Console.Write( "\n  left  right   <      >=     !=  \n" ) ;

      for ( int right_integer  =  0 ;
                right_integer  <  7 ;
                right_integer  ++ )
      {
         Console.Write( "\n   "  +  left_integer
                     +  "     "  +  right_integer ) ;

         bool first_truth_value  =  ( left_integer  <  right_integer ) ;
         bool second_truth_value =  ( left_integer  >= right_integer ) ;
         bool third_truth_value  =  ( left_integer  != right_integer ) ;

         Console.Write( "    "  +  first_truth_value
                      +  "   "  +  second_truth_value
                      +  "   "  +  third_truth_value  ) ;

      }
   }
}


