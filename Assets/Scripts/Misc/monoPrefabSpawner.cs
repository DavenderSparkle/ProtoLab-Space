using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monoPrefabSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    int randomPref;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }
    void Update()
    {
    }

    IEnumerator SpawnRoutine()
    {
        //Decide if is an oxygen bubble or star (Stars often appears orbiting planets)
        randomPref = Random.Range(0, prefabs.Length);

        while (true)
        {
            yield return new WaitForSeconds(10f);
            if (Random.Range(0f,1f) < 0.2f)
                Instantiate(prefabs[randomPref], transform.position, Quaternion.identity);
        }

    }
}
