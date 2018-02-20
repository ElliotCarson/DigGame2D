using CnControls;
using UnityEngine;
using System;

public class player_controller : MonoBehaviour {

    public float maxSpeed;
    public static player_controller instance;
    public Rigidbody2D rb;
    private float dig_unit = (float)0.3;
    private float lastMoveHoriz, lastMoveVert;
    bool isFlying = false;

    void Awake() //called before start
    {
        rb = GetComponent<Rigidbody2D>();
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start() {
    }

    // This is called once per frame
    void Update()
    {
        // check if flying
        CheckFlying();

        // check if falling too fast
        //CheckVelo();

        // keep the player in bounds
        CheckInBounds();

        // Joystick input handling - need to move this to a seperate function "Move()"
        float h = CnInputManager.GetAxis("Horizontal");
        Move(h, true);
        float v = CnInputManager.GetAxis("Vertical");
        Move(v, false);
        if (h == 0)
        {
            AddGravity();
            lastMoveHoriz = 0;
            lastMoveVert = 0;
        }
        
    }

    public void Move(float move, bool horiz)
    {
        //If moving into a block, dig it
        if (lastMoveHoriz != 0 && rb.velocity == Vector2.zero)
        {
            if (Math.Abs(lastMoveHoriz) > Math.Abs(lastMoveVert))
            {
                if (lastMoveHoriz > 0)
                {
                    Dig("right");
                }
                else
                {
                    Dig("left");
                }
            }
            else if (lastMoveVert < 0) //can't dig up
            {
                Dig("down");
            }
        }

        // otherwise just move
        if (horiz)
        {
            rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
            lastMoveHoriz = move;
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, move * maxSpeed);
            lastMoveVert = move;
        }
    }

    public void Dig(string direction)
    {
        if (!isFlying)
        {
            Vector2 temp = rb.position;
            switch (direction)
            {
                case "right":
                    temp.x += dig_unit;
                    //Debug.Log("digging right");
                    break;
                case "left":
                    temp.x -= dig_unit;
                    //Debug.Log("digging left");
                    break;
                case "down":
                    temp.y -= dig_unit;
                    //Debug.Log("digging down");
                    break;
                default:
                    break;

            }
            rb.position = temp;
        }
        else
        {
            Debug.Log("Can't dig, currently flying");
        }
    }

    void CheckVelo()
    {
        Vector2 temp = rb.velocity;
        if (temp.y < -20)
        {
            temp.y = -20;
            rb.velocity = temp;
        }
    }

    void CheckInBounds()
    {
        Vector2 temp = rb.position;
        if(temp.x < 0.5)
        {
            temp.x = (float)0.5;
            rb.position = temp;
        }
        else if (temp.x > 29.5)
        {
            temp.x = (float)29.5;
            rb.position = temp;
        }

    }
    
    void CheckFlying()
    {
        if (Physics2D.Raycast(rb.position, Vector2.down, (float)1))
        {
            isFlying = false;
            //Debug.Log("grounded");
        }
        else
        {
            isFlying = true;
            //Debug.Log("flying");
        }
    }

    void AddGravity()
    {
        Vector2 playerVelocity = rb.velocity;
        playerVelocity.y -= (float)9.81;
        rb.velocity = playerVelocity;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("collided");
        //other - 0, coal - 1, copper - 2, iron - 3, gold - 4, diamond - 5, platnium - 6, uranium - 7
        if (col.gameObject.tag == "dirt" || col.gameObject.tag == "stone" || col.gameObject.tag == "grass")
        {
            Destroy(col.gameObject);
            PlayerManager.instance.IncrementOre(-1);
        }
        else if (col.gameObject.tag == "coal")
        {
            Destroy(col.gameObject);
            PlayerManager.instance.IncrementOre(0);
        }
        else if (col.gameObject.tag == "copper")
        {
            Destroy(col.gameObject);
            PlayerManager.instance.IncrementOre(1);
        }
        else if (col.gameObject.tag == "iron")
        {
            Destroy(col.gameObject);
            PlayerManager.instance.IncrementOre(2);
        }
        else if (col.gameObject.tag == "gold")
        {
            Destroy(col.gameObject);
            PlayerManager.instance.IncrementOre(3);
        }
        else if (col.gameObject.tag == "diamond")
        {
            Destroy(col.gameObject);
            PlayerManager.instance.IncrementOre(4);
        }
        else if (col.gameObject.tag == "platnium")
        {
            Destroy(col.gameObject);
            PlayerManager.instance.IncrementOre(5);
        }
        else if (col.gameObject.tag == "uranium")
        {
            Destroy(col.gameObject);
            PlayerManager.instance.IncrementOre(6);
        }
        else if (col.gameObject.tag == "gas")
        {
            UI_Manager.instance.OpenGasStation();
        }
        else if (col.gameObject.tag == "refinery")
        {
            UI_Manager.instance.OpenRefinery();
        }
    }

    
    public Vector2 getPlayerPos()
    {
        Vector2 ppos = rb.transform.position;
        return ppos;
    }

    public bool PlayerIsStationary()
    {
        Debug.Log(("Player is stationary: " + (rb.velocity == Vector2.zero)));
        return (rb.velocity == Vector2.zero);
    }

}
