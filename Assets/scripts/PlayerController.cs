using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public class GroundState
    {
        private GameObject player;
        private float width;
        private float height;
        private float length;


        public GroundState(GameObject playerRef)
        {
            player = playerRef;
            width = player.GetComponent<Collider2D>().bounds.extents.x + 0.1f;
            height = player.GetComponent<Collider2D>().bounds.extents.y + 0.2f;
            length = 0.05f;
        }


        public bool isWall()
        {
            bool left = Physics2D.Raycast(new Vector2(player.transform.position.x - width, player.transform.position.y), -Vector2.right, length);
            bool right = Physics2D.Raycast(new Vector2(player.transform.position.x + width, player.transform.position.y), Vector2.right, length);

            if (left || right)
                return true;
            else
                return false;
        }

        public bool isGround()
        {
            bool bottom1 = Physics2D.Raycast(new Vector2(player.transform.position.x, player.transform.position.y - height), -Vector2.up, length);
            bool bottom2 = Physics2D.Raycast(new Vector2(player.transform.position.x + (width - 0.2f), player.transform.position.y - height), -Vector2.up, length);
            bool bottom3 = Physics2D.Raycast(new Vector2(player.transform.position.x - (width - 0.2f), player.transform.position.y - height), -Vector2.up, length);
            if (bottom1 || bottom2 || bottom3)
                return true;
            else
                return false;
        }

        public bool isTouching()
        {
            if (isGround() || isWall())
                return true;
            else
                return false;
        }

        public int wallDirection()
        {
            bool left = Physics2D.Raycast(new Vector2(player.transform.position.x - width, player.transform.position.y), -Vector2.right, length);
            bool right = Physics2D.Raycast(new Vector2(player.transform.position.x + width, player.transform.position.y), Vector2.right, length);

            if (left)
                return -1;
            else if (right)
                return 1;
            else
                return 0;
        }
    }

  
    public float speed = 14f;
    public float accel = 6f;
    public float airAccel = 3f;
    public float jump = 14f; 

    private GroundState groundState;

    void Start()
    {
        groundState = new GroundState(transform.gameObject);
    }

    private Vector2 input;

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
            input.x = -1;
        else if (Input.GetKey(KeyCode.RightArrow))
            input.x = 1;
        else
            input.x = 0;

        if (Input.GetKeyDown(KeyCode.Space))
            input.y = 1;

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, (input.x == 0) ? transform.localEulerAngles.y : (input.x + 1) * 90, transform.localEulerAngles.z);
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(((input.x * speed) - GetComponent<Rigidbody2D>().velocity.x) * (groundState.isGround() ? accel : airAccel), 0)); 
        GetComponent<Rigidbody2D>().velocity = new Vector2((input.x == 0 && groundState.isGround()) ? 0 : GetComponent<Rigidbody2D>().velocity.x, (input.y == 1 && groundState.isTouching()) ? jump : GetComponent<Rigidbody2D>().velocity.y); 

        if (groundState.isWall() && !groundState.isGround() && input.y == 1)
            GetComponent<Rigidbody2D>().velocity = new Vector2(-groundState.wallDirection() * speed * 0.75f, GetComponent<Rigidbody2D>().velocity.y); 

        input.y = 0;
    }
}