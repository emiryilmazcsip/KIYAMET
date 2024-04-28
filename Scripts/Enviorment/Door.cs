using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public Animator doorAnim;

    public bool requiresKey;
    public bool reqRed, reqBlue, reqGreen;

    public GameObject areaToSpawn;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
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
