# Lab 1

> Check for unsafe code blocks in your sources. Check for Platform Invoke [DllImport]. If there is none, that's ok.

## Span and ArrayPool

> Experiment with Span<T> and ArrayPool.

Create a small .NET Core console application and use the Span<T> type to access a string and an int array.

Use the ArrayPool and create 10000 arrays that are used only for a short time. Verify the memory using the task manager. 


## Format strings

How are format strings used in your application?

Create a .NET Core console application writing this string to the Console:

```csharp
int x = 42;
string s = "test";
Console.WriteLine(string.Format(formatString, x, s));
```

Read the formatString from a file. 

> Can you imagine issues from this?

Experiment with format strings coded in the program and using C# 6 string interpolation


## Integer overflows

Experiment with number overflows. Use numbers that are too big, and use casts.

Modify the application to use the Convert class, and to use the `checked` statement.

What exception is thrown by the Convert class?

Use the `checked` statement while experimenting with integer overflows.

Why is `checked` not the default?   

## Catch Exceptions

Write a small console application to read and write to the file system. What exceptions should you handle?

Log the exception using the trace features you usually use. What tracing features do you use.


## Address Spaces

1. Write a .NET Framework application, create a variable, and write the address of the variable to the console

2. Write a .NET Core application, create a variable, and write the address of the variable to the console

Run the application multiple times. What's different?
