using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{
    [SerializeField] Color[] colors;
    private int counter;

    public Color GetColor() 
    {
        return colors[counter++];
    }
}
