
//  Miles.cs  (c) 2002 Kari Laitinen

using System ;

class Miles
{
   static void Main()
   {
      float  distance_in_miles ;
      float  distance_in_kilometers ;

      Console.Write(
            "\n This program converts miles to kilometers." 
         +  "\n Please, give a distance in miles:  "  ) ;

      distance_in_miles  =  Convert.ToSingle( Console.ReadLine() ) ;

      distance_in_kilometers  =  1.6093F * distance_in_miles ;

      Console.Write( "\n " + distance_in_miles + " miles is "
                     + distance_in_kilometers + " kilometers." ) ;

      Console.Write( "\n {0} miles is {1} kilometers. \n",
                     distance_in_miles, distance_in_kilometers ) ;
   }
}


