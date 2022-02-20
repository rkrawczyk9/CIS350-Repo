/*
 * Robert Krawczyk
 * Prototype 3
 * Repeats the background
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] backgrounds;
    float size_x, swap_x = -77;
    float speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        size_x = spriteRenderer.bounds.size.x;
        UpdateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if(transform.position.x < swap_x)
        {
            transform.Translate(Vector3.right * size_x * 2);
            UpdateSprite();
        }
    }

    void UpdateSprite()
    {
        spriteRenderer.sprite = backgrounds[Random.Range(0, backgrounds.Length)];
    }
}
