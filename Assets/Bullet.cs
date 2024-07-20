using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public float lifetime = 4;

    private MeteorSpawner meteor_spawner;

    private void Start()
    {
        meteor_spawner = FindObjectOfType<MeteorSpawner>();
        Invoke("Expire", lifetime);
    }

    void Expire() 
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Meteor>()) 
        {
            meteor_spawner.BreakMeteor(collision.transform);
            Expire();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
    }
}
