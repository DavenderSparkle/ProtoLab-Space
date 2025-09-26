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

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            if (Random.Range(0f,1f) < 0.3f)
            {
                //Decide if is an oxygen bubble or star (Stars often appears orbiting planets)
                randomPref = Random.Range(0, prefabs.Length);
                Instantiate(prefabs[randomPref], transform.position, Quaternion.identity);
            }
        }

    }
}
