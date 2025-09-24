using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetColor : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite[] s;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = s[Random.Range(0, s.Length)];
    }
}
