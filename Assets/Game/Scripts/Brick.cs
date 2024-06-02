using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private ColorEnum ColorEnum;
    [SerializeField] public MeshRenderer MeshRenderer;
    [SerializeField] private ColorData ColorData;
    
    public void ChangeColor(ColorEnum colorEnum)
    {
        MeshRenderer.material = ColorData.GetColorData(ColorEnum);
        this.ColorEnum = colorEnum;
        ChangeColor((ColorEnum)Random.Range(1, 4));
    }

}
