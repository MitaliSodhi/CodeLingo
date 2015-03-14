
//  Person.cs (c) 2003 Kari Laitinen

using System ;

class  Person
{
   public  string  person_name ;
   public  int     year_of_birth ;
   public  string  country_of_origin ;

   public void print_person_data()
   {
      Console.Write( "\n   " + person_name  + " was born in "
                   +  country_of_origin  + " in " + year_of_birth ) ;
   }
}

class  PersonTest
{
   static void Main()
   {
      Person  computing_pioneer  =  new  Person() ;

      computing_pioneer.person_name        =  "Alan Turing" ;
      computing_pioneer.year_of_birth      =  1912 ;
      computing_pioneer.country_of_origin  =  "England" ;

      Person  another_computing_pioneer  =  new  Person() ;

      another_computing_pioneer.person_name        =  "Konrad Zuse" ;
      another_computing_pioneer.year_of_birth      =  1910 ;
      another_computing_pioneer.country_of_origin  =  "Germany" ;

      computing_pioneer.print_person_data() ;
      another_computing_pioneer.print_person_data() ;
   }
}


