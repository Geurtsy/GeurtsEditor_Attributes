using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemRarity
{
    RARE,
    COMMON,
    BORING
}

public class EnumTester : MonoBehaviour
{
    [SerializeField] private EnumDataContainer<ItemRaritySetting, ItemRarity> _globalRaritySettings;
    [GeurtsLabel("Rarity Types are set here. With the help of a GeurtsNote", GeurtsLabelAttribute.GeurtsStyleType.NORMAL_NOTE, 0, 10)]

    [SerializeField] private string _testerString;
}

[System.Serializable]
public class ItemRaritySetting
{
    public float _rarityChance;
    public Color _rarityColour;
}
