using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlanetCreator : MonoBehaviour
{

    public GameObject[] ArrayPrefabs; //Add here all Prefabs needed to instantiate
    GameObject newPrefab;
    public static int objCreated; //Static: Obj destroyer class manages substraction
    int maxObjects = 7;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        FirstGeneration();
        objCreated = 1;
    }

    // Update is called once per frame
    void Update()
    {
        GeneratePrefab();
    }

    void GeneratePrefab()
    {
        int rand = Random.Range(0, ArrayPrefabs.Length);
        if (objCreated < maxObjects)
        {
            newPrefab = (GameObject)Instantiate(ArrayPrefabs[rand], new Vector2(newPrefab.transform.position.x + 10f, Random.Range(-5, 5)/* + transform.position.y*/), Quaternion.identity);
            rb = newPrefab.gameObject.GetComponent<Rigidbody2D>();
            objCreated++;

        }
        newPrefab.transform.SetParent(transform);
    }

    void FirstGeneration()
    {
        int rand = Random.Range(0, ArrayPrefabs.Length);
        newPrefab = (GameObject)Instantiate(ArrayPrefabs[rand], new Vector2(0f, Random.Range(-5, 5)/* + transform.position.y*/), Quaternion.identity);
        newPrefab.transform.SetParent(transform);
        rb = newPrefab.gameObject.GetComponent<Rigidbody2D>();
    }
}
