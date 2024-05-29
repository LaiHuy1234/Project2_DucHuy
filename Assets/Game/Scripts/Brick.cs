using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private ColorEnum ColorEnum;
    [SerializeField] private MeshRenderer MeshRenderer;
    [SerializeField] private ColorData ColorData;
    
    public void ChangeColor(ColorEnum color)
    {
        MeshRenderer.material = ColorData.GetColorData(ColorEnum);

    }
}
