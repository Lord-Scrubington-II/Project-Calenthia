using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    public float speed;
    public Renderer bgRender;

    // Update is called once per frame
    void Update()
    {
        bgRender.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0f);
    }
}
