using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorLerp : MonoBehaviour {

    public float speed = 1.0f;
    public Color startColor;
    public Color endColor;
    public bool repeatable = true;
    float startTime;
    SpriteRenderer sRenderer;

    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        sRenderer = GetComponent<SpriteRenderer>();
        //startColor = new Color(53f, 236f, 129f);
        //endColor = new Color(219f, 236f, 77f);
        startColor = Color.cyan;
        endColor = Color.magenta;
    }

    // Update is called once per frame
    void Update()
    {
        if (!repeatable)
        {
            float t = (Time.time - startTime) * speed;
            sRenderer.color = Color.Lerp(startColor, endColor, t);
        }
        else
        {
            if (repeatable)
            {
                float t = (Mathf.Sin(Time.time - startTime)) * speed;
                sRenderer.color = Color.Lerp(startColor, endColor, t);
            }
        }


    }
}
