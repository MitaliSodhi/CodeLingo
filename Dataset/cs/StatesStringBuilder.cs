
//  StatesStringBuilder.cs (c) 2002-2003 Kari Laitinen

//  26.11.2002  C# file created.
//  25.06.2003  Last modification

//  This program works in the same way as program States.cs,
//  but here StringBuilder objects are used instead of
//  string objects.

using System ;
using System.Text ;  // StringBuilder namespace

class StatesStringBuilder
{
   static void Main()
   {
      string  westmost_state  =  "Hawaii" ;
      string  prairie_state   =  "Illinois" ;

      StringBuilder states_in_usa  =
             new StringBuilder( westmost_state + "  " + prairie_state ) ;

      Console.Write( "\n   "  +  states_in_usa ) ;

      string  golden_state    =  "California" ;

      states_in_usa.Insert( 6, golden_state ) ;
      states_in_usa.Insert( 6, "  " ) ;

      Console.Write( "\n   "  +  states_in_usa ) ;

      string  eastmost_state  =  "Maine" ;

      states_in_usa.Append( "  Virginia  " ) ;
      states_in_usa.Append( eastmost_state ) ;

      Console.Write( "\n   "  +  states_in_usa ) ;

      int index_of_last_state  =
                     states_in_usa.ToString().LastIndexOf( "  " ) ;

      states_in_usa.Remove( index_of_last_state,
                            states_in_usa.Length - index_of_last_state ) ;
      states_in_usa.Append( "  Massachusetts" ) ;

      Console.Write( "\n   "  +  states_in_usa ) ;

      states_in_usa.Replace( "Illinois", "Michigan" ) ;

      Console.Write( "\n   "  +  states_in_usa  +  "\n" ) ;

   }
}


