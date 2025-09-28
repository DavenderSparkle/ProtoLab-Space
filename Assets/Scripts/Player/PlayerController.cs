using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D player;

    //Sprite Change Behaviour (could use animator, but since only 2 images, keep it simple)
    SpriteRenderer sr;
    public Sprite[] s;

    public float vel;
    public float playervel;
    int traveled;

    [SerializeField] OxygenBarReducer oxBrRed;
    CollectibleBehaviour colBeh;
    [SerializeField]CollectedStarCounter colStrCount;

    [SerializeField] AudioSource crash;
    [SerializeField] AudioSource starPick;
    [SerializeField] AudioSource oxygenPick;
    [SerializeField] AudioSource rocket;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GetComponent<Rigidbody2D>();
        player.gravityScale = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        traveled = 1 * (int)Time.time;
        //Death By Suffocation
        if(oxBrRed.OxygenLv <= 0)
        { 
            StartCoroutine(WaitSeconds()); 
        }

        playervel = player.velocity.y;

        //Where all game gimmic occurs
        if (Input.GetKey(KeyCode.Space))
        {
            if (!rocket.isPlaying)
            {
                rocket.Play();
            }
            sr.sprite = s[0];
            vel = vel > 4 ? vel : vel += 0.2f * Time.deltaTime *10;
            player.velocity = new Vector2(0f, vel);

        }
        else
        {
            rocket.Stop();
            sr.sprite = s[1];
            player.velocity = playervel < -3f ? player.velocity = new Vector2 (0,-3f): player.velocity; 
            vel = 0;
        }

        //Tp going out of screen
        if (transform.position.y >= 10.5)
        {
            transform.position = new Vector2(transform.position.x, -10.4f);
        }
        else if (transform.position.y <= -10.5)
        {
            transform.position = new Vector2(transform.position.x, 10.4f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colBeh = collision.gameObject.GetComponent<CollectibleBehaviour>();
        //Death by Planet
        if (collision.CompareTag("Planet"))
        {
            crash.Play();
            StartCoroutine(WaitSeconds());
        }

        //Recover Oxygen
        if (collision.CompareTag("Oxygen"))
        {
            oxygenPick.Play();
            oxBrRed.OxygenLv = colBeh.Increment;
        }

        if (collision.CompareTag("Star"))
        {
            starPick.Play();
            colStrCount.Recollected = colBeh.Increment;
        }

    }


    IEnumerator WaitSeconds()
    {
        colStrCount.SaveRecord();
        SaveTravel();
        sr.enabled = false;
        yield return new WaitForSeconds(0.9f);
        SceneManager.LoadScene(0);
    }



    public void SaveTravel()
    {
        float current = PlayerPrefs.GetFloat("TravelRecord", 0);

        if (traveled > current)
        {
            PlayerPrefs.SetFloat("TravelRecord", traveled);
            PlayerPrefs.Save();
        }
    }
}
