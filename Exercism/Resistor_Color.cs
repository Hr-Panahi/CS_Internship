public static class ResistorColor
{
    private static readonly string[] _colors =
    {
      "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"
    };
    public static int ColorCode(string color) => System.Array.IndexOf(_colors, color);
    public static string[] Colors() => _colors;
}