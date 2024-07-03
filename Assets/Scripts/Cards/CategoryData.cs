using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CategoryData", menuName = "ScriptableObjects/CategoryData")]
public class CategoryData : ScriptableObject
{
    public string categoryName;
    public CardData[] easyPool;
    public CardData[] mediumPool;
    public CardData[] hardPool;
    public CardData[] masterPool;
    public CardData[] expertPool;
}
