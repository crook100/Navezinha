using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveControl : MonoBehaviour
{
    Animator anim;
    public Vector4 bounds;
    public float speed;
    public float attackSpeed = 0.25f;

    public Transform bullet;

    private float attackTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Fire() 
    {
        Transform t = Transform.Instantiate(bullet, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer > 0) 
        {
            attackTimer -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space)) 
        {
            if (attackTimer <= 0) 
            {
                attackTimer = attackSpeed;
                Fire();
            }
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            //Idle
            anim.SetBool("left", false);
            anim.SetBool("right", false);
        }
        else {
            if (Input.GetKey(KeyCode.A))
            {
                //Left
                anim.SetBool("left", true);
                if (transform.position.x > bounds.x) 
                {
                    transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
                }
            }
            else {
                anim.SetBool("left", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                //Right
                anim.SetBool("right", true);
                if (transform.position.x < bounds.z)
                {
                    transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
                }
            }
            else {
                anim.SetBool("right", false);
            }
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {

        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                //Up
                if (transform.position.y < bounds.y)
                {
                    transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
                }
            }
            
            if (Input.GetKey(KeyCode.S))
            {
                //Down
                if (transform.position.y > bounds.w)
                {
                    transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime);
                }
            }
        }
    }
}
