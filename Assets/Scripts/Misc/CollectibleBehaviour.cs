using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{
    [Header("How many does it give | Ex: Oxygen: 0.1 / Stars: always 1 (collectible)")]
    [SerializeField] private float increment;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
    }

    public float Increment
    {
        get { return increment; }
    }
}
