using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour // This is how the doors operate. This is the door script.
{

    public Animator doorAnim;

    public bool requiresKey; // Requirement of key to open door.
    public bool reqRed, reqBlue, reqGreen;

    public GameObject areaToSpawn;

    void OnTriggerEnter(Collider other) // if the player has a certain key, they can get in.
    {
        if(other.CompareTag("Player")) // Area of spawn mainly exists for the smaller testing area map I had making this game. It doesn't apply now.
        {
            if(requiresKey)
            {
                if(reqRed && other.GetComponent<PlayerInventory>().hasRed)
                {

                    doorAnim.SetTrigger("OpenDoor");
                    areaToSpawn.SetActive(true);
                }
                if(reqBlue && other.GetComponent<PlayerInventory>().hasBlue)
                {

                    doorAnim.SetTrigger("OpenDoor");
                    areaToSpawn.SetActive(true);
                }
                if(reqGreen && other.GetComponent<PlayerInventory>().hasGreen)
                {

                    doorAnim.SetTrigger("OpenDoor");
                    areaToSpawn.SetActive(true);
                }

            }
            else
            {

                doorAnim.SetTrigger("OpenDoor"); 
                areaToSpawn.SetActive(true);

            }
        }
    }
}
