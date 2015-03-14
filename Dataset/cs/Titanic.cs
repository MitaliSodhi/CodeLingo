
//  Titanic.cs  (c) 2003 Kari Laitinen

//  Compile: csc Titanic.cs Date.cs CurrentDate.cs

using System ;

class Titanic
{
   static void Main()
   {
      Date  date_when_titanic_sank  =  new  Date( "04/15/1912" ) ;

      CurrentDate  date_of_today    =  new  CurrentDate() ;

      int   years_ago, months_ago, days_ago ;

      date_of_today.get_distance_to( date_when_titanic_sank,
                                     out years_ago,
                                     out months_ago,
                                     out days_ago ) ;

      Console.Write( "\n Today it is "  +  date_of_today
                  +  ".\n On "  +  date_when_titanic_sank
                  +  ", the famous ship \"Titanic\" went to"
                  +  "\n the bottom of Atlantic Ocean."
                  +  "\n That happened "  +  years_ago  +  " years, "
                  +  months_ago  +  " months, and "
                  +  days_ago    +  " days ago. \n\n" ) ;
   }
}


