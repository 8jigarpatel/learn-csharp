# C# Basics

Overview:
- [Built-in types](#Built-in-types)
- [Nullable types](#Nullable-types)
- [Type converstions](#Type-conversions)
- [Boxing unboxing](#Boxing-unboxing)
- [Common operators](#Common-operators)
- [Conditional statements](#Conditional-statements)
- [Loops](#Loops)
- [Methods](#Methods)

---

## Built-in types
- boolean - `bool active = true;`
- integral types (whole number, decimal precision not available)
    - sbyte (-128 to 127), byte (0 to 255)
    - short (-32,768 to 32,767), ushort (0 to 65,535)
    - int, uint, long, ulong, char
    - `int age = 30;`
- floating-point types (with decimal precision)
    - float (7 digits precision) - `float f = 11.07F;`
    - double (15-6 digits precision) - `double d = 11.07;`
- decimal types (with much bigger precision, 28-29 digits)
    - decomal - `decimal money = 999999999.9m;` or `decimal money = 999999999.9M;`
    - withouth `m` or `M` suffix, the number is treated as a `double`
- string - `string name = "Jigar";`
    - escape sequence - `\`, to print Jigar's, `string jigars = "Jigar\'s";`
    - verbatim literal (provides more readable) - `@`, to print C:\Program, `string cprg = @"C:\Program";`

---

## Nullable types
- In C# types are divided in 2 broad categories:
    - Value types:
      - int, float, double, structs, enums etc
      - default values is some form of 0
      - to make it nullable, use `?` - `int? i = null;`
    - Reference types:
      - interface, class (also, string, that's a class), delegates, array etc
      - default value is null
- null coalescing operator - `??`
    ```
    int? problems = null;
    Console.WriteLine("There are {0} problems.", problems ?? 0); // There are 0 problems
    ```

---

## Type conversions
- Implicit, Explicit (type cast operator & `Convert` class), Parse, TryParse
- Implicit:
  - is done by compiler when two conditions are met during conversion:
    - no loss of information
    - no possibility of exception
  - example, from int to float
    ```
    int i1 = 100;
    float f1 = i1; // 100
    ```
- Explicit:
  - when implicit isn't possible (two conditions aren't met)
  - example, from float to int
    ```
    float f2 = 555.55F;
    int i2 = f2; // Cannot implicitly convert type 'type1' to 'type2'. An explicit conversion exists (are you missing a cast?)
    int i2 = (int)f2; // 555
    int i22 = Convert.ToInt32(f2); // 556

    // Explicit conversion using `Convert` class can lead to an exception
    float f3 = 555555555555;
    int i3 = (int)f3; // -2147483648
    Console.WriteLine(i3);
    int i33 = Convert.ToInt32(f3); // System.OverflowException: 'Value was either too large or too small for an Int32.'

    string validIntStr = "999";
    int validInt = Convert.ToInt32(validIntStr); // 999
    string invalidIntStr = "999.99";
    int invalidInt = Convert.ToInt32(invalidIntStr); // System.FormatException: 'Input string was not in a correct format.'
    ```
- Parse & TryParse:
  - useful when number is in string format
  - Parse throws an exception when it can't parse the value (too large number, or invalid format input string). So use only when you're sure that input will be valid.
  - TryParse returns bool indicating success of operation, and outputs int result.
  - example, from string to int
    ```
    // Parse & TryParse
    string intStr1 = "700";
    int intFromStrParse1 = int.Parse(intStr1); // 700
    bool tryParseSuccess1 = int.TryParse(intStr1, out intintFromStrTryParse1);
    Console.WriteLine(tryParseSuccess1); // false
    Console.WriteLine(intFromStrTryParse1); // 0

    string intStr2 = "200Blah";
    int intFromStrParse2 = int.Parse(intStr2); // SystemFormatException: 'Input string was not in a correctformat.'
    bool tryParseSuccess2 = int.TryParse(intStr2, out intintFromStrTryParse2);
    Console.WriteLine(tryParseSuccess2); // false
    Console.WriteLine(intFromStrTryParse2); // 0

    string intStr3 = "999999999999";
    int intFromStrParse3 = int.Parse(intStr3); // SystemOverflowException: 'Value was either too large or toosmall for an Int32.'
    bool tryParseSuccess3 = int.TryParse(intStr3, out intintFromStrTryParse3);
    Console.WriteLine(tryParseSuccess3); // false
    Console.WriteLine(intFromStrTryParse3); // 0
    ```

---

## Boxing unboxing
- Boxing and unboxing in C# are operations that are used to convert between value types and reference types.
  - Boxing: process of converting a value type to an object reference type. This is necessary when a value type needs to be treated like a reference type, such as when storing it in a collection that requires all elements to be objects. When a value type is boxed, a new object is allocated on the heap to hold the value, and a reference to this object is returned.
  - Unboxing: process of converting an object reference type to a value type. This is necessary when retrieving a value type from a collection or other object that stores it as an object reference. When unboxing, the object reference is checked to make sure it contains a value of the correct type, and then the value is extracted from the object and returned.
- Both boxing and unboxing incur a performance cost, as they involve copying data and allocating memory on the heap. Therefore, it's generally best to avoid unnecessary boxing and unboxing operations when possible, such as by using generic collections like List<T> that avoid the need for boxing and unboxing.
- Example
  - Boxing and unboxing can happen in your C# code when you work with value types (such as int, float, double, etc.) in a context where a reference type is expected. For example, if you add an int value to an ArrayList (which is a reference type), the int value will be boxed into an object and stored on the heap. When you later retrieve the value from the ArrayList, it will be unboxed back into an int value.
  ```
  int myInt = 42;
  object myObj = myInt; // Boxing happens here
  int myOtherInt = (int)myObj; // Unboxing happens here
  ```
- boxing and unboxing are related to type conversion in C#. Boxing converts a value type to an object type (a reference type), and unboxing converts the object type back to the original value type. This can be seen as a type conversion from a value type to a reference type and vice versa

---

## Common operators
- assignment operator - `=`
- arithmetic operators - `+`, `-`, `*`, `/`, `%`
  ```
  int numerator = 25;
  int denominator = 3;

  int quotient = numerator / denominator; // 8 (8*3 = 24)
  int remainder = numerator % denominator; // 1 (24+1 = 25)
  ```
- comparision operators - `==`, `!=`, `>`, `>=`, `<`, `>=`
- turnary operator - `boolCondition ? ifTrue : ifFalse;`
- null coalescing operator - `??`

---

## Conditional statements
- two types - `if` & `switch`
- example,
  ```
  int number = 10;

  // if - option 1
  if (number == 10)
  {
      Console.WriteLine("Number is 10");
  }
  else if (number == 20)
  {
      Console.WriteLine("Number is 20");
  }
  else
  {
      Console.WriteLine("Number is neither 10 nor 20");
  }

  // if - option 2
  if (number == 10 || number == 20)
  {
      Console.WriteLine("Number is {0}", number);
  }
  else
  {
      Console.WriteLine("Number is neither 10 nor 20");
  }

  // switch - option 1
  switch (number)
  {
      case 10:
          Console.WriteLine("Number is 10");
          break;
      case 20:
          Console.WriteLine("Number is 20");
          break;
      default:
          Console.WriteLine("Number is neither 10 nor 20");
          break;
  }

  // switch - option 2
  switch (number)
  {
      case 10:
      case 20:
          Console.WriteLine("Number is {0}", number);
          break;
      default:
          Console.WriteLine("Number is neither 10 nor 20");
          break;
  }

  // &&
  if (number > 0 && number <= 20)
  {
      Console.WriteLine("Number is greater than 0 AND less than or equal 20");
  }

  // ||
  if (number < 0 || number > 100)
  {
      Console.WriteLine("Number is less than 0 OR greater than 100");
  }
  ```

---

## Loops
- while, do while, forr, foreach
- while: check condition first, execute loop while condition is true
    ```
    int whileStart = 0;
    while (whileStart <= 10)
    {
        if (whileStart % 2 == 0)
        {
            Console.WriteLine(whileStart);
        }
        whileStart += 2;
    }
    ```
- do while: check condition at the end, executes loop while condition is true. Hence, guaranteed to executed at least once
    ```
    int doWhileStart = 0;
    do
    {
        if (doWhileStart % 2 == 0)
        {
            Console.WriteLine(doWhileStart);
        }
        doWhileStart += 2;
    } while (doWhileStart <= 10);
    ```
- for: similar to while, but loop has (1) initialization, (2) condtion check, and (3) modifying variable - all at one place
    ```
    for (int i = 0; i <= 10; i += 2)
    {
        if (i % 2 == 0)
        {
            Console.WriteLine(i);
        }
    }
    ```
- foreach: used to iterate through items in a collection
    ```
    int[] zeroToTen = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    foreach (int number in zeroToTen)
    {
        if (number % 2 == 0)
        {
            Console.WriteLine(number);
        }
    }
    ```
- break vs continue in loops
  - continue: skip the current iteration
  - break: exit the loop completely

---

## Methods
- also known as functions
- very useful as they allow us to define logic once and use it multiple times
  ```
  [optional_attributes]
  access_modifier optional_static return_type method_name(optional_parameters)
  {
    method_body
    optional_return
  }

  /*
  access_modifier:
  static:
  return_type:
  method_name:
  parameters:
  method_body:
  return:
  */
  ```
- static methods vs instance methods:
  - static: invoked using class name
  - instance: invoked using an instance of class (i.e., object)
- types of parameter
  - value: creates a copy of the parameter passed, so modification doesn't affect each other
  - reference: any changes made to the parameter in the method will be reflected in that variable when control passes back to the calling method
    ```
    int i = 10;
    Console.WriteLine(i); // 10
    ChangeValueOfInt(i);
    Console.WriteLine(i); // 10
    ChangeValueOfIntRef(ref i);
    Console.WriteLine(i); // 20

    string s = "Jigar";
    Console.WriteLine(s); // "Jigar"
    ChangeValueOfString(s);
    Console.WriteLine(s); // "Jigar"
    ChangeValueOfStringRef(ref s);
    Console.WriteLine(s); // "Jigar Patel"

    private static void ChangeValueOfInt(int input)
    {
        input = 20;
        Console.WriteLine(input + " - from ChangeValueOfInt"); // 20
    }

    private static void ChangeValueOfIntRef(ref int input)
    {
        input = 20;
        Console.WriteLine(input + " - from ChangeValueOfIntRef"); // 20
    }

    private static void ChangeValueOfString(string input)
    {
        input += " Patel";
        Console.WriteLine(input + " - from ChangeValueOfString"); // "Jigar Patel"
    }

    private static void ChangeValueOfStringRef(ref string input)
    {
        input += " Patel";
        Console.WriteLine(input + " - from ChangeValueOfStringRef"); // "Jigar Patel"
    }
    ```
  - out: used when method needs to return more than one value
    ```
    int one = 10;
    int two = 5;
    DoSumAndProduct(one, two, out int sum, out int product);
    Console.WriteLine(sum); // 15
    Console.WriteLine(product);  // 50

    private static void DoSumAndProduct(int one, int two, out int sum, out int product)
    {
        sum = one + two;
        product = one * two;
    }
    ```
  - parameter arrays: method can take variable number of arguments using this. This should be the last one in a method declaration, and only one params keyword is permitted in a method declaration
    ```
    Console.WriteLine(SumAll(5)); // 5
    Console.WriteLine(SumAll(5, 5)); // 10
    Console.WriteLine(SumAll(5, 5, 5)); // 15

    private static int SumAll(params int[] nums)
    {
        return nums.Sum();

        //int sum = 0;
        //foreach(int num in nums)
        //{
        //    sum += num;
        //}
        //return sum;
    }
    ```
- Method parameters vs Method arguments
  - parameter term is used for method declaration
  - argument term is used when supplying value for method parameter
  - so, argument for parameter
     ```
     int i = 10;
     int j = AddFive(i); // i is the `argument` passed to the function AddFive

     private static int AddFive(int input) // `input` here is parameter
     {
        return input + 5;
     }
     ```
---

### sources:
- https://www.youtube.com/playlist?list=PLAC325451207E3105