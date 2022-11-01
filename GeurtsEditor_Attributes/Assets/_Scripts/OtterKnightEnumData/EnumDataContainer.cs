using UnityEngine;
using System;

[System.Serializable]
public class EnumDataContainer<DataType, EnumType> where EnumType : Enum
{
    [SerializeField] private DataType[] _content = null;
    [SerializeField] private EnumType _enumType;

    public DataType this[int index]
    {
        get { return _content[index]; }
    }

    public int Length
    {
        get { return _content.Length; }
    }
}
