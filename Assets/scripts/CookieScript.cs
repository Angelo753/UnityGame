using UnityEngine;
using System.Collections;
public class CookieScript : MonoBehaviour
{
    public AudioSource Audio;

    private LevelManager gameLevelManager;
    public int chocolateValue;
    // Use this for initialization
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameLevelManager.AddCoins(chocolateValue);
            Destroy(gameObject);
            Audio.Play();
        }

       

    }
}