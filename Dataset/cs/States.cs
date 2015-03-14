
//  States.cs (c) 2003 Kari Laitinen

//  26.11.2002  C# file created.
//  07.06.2003  Last modification

using System ;

class States
{
   static void Main()
   {
      string  states_in_usa ;

      string  westmost_state  =  "Hawaii" ;
      string  prairie_state   =  "Illinois" ;

      states_in_usa   =  westmost_state + "  " + prairie_state  ;

      Console.Write( "\n   "  +  states_in_usa ) ;

      string  golden_state    =  "California" ;

      states_in_usa  =  states_in_usa.Insert( 6, golden_state ) ;
      states_in_usa  =  states_in_usa.Insert( 6, "  " ) ;

      Console.Write( "\n   "  +  states_in_usa ) ;

      string  eastmost_state  =  "Maine" ;

      states_in_usa  =  states_in_usa  +  "  Virginia  "  ;
      states_in_usa  =  states_in_usa  +  eastmost_state  ;

      Console.Write( "\n   "  +  states_in_usa ) ;

      int index_of_last_state  =  states_in_usa.LastIndexOf( "  " ) ;

      states_in_usa  =  states_in_usa.Remove( index_of_last_state,
                            states_in_usa.Length - index_of_last_state ) ;

      states_in_usa  =  states_in_usa  +  "  Massachusetts"  ;

      Console.Write( "\n   "  +  states_in_usa ) ;

      states_in_usa  =  states_in_usa.Replace( "Illinois", "Michigan" ) ;

      Console.Write( "\n   "  +  states_in_usa  +  "\n" ) ;

   }
}


