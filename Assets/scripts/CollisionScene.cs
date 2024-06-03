using UnityEngine;
using System.Collections;

public class CollisionScene : MonoBehaviour
{
    public GameObject gameObject;

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "won")
        {
            gameObject.SetActive(true);
        }
    }
    
}