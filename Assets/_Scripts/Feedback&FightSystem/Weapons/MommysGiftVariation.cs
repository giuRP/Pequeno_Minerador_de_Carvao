using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MommysGiftVariation : MonoBehaviour
{
    public List<Sprite> gifts = new List<Sprite>();

    SpriteRenderer spriteRenderer;

    int giftIndex = 0;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        spriteRenderer.sprite = gifts[giftIndex];
    }

    public void ChangeGiftSprite()
    {
        giftIndex = Random.Range(0, gifts.Count-1);
        spriteRenderer.sprite = gifts[giftIndex];
        Debug.Log(giftIndex);
    }
}
