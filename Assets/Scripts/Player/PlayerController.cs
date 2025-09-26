using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D player;

    //Sprite Change Behaviour (could use animator, but since only 2 images, keep it simple)
    SpriteRenderer sr;
    public Sprite[] s;

    public float vel;
    public float playervel;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GetComponent<Rigidbody2D>();
        player.gravityScale = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        playervel = player.velocity.y; //Debug falling velocity
        if (Input.GetKey(KeyCode.Space))
        {
            sr.sprite = s[0];
            vel = vel > 4 ? vel : vel += 0.2f * Time.deltaTime *10;
            player.velocity = new Vector2(0f, vel);

        }
        else
        {
            sr.sprite = s[1];
            player.velocity = playervel < -3f ? player.velocity = new Vector2 (0,-3f): player.velocity; 
            vel = 0;
        }
    }

    //Death by Planet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Planet"))
            Destroy(this.gameObject);
    }
}
