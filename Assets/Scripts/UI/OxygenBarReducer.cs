using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBarReducer : MonoBehaviour
{
    Slider oxygenLevel;
    float boost;
    private float oxygenLv;

    // Start is called before the first frame update
    void Start()
    {
        oxygenLevel = GetComponent<Slider>();
        oxygenLv = oxygenLevel.value;
    }

    // Update is called once per frame
    void Update()
    {
        oxygenLevel.value = oxygenLv;
        boost = Input.GetKey(KeyCode.Space) ? 2 : 1; //if you use propulsor it burns oxygen
        oxygenLv -= 0.01f * Time.deltaTime * boost;
    }

    public float OxygenLv
    {
        get {  return oxygenLv; }
        set { oxygenLv += value; }
    }
}
