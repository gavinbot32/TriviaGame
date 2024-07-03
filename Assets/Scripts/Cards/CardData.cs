using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData")]

public class CardData : ScriptableObject
{
    public string question;
    [Tooltip("1-5 Easiest-Hardest")]
    public int difficultyLevel = 1;
}
