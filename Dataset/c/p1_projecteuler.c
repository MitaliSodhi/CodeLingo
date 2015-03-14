#include <stdio.h>

// Project Euler: Problem 2
// =========================
// Add all the natural numbers below one thousand that are multiples of 3 or 5.

int main(void) {
  printf("Find the sum of all the multiples of 3 or 5 below 1000.\n");
  
  unsigned long int intSum = 0;
  unsigned int intMax = 1000;
  unsigned int i;
  
  for (i = 1; i < intMax; i++) {
    if ((i%3 == 0) || (i%5 == 0)) {
      intSum += i;
    }
  }  

  printf("The sum is: %i", intSum);

  return 0;
}
