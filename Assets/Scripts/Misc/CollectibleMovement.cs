using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleMovement : MonoBehaviour
{
    Rigidbody2D collectibleRB;
    float pos;
    float randomLimit;
    float randomSpeed;

    PlanetBehaviour plaBeh;

    // Start is called before the first frame update
    void Start()
    {
        plaBeh = GetComponent<PlanetBehaviour>();
        collectibleRB = GetComponent<Rigidbody2D>();
        randomLimit = Random.Range(2, 6.5f);
        randomSpeed = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        pos = Mathf.Sin(Time.time * randomSpeed)* randomLimit;
        if(plaBeh == null || !plaBeh.isOrbiter)
        {
            collectibleRB.velocity = new Vector2(-5, 0);
            transform.position = new Vector2(transform.position.x, pos);
        }

        if (transform.position.x < -23) Destroy(gameObject);
    }
}
