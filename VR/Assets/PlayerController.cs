using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private Vector3 move;
    public GameObject sphere;
    public GameObject player;
    private float incrementSpeed = 0.1f;
    private float moveVertical;
    private float moveHorizontal;

    SerialPort sp = new SerialPort("COM5", 9600);
    string[] strArr;

    // Start is called before the first frame update
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 21;
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        strArr = sp.ReadLine().Split(',');

        if (sphere.transform.position.x <= player.transform.position.x)
        {
            float spawnXPosition = player.transform.position.x + UnityEngine.Random.Range(30,40);
            float spawnYPosition = player.transform.position.y + UnityEngine.Random.Range(-10, 20);
            float spawnZPosition = player.transform.position.z + UnityEngine.Random.Range(-10, 30);
            sphere.transform.position = new Vector3(spawnXPosition, spawnYPosition, spawnZPosition);
            sphere.SetActive(true);
        }

        // float moveHorizontal = Input.GetAxis("Horizontal"); //replace these lines with Arduino readings
        //float moveVertical = Input.GetAxis("Vertical");  //replace these lines with Arduino readings
        if(Convert.ToDouble(strArr[0]) > 30)
        {
             moveVertical = 10f;
        }
        else if (Convert.ToDouble(strArr[0]) < -30 )
        {
            moveVertical = -10f;
        }
        else
        {
            moveVertical = 0;
        }

        if (Convert.ToDouble(strArr[1]) > 30)
        {
            moveHorizontal = 10f;
        }
        else if (Convert.ToDouble(strArr[1]) < -30)
        {
            moveHorizontal = -10f;
        }
        else
        {
            moveHorizontal = 0;
        }


        //float moveVertical = (float)Convert.ToDouble(strArr[0]);
        //float moveHorizontal = (float)Convert.ToDouble(strArr[1]);
       // float moveHorizontal = 0f; 
        print(moveVertical);

        if (incrementSpeed > 2f)
        {
            incrementSpeed = 2f;
        }
            move = new Vector3(incrementSpeed, moveVertical/50f, -moveHorizontal/50f);
            player.transform.position = (Vector3)player.transform.position + move;
    }

   void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Sphere")
        {
            incrementSpeed = 1.1f * incrementSpeed;
            textFollow.instance.youScored();
            sphere.SetActive(false);
        }
    }
}