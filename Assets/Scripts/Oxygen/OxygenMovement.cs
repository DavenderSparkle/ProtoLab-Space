using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenMovement : MonoBehaviour
{
    Rigidbody2D oxygenRB;
    float pos;

    // Start is called before the first frame update
    void Start()
    {
        oxygenRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        pos = Mathf.Sin(Time.time)* 6.5f;
        oxygenRB.velocity = new Vector2(-3, 0);
        transform.position = new Vector2(transform.position.x, pos);

        if (transform.position.x < -23) Destroy(gameObject);
    }
}
