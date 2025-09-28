using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : MonoBehaviour
{
    Rigidbody2D planetRb;

    GameObject orbitorPlanet;
    public GameObject[] whoOrbits;
    public bool isOrbiter = false;
    float dirRNG;
    float probOrbit;

    // Start is called before the first frame update
    void Start()
    {
        probOrbit = Random.Range(0f, 1f);

        planetRb = GetComponent<Rigidbody2D>();
        if (whoOrbits.Length > 0 && probOrbit > 0.5f) Orbit();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        planetRb.velocity = new Vector2(-4f, 0f);
        if(planetRb.position.x < -23f) 
        {
            if(!isOrbiter) PlanetCreator.objCreated--; //This safeguards that when destroyed, two planets are not created
            Destroy(gameObject);
        }

        if (orbitorPlanet != null) orbitorPlanet.transform.RotateAround(transform.position, Vector3.back, dirRNG);
    }

    void Orbit()
    {
        float distance = transform.position.y + 6f;
        do 
        {
            dirRNG = Random.Range(-0.4f, 0.4f);
        } while (dirRNG == 0);

        orbitorPlanet = Instantiate(whoOrbits[Random.Range(0,whoOrbits.Length)], new Vector2(transform.position.x, distance), Quaternion.identity);

        PlanetBehaviour orbitorScript = orbitorPlanet.GetComponent<PlanetBehaviour>();
        orbitorScript.isOrbiter =true;
    }
}
