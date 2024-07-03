using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChallengeStage", menuName = "ScriptableObjects/ChallengeStage")]
public class ChallengeStage : ScriptableObject
{
    public CategoryData[] categories;
    public int pointMultiplier;
}
