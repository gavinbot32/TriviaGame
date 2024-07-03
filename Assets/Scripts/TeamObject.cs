using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TeamObject : MonoBehaviour
{
    [Header("Team Values")]
    public string teamName;
    public int points;
    public Color teamColor;

    [Header("Components")]
    private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image accentImage;
    public Image highlight;
    public void Initialize(string name, Color color, int startPoints, GameManager manager)
    {
        gameManager = manager;
        teamName = name;
        points = startPoints;
        teamColor = color;
        highlight.gameObject.SetActive(false);
        UpdateUI();
    }
    public void UpdateUI()
    {
        UpdatePointText();
        nameText.text = teamName.ToString();
        accentImage.color = teamColor;
    }
    public void UpdatePointText()
    {
        pointText.text = points.ToString();
    }
    public void AddPoints(int amount)
    {
        points += amount;
        UpdatePointText();
    }
    public void RemovePoints(int amount)
    {
        points -= amount;
        UpdatePointText();
    }

}
