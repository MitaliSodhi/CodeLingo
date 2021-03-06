#include <stdio.h>

// Project Euler: Problem 2
// =========================
// Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 
// and 2, the first 10 terms will be:
//     1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
// By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum // of the even-valued terms.

int main(void) {
  printf("==========\nBy considering the terms in the Fibonacci sequence whose\nvalues do not exceed four million, find the sum of the even-valued terms.\n==========\n\n");
  
  unsigned long int intFib = 0;
  unsigned long int intPrev = 0;
  unsigned long int intCur = 1;
  unsigned long int intSumEvenNumbers = 0;
  unsigned long int intMax = 0x3D0900; // 4.000.000 in hex
  
  // Do the Fibbonacci sequence until the value exceeds 4 000 000.
  while ( intSumEvenNumbers < intMax ) {
    intFib = intPrev + intCur;

    if (intFib % 2 == 0)
      intSumEvenNumbers += intFib;

    intPrev = intCur; intCur = intFib;
  }

  printf("The sum of all even numbers in the Fibonacci sequence is: %i\n", intSumEvenNumbers );

  return 0;
}