using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectedStarCounter : MonoBehaviour
{
    TMP_Text counter;
    private float recollected = 0;
    // Start is called before the first frame update
    void Start()
    {
        counter = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = $":{recollected}";
    }
    
    public float Recollected
    {
        get { return recollected; }
        set { recollected += value; }
    }
}
