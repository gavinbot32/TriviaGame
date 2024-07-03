using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameManager : MonoBehaviour
{
    public List<NamingObject> teams;
    public List<Color> colors;
    public Transform teamParent;
    public Button addButton;

    public Animator anim;
    public NamingObject namingPrefab;
    [SerializeField] private GameManager gameManager;

    public int maxTeams = 6;

    private void Start()
    {
        NewTeam();
    }

    public void NewTeam()
    {
        if (teams.Count >= maxTeams) return;
        NamingObject team = Instantiate(namingPrefab, teamParent);
        Color x = colors[Random.Range(0, colors.Count)];
        colors.Remove(x);
        teams.Add(team);
        team.Initialize(teams.Count, x, this);
        if (teams.Count >= maxTeams) addButton.gameObject.SetActive(false);
    }

    public void RemoveTeam(NamingObject team)
    {
        teams.Remove(team);
        colors.Add(team.teamColor);
        Destroy(team.gameObject);

        for(int i = 0; i < teams.Count; i++)
        {
            teams[i].UpdateTeamText(i + 1);
        }
        if (teams.Count < maxTeams) addButton.gameObject.SetActive(true);
    }

    public void ConfirmNames()
    {
        List<Team>  finalTeams = new List<Team>();
        foreach(NamingObject team in teams)
        {
            if(team.teamName == "")
            {
                team.teamName = team.teamText.text;
            }
            Team x = new Team();
            x.Initialize(team.id, team.teamName, team.teamColor);
            finalTeams.Add(x);
        }
        gameManager.PullTeams(finalTeams);
        anim.SetTrigger("Transition");
    }

    public void SetActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

}
