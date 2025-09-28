using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] TMP_Text starRecord;
    [SerializeField] TMP_Text distanceRecord;
    // Start is called before the first frame update
    void Start()
    {
        float record = PlayerPrefs.GetFloat("StarsRecord", 0);
        float distance = PlayerPrefs.GetFloat("TravelRecord", 0);
        starRecord.text = $":{record}";
        distanceRecord.text = $":{distance}";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            starRecord.text = ":0";
            distanceRecord.text = ":0";
            PlayerPrefs.DeleteAll();
        }
    }
}
