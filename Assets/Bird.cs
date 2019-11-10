using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rgbd;
    private bool isDead = false;
    public float forceUp = 200f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rgbd.velocity = Vector2.zero;
                rgbd.AddForce(new Vector2(0, forceUp));
                anim.SetTrigger("Flap");
            }
        } else
        {

        }
    }

    void OnCollisionEnter2D()
    {
        rgbd.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Dead");
        GameController.instance.BirdDied();
        
    }
}
