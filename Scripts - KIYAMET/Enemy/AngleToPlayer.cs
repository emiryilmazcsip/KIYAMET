using UnityEngine;

public class AngleToPlayer : MonoBehaviour //this script basically is what makes the enemy sprite move to look at you at all times. 
{
    private Transform player; //transform the sprite to the player 
    private Vector3 targetPos; //target the position of player for the sprite
    private Vector3 targetDir; //target the direction of player for the sprite

    private SpriteRenderer spriteRenderer; //the actuall sprite renderer


    private float angle;
    public int lastIndex;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform; //find the player and interact with player move script.
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Getting Target position and JAZZ
        targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        targetDir = targetPos - transform.position;

        //Get Angle
        angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);

        //flip sprite
        Vector3 tempScale = Vector3.one;
        if (angle > 0)
        {
            tempScale.x *= -1f;
        }

        spriteRenderer.transform.localScale = tempScale;

        lastIndex = GetIndex(angle);


    }

    private int GetIndex(float angle) //the specific angles of movement in the sprite. 
    {
        //front
        if(angle > -22.5f && angle < 22.8f)
            return 0;
        if(angle >= 22.5f && angle < 67.5f)
            return 7;
        if(angle >= 67.5f && angle < 112.5f)
            return 6;
        if(angle >= 112.5f && angle < 157.5f)
            return 5;

        //Back
        if(angle <= -157.5f || angle >= 157.5f)
            return 4;
        if(angle >= -157.4f && angle >= -112.5f)
            return 3;
        if(angle >= -112.5f && angle >= -67.5f)
            return 2;
        if(angle >= -67.5f && angle <= -22.5f)
            return 1;


        return lastIndex;
    }

    private void OnDrawGizmosSelected() //for testing/debugging
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, targetPos);

    }

}
