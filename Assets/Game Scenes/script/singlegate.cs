using UnityEngine;

public class singlegate : MonoBehaviour
{
    public GameObject player;
    public AudioSource Open;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == player && PlayerKey.keyCount>0)
        {
            PlayerKey.keyCount--;
            Open.Play();
            Destroy(gameObject);
        }
    }
}
