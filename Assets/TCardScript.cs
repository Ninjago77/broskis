using UnityEngine;
using UnityEngine.U2D;

public class TCardScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer = null;
    public int cardNo = 0;
    //public float translucency = .5f;
    public Sprite[] cardsSprites = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Begin()
    {

        if (cardNo >= 52)
        {
            cardNo += 2;
        }
        else
        {
            cardNo = (13*(cardNo/14)) + cardNo%14;
        }


        spriteRenderer.sprite = cardsSprites[cardNo];

        //whiteify();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void whiteify()
    //{
    //    // Note: The original texture must have "Read/Write Enabled" checked in its Import Settings
    //    Texture2D tex = spriteRenderer.sprite.texture;

    //    // Get all pixels from the sprite
    //    Color[] pixels = tex.GetPixels();

    //    for (int i = 0; i < pixels.Length; i++)
    //    {
    //        // Check if the pixel is pure white (R=1, G=1, B=1)
    //        if (pixels[i].r >= 0.99f && pixels[i].g >= 0.99f && pixels[i].b >= 0.99f)
    //        {
    //            // Make the white pixel translucent (e.g., 0.5 Alpha)
    //            pixels[i] = new Color(pixels[i].r, pixels[i].g, pixels[i].b, translucency);
    //        }
    //    }

    //    // Apply changes to the texture
    //    tex.SetPixels(pixels);
    //    tex.Apply();
    //}
}
