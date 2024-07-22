using System;
using System.Collections.Generic;
using UnityEngine.UIElements;

internal static class LengthParser {
    internal static StyleLength LengthStringToStyleLength(string lengthString) {
        if (string.IsNullOrEmpty(lengthString)) {
            throw new ArgumentException("Length string cannot be null or empty", nameof(lengthString));
        }

        lengthString = lengthString.Trim().ToLower();
        if (lengthString.EndsWith("px")) {
            if (float.TryParse(lengthString.Substring(0, lengthString.Length - 2), out float pxValue)) {
                return new StyleLength(pxValue);
            }
        }
        else if (lengthString.EndsWith("%")) {
            if (float.TryParse(lengthString.Substring(0, lengthString.Length - 1), out float percentValue)) {
                return new StyleLength(new Length(percentValue, LengthUnit.Percent));
            }
        }

        throw new ArgumentException($"Invalid length string: {lengthString}", nameof(lengthString));
    }


    internal static StyleLength[] LengthStringsToStyleLengths(string lengthsString) {
        if (string.IsNullOrEmpty(lengthsString)) {
            throw new ArgumentException("Lengths string cannot be null or empty", nameof(lengthsString));
        }

        string[] lengths = lengthsString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        List<StyleLength> styleLengths = new();

        foreach (string length in lengths) {
            styleLengths.Add(LengthStringToStyleLength(length));
        }

        return styleLengths.ToArray();
    }
}