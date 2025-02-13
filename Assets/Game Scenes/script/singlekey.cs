using UnityEngine;
using System.Collections;


public class singlekey : MonoBehaviour
{

    public GameObject player;
    public AudioSource item;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == player)
        {
            PlayerKey.keyCount += 2;
            item.Play();
            Destroy(gameObject);

        }
    }
}
