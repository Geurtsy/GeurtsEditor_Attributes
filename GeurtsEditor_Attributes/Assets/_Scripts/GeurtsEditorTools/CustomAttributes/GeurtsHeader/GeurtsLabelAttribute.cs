using UnityEngine;

public class GeurtsLabelAttribute : PropertyAttribute
{
    public enum GeurtsStyleType
    {
        HEADING_1,
        HEADING_2,
        HEADING_3,
        HEADING_4,
        NORMAL_NOTE,
        MAIN_NOTE
    }

    public string _headerString;
    public GeurtsStyleType _headingType;
    public float _prefixSpacing;
    public float _suffixSpacing;

    public GeurtsLabelAttribute(string headerString, GeurtsStyleType headingType, float prefixSpacing, float suffixSpacing)
    {
        _headerString = headerString;
        _headingType = headingType;
        _prefixSpacing = prefixSpacing;
        _suffixSpacing = suffixSpacing;
    }
}
