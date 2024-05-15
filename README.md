
# ZipCodeParser

This C# class `ZipCodeParser` provides functionality to parse zip codes from a given input string and generate a mapping of zip codes to state abbreviations. It's designed to be used as part of a larger system where zip code data needs to be processed and mapped.

## Usage

1. **Input Data**: The `Parse` method takes a string input containing raw data with zip codes and optionally associated state abbreviations. The input data should follow a specific format where each zip code is followed by its associated state abbreviation, separated by a space or newline.

2. **Parsing**: The `ZipCodeParser.Parse(string input)` method parses the input string using a regular expression to extract zip codes and associated state abbreviations. If a zip code is not followed by a state abbreviation, it assigns a default abbreviation of "XX".

3. **Output**: The parsed zip codes and state abbreviations are then sorted and condensed to create a mapping. The output is printed in a format suitable for copying and pasting into a Java program, where it generates a map of zip codes to state abbreviations.

## Requirements

- .NET Framework or .NET Core environment to compile and execute the C# code.

## Installation

1. Clone this repository to your local machine.

```
git clone https://github.com/your-username/JunkParser.git
```

2. Navigate to the `JunkParser` directory.

```
cd JunkParser
```

3. Compile the code using the appropriate .NET compiler.

```
dotnet build
```

## Usage Example

```csharp
using JunkParser;

class Program
{
    static void Main(string[] args)
    {
        // Replace "path/to/rawStates.txt" with the actual file path
        string filePath = "C:\\path\\to\\rawStates.txt";

        string data;
        try
        {
            data = File.ReadAllText(filePath);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"Error: File not found - {filePath}, {e}");
            return;
        }

        ZipCodeParser.Parse(data);
        Console.WriteLine("Done");
    }
}
