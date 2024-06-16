using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.StickyNote;

    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ColorData", order = 1)]
    public class ColorData : ScriptableObject
    {
        public List<Material> colors;
        public Material GetColorData(ColorEnum colorEnum)
        {
            return colors[(int)colorEnum];
        }
    }

public enum ColorEnum
{
    None = 0,
    Yellow = 1,
    Red = 2,
    Green = 3,
    Blue = 4,
}
