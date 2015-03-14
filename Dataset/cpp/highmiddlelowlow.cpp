
//  highmiddlelowlow.cpp (c) 2000-2002 Kari Laitinen

#include  <iostream.h>

class  Member_class
{
protected:

   int  some_integer ;

public:
   Member_class()
   {
      cout << "\n Member_class constructor "  <<  (long) this ;
   }

   ~Member_class()
   {
      cout << "\n Member_class destructor  "  <<  (long) this ;
   }
} ;

class  Another_member_class
{
protected:

   int  some_integer ;
   int  another_integer ;

public:
   Another_member_class()
   {
      cout << "\n Another_member_class constructor "  <<  (long) this ;
   }

   ~Another_member_class()
   {
      cout << "\n Another_member_class destructor  "  <<  (long) this ;
   }
} ;

class  High_class 
{
protected:
   Member_class          some_data_member ;
   Another_member_class  another_data_member ;
   Member_class          third_member ;

public:
   High_class()
   {
      cout << "\n The constructor of High_class was called." ;
   }

   ~High_class()
   {
      cout << "\n The destructor of High_class was called." ;
   }
} ;

class  Middle_class  :  public  High_class
{
public:
   Middle_class()
   {
      cout << "\n The constructor of Middle_class was called." ;
   }

   ~Middle_class()
   {
      cout << "\n The destructor of Middle_class was called." ;
   }
} ;

class  Low_class  :  public  Middle_class
{
protected:
   Another_member_class  data_member_in_low_class ;

   Member_class  small_arry_of_objects[ 4 ] ;

public:
   Low_class()
   {
      cout << "\n The constructor of Low_class was called." ;
   }
   ~Low_class()
   {
      cout << "\n The destructor of Low_class was called." ;
   }
} ;

int main()
{
   Low_class  low_class_object ;
}


