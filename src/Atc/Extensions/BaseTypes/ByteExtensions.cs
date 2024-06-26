// ReSharper disable once CheckNamespace
namespace System;

/// <summary>
/// Extensions for the byte class.
/// </summary>
public static class ByteExtensions
{
    /// <summary>
    /// Take some bytes from a given start position and for the given length.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="startPosition">The start position.</param>
    /// <param name="length">The length.</param>
    public static byte[] TakeBytes(
        this byte[] value,
        int startPosition = 0,
        int length = 0)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length < startPosition + length)
        {
            return Array.Empty<byte>();
        }

        return value
            .Skip(startPosition)
            .Take(length)
            .ToArray();
    }

    /// <summary>
    /// Take some bytes from a given start position and for the given length and convert to Int.
    /// and convert to a <see cref="int"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="startPosition">The start position.</param>
    /// <param name="length">The length.</param>
    public static int TakeBytesAndConvertToInt(
        this byte[] value,
        int startPosition = 0,
        int length = 0)
    {
        if (length > sizeof(int))
        {
            return -1;
        }

        var bytes = TakeBytes(value, startPosition, length);
        if (bytes.Length == 0)
        {
            return -1;
        }

        if (length < sizeof(int))
        {
            bytes = bytes
                .Concat(ByteHelper.CreateZeroArray(length))
                .ToArray();
        }

        return BitConverter.ToInt32(bytes);
    }

    /// <summary>
    /// Take some bytes from a given start position and for the given length and convert to Long.
    /// and convert to a <see cref="long"/> value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="startPosition">The start position.</param>
    /// <param name="length">The length.</param>
    public static long TakeBytesAndConvertToLong(
        this byte[] value,
        int startPosition = 0,
        int length = 0)
    {
        if (length > sizeof(long))
        {
            return -1;
        }

        var bytes = TakeBytes(value, startPosition, length);
        if (bytes.Length == 0)
        {
            return -1;
        }

        if (length < sizeof(long))
        {
            bytes = bytes
                .Concat(ByteHelper.CreateZeroArray(length))
                .ToArray();
        }

        return BitConverter.ToInt64(bytes);
    }

    /// <summary>
    /// Take the remaining bytes from a given start position.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="startPosition">The start position.</param>
    public static byte[] TakeRemainingBytes(
        this byte[] value,
        int startPosition = 0)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        if (value.Length < startPosition)
        {
            return Array.Empty<byte>();
        }

        return value
            .Skip(startPosition)
            .ToArray();
    }

    /// <summary>
    /// Splits a byte array by a specific byte into multiple byte arrays.
    /// </summary>
    /// <param name="source">The source byte array to split.</param>
    /// <param name="splitByte">The byte to split on.</param>
    public static IEnumerable<byte[]> Split(
        this IEnumerable<byte> source,
        byte splitByte)
    {
        if (source is null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        return SplitSource();

        IEnumerable<byte[]> SplitSource()
        {
            var current = new List<byte>();

            foreach (var b in source)
            {
                if (b == splitByte)
                {
                    if (current.Count > 0)
                    {
                        yield return current.ToArray();
                    }

                    current.Clear();
                    continue;
                }

                current.Add(b);
            }

            if (current.Count > 0)
            {
                yield return current.ToArray();
            }
        }
    }

    /// <summary>
    /// Converts a byte array to its hexadecimal string representation.
    /// Examples:
    /// <code>{ 0x1A, 0x2B, 0x3C }.ToHex() // Gives: "1A2B3C"</code>
    /// <code>{ 0x1A, 0x2B, 0x3C }.ToHex("-") // Gives: "1A-2B-3C"</code>
    /// <code>{ 0x1A, 0x2B, 0x3C }.ToHex("-", true) // Gives: "0x1A-0x2B-0x3C"</code>
    /// <code>{ 0x1A, 0x2B, 0x3C }.ToHex(", ", true) // Gives: "0x1A, 0x2B, 0x3C"</code>
    /// </summary>
    /// <param name="value">The byte array to be converted.</param>
    /// <param name="separator">An optional character used to separate the hexadecimal values. If not provided, there will be no separator between values.</param>
    /// <param name="showHexSign">A flag indicating whether to prepend each hexadecimal value with '0x'. Defaults to false.</param>
    /// <returns>
    /// A string representation of the byte array in hexadecimal format.
    /// </returns>
    /// <example>
    /// Here are several examples of using the ToHex method:
    /// <code>
    /// byte[] exampleBytes = { 0x1A, 0x2B, 0x3C };
    ///
    /// // Example without separator
    /// Console.WriteLine(exampleBytes.ToHex()); // Outputs: 1A2B3C
    ///
    /// // Example with separator
    /// Console.WriteLine(exampleBytes.ToHex("-")); // Outputs: 1A-2B-3C
    ///
    /// // Example with separator and hex sign
    /// Console.WriteLine(exampleBytes.ToHex("-", true)); // Outputs: 0x1A-0x2B-0x3C
    ///
    /// // Example with separator and hex sign - Note: Same as exampleBytes.ToHexWithPrefix()
    /// Console.WriteLine(exampleBytes.ToHex(", ", true)); // Outputs: 0x1A, 0x2B, 0x3C
    /// </code>
    /// </example>
    public static string ToHex(
        this byte[] value,
        string? separator = null,
        bool showHexSign = false)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        var s = BitConverter.ToString(value);
        if (separator is null)
        {
            return s.Replace("-", string.Empty, StringComparison.Ordinal);
        }

        return showHexSign
            ? "0x" + s.Replace("-", $"{separator}0x", StringComparison.Ordinal)
            : s.Replace("-", separator, StringComparison.Ordinal);
    }

    /// <summary>
    /// Converts a byte array to its hexadecimal string representation with a '0x' prefix for each byte
    /// and separated with ', '.
    /// Examples:
    /// <code>{ 0x1A, 0x2B, 0x3C }.ToHexWithPrefix() // Gives: "0x1A, 0x2B, 0x3C"</code>
    /// </summary>
    /// <param name="value">The byte array to be converted.</param>
    /// <returns>
    /// A string representation of the byte array in hexadecimal format, prefixed with '0x' for each byte
    /// and separated with ', '.
    /// </returns>
    /// <example>
    /// <code>
    /// byte[] exampleBytes = { 0x1A, 0x2B, 0x3C };
    /// string hex = ToHexWithPrefix(exampleBytes);
    /// Console.WriteLine(hex); // Outputs: 0x1A, 0x2B, 0x3C
    /// </code>
    /// </example>
    public static string ToHexWithPrefix(
        this byte[] value)
        => ToHex(value, separator: ", ", showHexSign: true);
}