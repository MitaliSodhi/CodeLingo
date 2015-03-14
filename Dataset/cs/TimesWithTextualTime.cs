
//  TimesWithTextualTime.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-17  File created.
//  2004-11-17  Last modification.

//  A solution to Exercise 12-9

using System ;

abstract class CurrentTime
{
   protected int current_hours ;
   protected int current_minutes ;
   protected int current_seconds ;

   public CurrentTime()
   {
      DateTime  current_system_time  =  DateTime.Now ;

      current_hours    =  current_system_time.Hour ;
      current_minutes  =  current_system_time.Minute ;
      current_seconds  =  current_system_time.Second ;
   }

   abstract public void print() ;
}

//  It is not entirely true that the 12-hour a.m./p.m. time
//  would be used everywhere in America, and the 24-hour time
//  would be used everywhere in Europe. The names AmericanTime
//  and EuropeanTime just happen to be nice names to
//  distinguish these two different ways to display time.

class  AmericanTime  :  CurrentTime
{
   public override void print()
   {
      int[]  american_hours  =

        { 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,
          12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11  } ;

      Console.Write(  american_hours[ current_hours ]
                   +  ":"  +  current_minutes.ToString( "D2" ) 
                   +  ":"  +  current_seconds.ToString( "D2" ) ) ;

      if ( current_hours  <  12 )
      {
         Console.Write( " a.m." ) ;
      }
      else
      {
         Console.Write( " p.m." ) ;
      }
   }
}

class  EuropeanTime  :  CurrentTime
{
   public override void print()
   {
      Console.Write( current_hours
                  +  ":"  +  current_minutes.ToString( "D2" )
                  +  ":"  +  current_seconds.ToString( "D2" ) ) ;
   }
}

class  TextualTime  :  CurrentTime
{
   public override void print()
   {
      string[]  textual_hours  =
         { "midnight", "one", "two", "three", "four", "five",
           "six",  "seven",    "eight", "nine", "ten", "eleven",
           "noon", "one", "two", "three", "four", "five",
           "six",  "seven",    "eight", "nine", "ten", "eleven" } ;

      Console.Write(  current_minutes.ToString( "D2" )  +  " minutes and " 
                   +  current_seconds.ToString( "D2" )  +  " seconds past "
                   +  textual_hours[ current_hours ] ) ;

      if ( current_hours  <  6 )
      {
         Console.Write( " at night" ) ;
      }
      else if ( current_hours  <  12 )
      {
         Console.Write( " in the morning" ) ;
      }
      else if ( current_hours  < 18 )
      {
         Console.Write( " in the afternoon" ) ;
      }
      else
      {
         Console.Write( " in the evening" ) ;
      }
   }
}

class TimesWithTextualTime
{
   static void Main()
   {
      CurrentTime  time_to_show ;

      Console.Write( "\n Type 12 to see the time in 12-hour a.m./p.m format."
                  +  "\n Type 24 to see the time in 24-hour format."
                  +  "\n Any other number gives a textual time format. " ) ;

      int  user_response  =  Convert.ToInt32( Console.ReadLine() ) ;

      if ( user_response  ==  12 )
      {
         time_to_show  =  new  AmericanTime() ;
      }
      else if ( user_response  ==  24 )
      {
         time_to_show  =  new  EuropeanTime() ;
      }
      else
      {
         time_to_show  =  new  TextualTime() ;
      }

      Console.Write( "\n  The time is now " ) ;

      time_to_show.print() ;

      Console.Write( "\n" ) ;
   }
}




