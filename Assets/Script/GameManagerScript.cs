using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public Sprite[] CardFaces;

    public GameObject CardPrefab;

    //S for Spade, C for Clubs, D for Diamonds, H for Hearts
    public static string[] suits = { "C", "D", "H", "S" };

    public static string[] values = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" }; 

    public List<string> deck;

    public List<string> shuffledDeck;

    public GameObject CardContainer;


    // Start is called before the first frame update
    void Start()
    {
        PlayCards();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayCards() {

        deck = GenerateDeck();
        shuffledDeck = deck;
        shuffledDeck = Shuffle(shuffledDeck);
        CardDeal();
        //foreach (string card in deck)
        //{
        //    print(card);
        //}
    }

    //when the game starts, create card that is in order: C1 to C13, D1 to D13, H1 to H13, S1 to S13
    public static List<string> GenerateDeck() {

        List<string> newDeck = new List<string>();

        //this nested loop creates a card deck of 52 cards 
        foreach (string s in suits)
        {
            foreach (string v in values)
            {
                newDeck.Add(s + v);
            }
        }

        return newDeck;
    }


    //shuffle the deck created to form a deck of card w random sequeunce. 
    public static List<T> Shuffle<T>(List<T> list) {

        System.Random random = new System.Random();

        int n = list.Count;

        while (n > 1) {

            int k = random.Next(n);
            n--;

            //swap positions of index k and n, k at random
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;

        }
        return list;

    }

    //spawn deck cards
    public void CardDeal() {

        foreach (string card in deck)
        {
            //Instantiate CardPrefabs in CardContainer
            GameObject newCard = Instantiate(CardPrefab, CardContainer.transform);
            //name is C1 to C13, D1 to D13, H1 to H13, S1 to S13 (shuffled)
            newCard.name = card;
        }
    }

}
