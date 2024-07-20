using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOffsetter : MonoBehaviour
{
    public Vector2 speed = new Vector2(1.0f, 1.0f);
    Material mat;
    Vector2 offset;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (offset.x >= 1)
        {
            offset.x -= 1;
        }

        if (offset.y >= 1)
        {
            offset.y -= 1;
        }

        offset += speed * Time.deltaTime;
        mat.mainTextureOffset = offset;
    }
}
