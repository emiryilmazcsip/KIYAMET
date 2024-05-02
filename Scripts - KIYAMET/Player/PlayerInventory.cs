using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour // This script checks if the player has the keys in their inventory to use. If they don't clear it.
{
    public bool hasRed, hasGreen, hasBlue;


    private void Start()
    {
        CanvasManager.Instance.ClearKeys();
    }
}
