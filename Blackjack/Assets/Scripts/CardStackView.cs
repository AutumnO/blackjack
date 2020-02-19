using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardStack))]
public class CardStackView : MonoBehaviour
{
    CardStack deck;
    List<int> fetchedCards;
    int lastCount;

    public Vector3 start;
    public float cardOffset;
    public GameObject cardPreFab;

    void Start()
    {
        fetchedCards = new List<int>();
        deck = GetComponent<CardStack>();
        ShowCards();
        lastCount = deck.CardCount;
    }

    void Update()
    {
        if (lastCount != deck.CardCount)
        {
            lastCount = deck.CardCount;
            ShowCards();
        }
    }

    void ShowCards()
    {
        int cardCount = 0;

        if (deck.HasCards)
        {
            foreach (int i in deck.GetCards())
            {
                float co = cardOffset * cardCount;
                Vector3 temp = start + new Vector3(co, 0f);
                AddCard(temp, i, cardCount);

                cardCount++;
            }
        }
    }
    void AddCard(Vector3 position, int cardIndex, int positionalIndex)
    {
        if (fetchedCards.Contains(cardIndex))
        {
            return;
        }
        
        GameObject cardCopy = (GameObject)Instantiate(cardPreFab);
        cardCopy.transform.position = position;

        CardModel cardModel = cardCopy.GetComponent<CardModel>();
        cardModel.cardIndex = cardIndex;
        cardModel.ToggleFace(true);

        SpriteRenderer spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingOrder = positionalIndex;

        fetchedCards.Add(cardIndex);
    }
}