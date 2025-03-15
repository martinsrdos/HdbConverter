using System.Text.RegularExpressions;

namespace HdbConverter.Lib;

/// <summary>
/// Checks if in strings are positive numbers. If string is empty returns also <c>false</c>, because it is not a number.
/// </summary>
public static class Validator
{
    /// <summary>
    /// Check if contains only numbers (only positive). If empty, returs also false.
    /// </summary>
    public static bool IsPositiveDecimal(this string number)
    {
        return Regex.IsMatch(number, "^[0-9]+$");
    }

    /// <summary>
    /// Check if contains only zeros an ones (only positive). If empty, returs also false.
    /// </summary>
    public static bool IsBinary(this string number)
    {
        return Regex.IsMatch(number, "^[0-1]+$");
    }

    public static bool IsHexadecimalPositive(this string number)
    {
        return Regex.IsMatch(number, "^[a-fA-F0-9]+$");
    }

    public static bool IsNegative(this string number)
    {
        if (number.Length == 0) return false;
        return number[0] == '-';
    }
}
