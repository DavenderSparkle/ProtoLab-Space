using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBG : MonoBehaviour
{
    Material bg;

    float scroll = 1f;
    float offset;

    // Start is called before the first frame update
    void Start()
    {
        bg = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scroll) / 10;
        bg.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
