using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Android : MonoBehaviour
{

    public GameObject majsnerAndroid;
    public GameObject majsnerWindows;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        { 
        majsnerWindows.SetActive(false);
        majsnerAndroid.SetActive(true);
        }
    }
}
