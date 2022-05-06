# C# Crash Course

In this C# Crash Course, we'll go over the basics of C# so that you'll be ready to build out exciting web apps! We'll start by going through the key attributes of C#, syntax basics, and introduce you to OOP. In each section, we'll link you to some quick in-browser C# challenges so you can apply these concepts.

## Topics you'll learn
* Language attributes
* Syntax basics
* Object Oriented Programming

---

# Language attributes
C# is a strongly typed, compiled, object oriented language. Let's break this down.
## Strongly typed
  In a **strongly typed** language, every variable has a defined type. Some of these types include:
  * String, "Hello world!"
  * Char, 'a'
  * int, 3
  * decimal, 1.5
  * bool, True

## Compiler 
A **compiler** converts the code you write into a format that your computer can understand. After you write C# and build it, the C# compiler (called Roslyn) will analyze your code to check for any errors.

---

# The basics
Here's a piece of code that will print "Hello world!" to the console.

```csharp
using System;

Console.WriteLine("Hello world!");
```
## Keywords
With C#, you use **keywords** like *using* and *Console*.
**Keywords** are predefined, reserved identifiers that have special meanings to the compiler.

## Accessing methods
The `. (DOT)` in *Console.WriteLine* allows us to access methods and properties. In this example, **Console** is a type that represents the console window. **WriteLine** is a method of the Console type that prints a line of text to that text console.

## Parameters
In this example, we use parentheses pass a string as a parameter to *Console.WriteLine*. 

## Variables
In C#, **variables** allow you to temporarily store a value in memory. In C#, you must declare a variable before using it. 
  ```csharp
  var cSharp = "really cool";
  ```
In this example, we created a string called `cSharp`. You can use the var keyword to declare local variables without explicitly giving them a type.
  
Variable names can contain alphanumeric characters and underscores, but no special characters. They also cannot be keywords.

# Syntax cheat sheet
## Semicolons
  Every statement is ended by a semicolon
   ```csharp
   Console.WriteLine("there is a ';' at the end of this statement");
   ```
## Comments
  You can make comments by using 2 slashes
   ```csharp
   // this is a comment is C#
   ```
## Case sensitive
  C# is case sensitive! For example, a variable "cat" is completely different from a variable "CAT".
    ```csharp
    var cat = "meow";
    var CAT = "rawr";
    ```

## Arithmetic Operators
   These are probably familiar to you!
   | symbol | what it does |
   | --- | ------ |
   | + | addition |
   | - | subtraction |
   | * | multiplication |
   | / | division |
   | % | remainder |
   | ++ | increment |
   | -- | decrement |

## Boolean expressions
  We use booleans to compare two or more things.
  | symbol | what it does |
  | --- | ---------- |
  | < | less than |
  | > | greater than |
  | <= | less than or equal |
  | >= | greater than or equal |
  | == | equal |
  | != | not equal |
   
---

# Object Oriented Programming
C# is an object-oriented language. 
Objects are defined by **Classes**. In other words, an **Object** is an instance of a class.
One way to think about this is that a class is like the blue prints for a house. The actual house that is built is an objects because it is an instance of this blue print.

## Properties and methods
Objects inherently have attributes. In C# we call these **properties**. The attributes of a house may be the number of doors, what color the house is painted, etc.

We can also define **methods** which describe what an object can do. For example, you can sell your house. 

Let's look at an example House class:
```csharp
// The namespace declaration provides a way to logically organize your classes
namespace Classes;

public class House
{
  // House properties
    public string Address { get; }
    public int Size { get;}

  // House methods
    public void SellHouse(decimal amount, DateTime date)
    {
    }
}
```
## Constructor
We can define a **constructor** to allow us to create new House objects. 

```csharp
public House(string address, int squareFeet)
{
    this.Address = address;
    this.Size = squareFeet;
}
```
When we create an object with **new** this constructor will be called.
```csharp
using Classes;

// Let's create a 1500 square foot house on Candy Cane Lane
var house = new House("123 Candy Cane Lane", 1500);
```

# Mini Challenges!
Each of these mini challenges is designed so that you can apply C# concepts to mini coding exercises. These challenges are all sourced from Microsoft documentation and will allow you to get coding inside your browser. Easy peasy!

| # | Challenge  | Solution   | Duration   | What you will learn | More information |
|-| ------------------------------- | ------------------------------- | ----------- |  -------------------------------------- | - |
1 | [Hello World](https://docs.microsoft.com/learn/modules/csharp-write-first/2-exercise-hello-world/?ns-enrollment-type=learningpath&ns-enrollment-id=learn.languages.csharp-first-steps)| N/A | 3 min |  case sensitive, strings, comments | [Intro to C# Tutorial](https://docs.microsoft.com/dotnet/csharp/tour-of-csharp/tutorials/hello-world?WT.mc_id=csharpnotebook-35129-website), [C# documentation](https://docs.microsoft.com/dotnet/csharp/) |
2 | [Variables](https://docs.microsoft.com/learn/modules/csharp-literals-variables/6-challenge )|[Solution](https://docs.microsoft.com/learn/modules/csharp-literals-variables/7-solution)| 5 min |  variables, data types, strings, ints, decimals | [String formatting tutorial](https://docs.microsoft.com/learn/modules/csharp-basic-formatting/), [C# documentation](https://docs.microsoft.com/dotnet/csharp/) |
3 | [Operating on numbers](https://docs.microsoft.com/learn/modules/csharp-basic-operations/5-challenge)|[Solution](https://docs.microsoft.com/learn/modules/csharp-basic-operations/6-solution)| 2 min |  ints, decimals | [Number operations tutorial](https://docs.microsoft.com/learn/modules/csharp-basic-operations/), [C# documentation](https://docs.microsoft.com/dotnet/csharp/) |
4 | [Making clean code](https://docs.microsoft.com/learn/modules/csharp-readable-code/5-challenge)|[Solution](https://docs.microsoft.com/learn/modules/csharp-readable-code/6-solution)| 5 min |  topics | [C# coding conventions](https://docs.microsoft.com/dotnet/csharp/fundamentals/coding-style/coding-conventions) | [C# documentation](https://docs.microsoft.com/dotnet/csharp/) |


# Bonus and more ways to connect

Want more practice with C#? The .NET team has you covered. Here's a few learning resources:
* C# Video Series on [Microsoft Docs](https://docs.microsoft.com/shows/CSharp-101/?WT.mc_id=dotnet-35129-website) or [YouTube](https://www.youtube.com/watch?v=Z5JS36NlJiU)
* Self Guided Tutorials on [Microsoft Learn](https://docs.microsoft.com/users/dotnet/collections/yz26f8y64n7k07)
* [Learn to Code Page](https://dotnet.microsoft.com/learntocode)

Connect with us! Check out the [.NET Community Page](https://dotnet.microsoft.com/platform/community) to find links to our blogs, YouTube, Twitter, and more.