using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Sprite[] sprites;
    private SpriteRenderer sr;
    private int frame = 0;

    // Start is called before the first frame update
    void Start()
    {
        Texture2D[] textures = Resources.LoadAll<Texture2D>("Textures/Gobliner/Walk/");
        sprites = new Sprite[textures.Length];

        Rect r = new Rect(0, 0, 150, 400);
        Vector2 v = new Vector2(-1, -1);

        for (int i = 0; i < textures.Length; i++)
        {
            sprites[i] = Sprite.Create(textures[i], r, v);
        }

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        frame++;
        if (frame > 59) frame = 0;
        Debug.Log(frame);
        sr.sprite = sprites[frame];
    }
}
