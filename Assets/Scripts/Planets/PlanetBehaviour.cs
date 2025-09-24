using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : MonoBehaviour
{
    Rigidbody2D planetRb;
    // Start is called before the first frame update
    void Start()
    {
        planetRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        planetRb.velocity = new Vector2(-3f, 0f);
        if(planetRb.position.x < -23f) 
        {
            PlanetCreator.objCreated--;
            Destroy(gameObject);
        }
    }
}
