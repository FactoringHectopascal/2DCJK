using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    public PlatformerMovement player;
    public Vector3 targetPoint = Vector3.zero;
    [SerializeField]
    public float moveSpeed = 3;
    [SerializeField]
    public float lookAheadDistance = 5f;
    [SerializeField]
    public float lookAheadSpeed = 3f;
    [SerializeField]
    public float lookOffset;


    // Start is called before the first frame update
    void Start()
    {
        targetPoint = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }

    // Update is called once per frame
    void Update()
    {
        targetPoint.x = player.transform.position.x; // target points for the camera are the players transform position
        targetPoint.y = player.transform.position.y;

        if (player.rb.velocity.x > 0) // if the player walks right make the player look ahead to the right by offsetting the camera
        {
            lookOffset = lookAheadDistance;
        }
        if (player.rb.velocity.x < 0) // same but left and negative
        {
            lookOffset = -lookAheadDistance;
        }
        targetPoint.x = player.transform.position.x + lookOffset; // adds lookaheaddistance from our if statement because it equals our lookoffset
        transform.position = Vector3.Lerp(transform.position, targetPoint, moveSpeed * Time.deltaTime); //moves from point a to point b by our movespeed + time
    }
}
