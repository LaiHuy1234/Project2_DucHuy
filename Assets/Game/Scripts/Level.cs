using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform startPoint;
    public Transform finishPoint;
    public int botAmount;
    public Platform[] platforms;

    public void OnInit()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].OnInit();
        }
    }
}
