using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textFollow : MonoBehaviour
{
    //public GameObject cam;
    public static textFollow instance;
    public Text scoreText;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = cam.transform.position + transform.position;
    }

    public void youScored()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}


