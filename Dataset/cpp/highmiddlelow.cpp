
//  highmiddlelow.cpp (c) 2002 Kari Laitinen

#include  <iostream.h>

class  Member_class
{
public:
   Member_class()
   {
      cout << "\n Member_class constructor was called. " ;
   }

   ~Member_class()
   {
      cout << "\n Member_class destructor was called. " ;
   }
} ;

class  High_class 
{
protected:
   Member_class  some_data_member ;
   Member_class  another_data_member ;

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
   Member_class  data_member_in_low_class ;

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


