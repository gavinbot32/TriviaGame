using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    public TextMeshProUGUI pointText;
    private CardData cardData;
    private GameManager gameManager;
    public GameObject buttonObj;

    public void Initialize(CardData card, GameManager manager)
    {
        this.cardData = card;
        this.gameManager = manager;
        gameManager.cards.Add(this);
        pointText.text = (card.difficultyLevel * gameManager.basePoints).ToString();
        buttonObj.SetActive(true);
    }

    public void OnQuestion()
    {
        gameManager.NewCard(cardData);
        gameManager.cards.Remove(this);
        buttonObj.SetActive(false);
    }

}
