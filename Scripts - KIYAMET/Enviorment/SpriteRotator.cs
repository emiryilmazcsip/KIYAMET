using UnityEngine;

public class SpriteRotator : MonoBehaviour // This script makes any sprite or 2d gui image rotate to always look at the player.
{
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMove>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
