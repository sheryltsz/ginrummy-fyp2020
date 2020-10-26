using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{

    public Sprite cardFace;
    public Sprite cardBack;

    private SpriteRenderer spriteRenderer;
    public bool onCardFace = false;
    GameManagerScript gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManagerScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();


        List<string> deck = gm.deck;

        int i = 0;

        foreach (string card in deck)
        {
            if (this.name == card) {

                cardFace = gm.CardFaces[i];
                spriteRenderer.sprite = cardFace;
                break;
            }
            i++;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onCardFace)
        {
            spriteRenderer.sprite = cardFace;
        }
        else
        {
            spriteRenderer.sprite = cardBack;
        }
        

    }
}
