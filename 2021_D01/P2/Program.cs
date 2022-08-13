// See https://aka.ms/new-console-template for more information



var inputFile = File.ReadLines(@"D:\Repos\AdventOfCode\2021_D01\P2\2021_D01_P1_input.txt");

int counterLargerThanPrevious = 0;
var previous = new ThreeMeasurementWindow();

// we don't need this list, but i'm leaving it here anyway
List<ThreeMeasurementWindow> list = new List<ThreeMeasurementWindow> (){ previous };

foreach (var line in inputFile)
{
    if(int.TryParse(line, out int result))
    {
        var current = previous.AddMeasurement(result);

        if(current > previous) counterLargerThanPrevious++;

        previous = current;
    }

    list.Add(previous);
}

Console.WriteLine($"There are {counterLargerThanPrevious} measurements that are larger than the previous");
Console.ReadLine();

class ThreeMeasurementWindow
{
    int[] measurements = new int[] { int.MaxValue, int.MaxValue, int.MaxValue };

    public int Sum() => measurements.Contains(int.MaxValue) ? int.MaxValue : measurements.Sum();

    public bool IsGreaterThan(ThreeMeasurementWindow measurementWindow) => this.Sum() > measurementWindow.Sum();

    public ThreeMeasurementWindow AddMeasurement(int newMeasurement)
    {
        return new ThreeMeasurementWindow
        {
            measurements = new int[] { measurements[1], measurements[2], newMeasurement },
        };
    }

    public static bool operator >(ThreeMeasurementWindow a, ThreeMeasurementWindow b) => a.IsGreaterThan(b);
    public static bool operator <(ThreeMeasurementWindow a, ThreeMeasurementWindow b) => b.IsGreaterThan(a);

}