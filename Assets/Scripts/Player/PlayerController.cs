using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D player;
    public float vel;
    public float playervel;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        player.gravityScale = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        playervel = player.velocity.y; //Debug falling velocity
        if (Input.GetKey(KeyCode.Space))
        {
            vel = vel > 3 ? vel : vel += 0.2f * Time.deltaTime *10;
            player.velocity = new Vector2(0f, vel);
        }
        else
        {
            player.velocity = playervel < -3f ? player.velocity = new Vector2 (0,-3f): player.velocity; 
            vel = 0;
        }
    }
}
