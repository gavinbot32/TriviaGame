using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Category : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Question questionPrefab;
    [SerializeField] private CategoryData cData;
    [SerializeField] private TextMeshProUGUI categoryName;
    

    public void Initialize(CategoryData data, GameManager gm)
    {
        this.gameManager = gm;
        this.cData = data;
        categoryName.text = cData.name;
        for (int i = 0; i < 5;  i++) {
            CardData[] cardList = cData.easyPool;
            switch (i)
            {
                case 0:
                    cardList = cData.easyPool;
                    break;
                case 1:
                    cardList = cData.mediumPool;
                    break;
                case 2:
                    cardList = cData.hardPool;
                    break;
                case 3:
                    cardList = cData.masterPool;
                    break;
                case 4:
                    cardList = cData.expertPool;
                    break;
                default:
                    cardList = cData.easyPool;
                    break;
            }

            Question q = Instantiate(questionPrefab, transform);
            q.Initialize(cardList[Random.Range(0, cardList.Length)], gameManager);
        }
    }

}
