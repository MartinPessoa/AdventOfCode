// See https://aka.ms/new-console-template for more information


var inputFile = File.ReadLines(@"D:\Repos\AdventOfCode\2021_D01\2021_D01_input.txt");

int counterLargerThanPrevious = 0;
int previous = int.MaxValue;
foreach (var line in inputFile)
{
    if(int.TryParse(line, out int result))
    {
        if(result > previous) counterLargerThanPrevious++;
    }

    previous = result;
}

Console.WriteLine($"There are {counterLargerThanPrevious} measurements that are larger than the previous");
Console.ReadLine();