using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 0.26f;

    private void Start()
    {
        speed = 4.2f - transform.localScale.x;
        rotationSpeed = speed*4;
        Invoke("DestroyNow", (12 - speed*2));
    }

    void DestroyNow() 
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * speed * Time.deltaTime, Space.World);
        transform.Rotate(new Vector3(0, 0, 1) * rotationSpeed * Time.deltaTime);
    }
}
