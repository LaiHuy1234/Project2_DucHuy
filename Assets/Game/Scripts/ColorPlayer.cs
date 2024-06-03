using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPlayer : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer m_Renderer;
    [SerializeField] private ColorData ColorData;
    [SerializeField] private ColorEnum ColorEnum;

    public void ChangeColor(ColorEnum colorEnum)
    {
        this.ColorEnum = colorEnum;
        m_Renderer.material = ColorData.GetColorData(ColorEnum);
    }
}
