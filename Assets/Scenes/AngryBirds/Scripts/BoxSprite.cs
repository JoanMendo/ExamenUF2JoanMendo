using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSprite : MonoBehaviour
{
    
    public Sprite[] boxSprites;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        int randomSpriteIndex = Random.Range(0, boxSprites.Length);
        _spriteRenderer.sprite = boxSprites[randomSpriteIndex];
    }

    
}
