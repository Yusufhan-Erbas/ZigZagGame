using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color[] colors;

    Color ilkRenk, ikinciRenk;
    int birinciRenk;

    public Material groundMat;

    private void Start()
    {
        birinciRenk = Random.Range(0, colors.Length);
        groundMat.color = colors[birinciRenk];
        Camera.main.backgroundColor = colors[birinciRenk];
    }
}
