using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasRed, hasGreen, hasBlue;


    private void Start()
    {
        CanvasManager.Instance.ClearKeys();
    }
}
