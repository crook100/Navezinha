using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    public Transform meteoro;

    public float meteorTimer = 2f;
    private float meteorSpawnTimer = 0f;


    // Update is called once per frame
    void Update()
    {
        if (meteorSpawnTimer <= 0) 
        {
            meteorSpawnTimer = meteorTimer;
            SpawnMeteor();
        }
        meteorSpawnTimer -= Time.deltaTime;
    }

    public void BreakMeteor(Transform original) 
    {
        float size = original.localScale.x / 2.5f;
        if (size > 0.8f) 
        {
            Transform t1 = Instantiate(meteoro, new Vector3(original.position.x, original.position.y, 0), Quaternion.identity);
            Transform t2 = Instantiate(meteoro, new Vector3(original.position.x, original.position.y, 0), Quaternion.identity);
            t1.localScale = Vector3.one * (size * Random.Range(0.5f, 1.5f));
            t2.localScale = Vector3.one * (size * Random.Range(0.5f, 1.5f));

            t1.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3f, 3f), Random.Range(-0.1f, -1f)), ForceMode2D.Impulse);
            t2.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3f, 3f), Random.Range(-0.1f, -1f)), ForceMode2D.Impulse);
        }
        Destroy(original.gameObject);

    }

    void SpawnMeteor() 
    {
        Transform t = Instantiate(meteoro, new Vector3( Random.Range(-8f, 8f) , 6, 0), Quaternion.identity);
        t.localScale = Vector3.one * Random.Range(1f, 4f);
    }
}
