using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenuBehaviour : MonoBehaviour
{
    public float limit, speed;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, Mathf.Sin(Time.time * speed) *limit);

        if (Input.GetKey(KeyCode.Space))
            StartCoroutine(WaitSeconds());
    }


    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene(1);
    }
}
