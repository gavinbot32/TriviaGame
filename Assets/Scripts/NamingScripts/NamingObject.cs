using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NamingObject : MonoBehaviour
{
    public TextMeshProUGUI teamText;
    public TMP_InputField input;
    public Image accentImage;
    public Color teamColor;
    public string teamName;
    public int id;

    public Button removeButton;

    private NameManager nameManager;


    private void FixedUpdate()
    {
        if (nameManager == null) return;

        removeButton.gameObject.SetActive(nameManager.teams.Count > 1);
    }

    public void Initialize(int teamIndex, Color color, NameManager manager)
    {
        nameManager = manager;
        teamColor = color;
        accentImage.color = teamColor;
        UpdateTeamText(teamIndex);
        id = teamIndex;
    }

    public void UpdateTeamText(int teamIndex)
    {
        teamText.text = "Team " + teamIndex.ToString();
        id = teamIndex;
    }

    public void RemoveTeam()
    {
        nameManager.RemoveTeam(this);
    }

    public void OnFieldChanged()
    {
        teamName = input.text;
    }


}
