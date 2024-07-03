using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int startPoints;

    public WinScreenManager winScreenManager;
    [SerializeField] private AudioSource audio;

    [Header("Teams")]
    public List<TeamObject> teams;
    public TeamObject teamPrefab;
    public Transform teamParent;

    public TeamObject curTeam;

    [Header("Questions")]
    private bool canAnswer;
    [SerializeField] private AudioClip suspenseAudio;
    [SerializeField] private AudioClip incorrectAudio;
    [SerializeField] private AudioClip correctAudio;
    public int basePoints;
    CardData curCard;
    [SerializeField] Category cPrefab;
    [SerializeField] Transform cParent;
    [SerializeField] CategoryData[] categories;
    public List<Category> categoryObjects;
    public List<Question> cards;

    [Header("Card Object")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Animator cardAnim;
    public float maxTimer = 30;
    private float timerCooldown = 3;
    private float curTimer;
    public GameObject cardObject;
    public TextMeshProUGUI cardPointsText;
    public TextMeshProUGUI questionText;

    private void Start()
    {
        PullSettings();
    }

    public void PullSettings()
    {
        float volume = PrefsPull("float_Sound", 1f);
        maxTimer = (float)PrefsPull("int_Timer", 30);

        audio.volume = volume;
    }

    private void Update()
    {
        if (timerCooldown > 0) timerCooldown -= Time.deltaTime;
        if(curTimer > 0)
        {
            if (timerCooldown <= 0)
            {
                curTimer -= Time.deltaTime;
            }
            timerText.text = Mathf.RoundToInt(curTimer).ToString();
            if (curTimer < 0)
            {
                IncorrectAnswer();
            }
        }
    }

    public void PullTeams(List<Team> teams)
    {
        this.teams = new List<TeamObject>();
        foreach (Team team in teams)
        {
            TeamObject x = Instantiate(teamPrefab, teamParent);
            x.Initialize(team.teamName, team.teamColor, startPoints,this);
            this.teams.Add(x);
        }
        curTeam = this.teams[0];
        curTeam.highlight.gameObject.SetActive(true);
        FillBoard();
    }

    public void FillBoard()
    {
        if(categoryObjects.Count > 0)
        {
            foreach(Category cate in categoryObjects)
            {
                Destroy(cate.gameObject);
            }
        }
        categoryObjects.Clear();
        cards = new List<Question>();
        foreach(CategoryData c in categories)
        {
            Category cate = Instantiate(cPrefab, cParent);
            cate.Initialize(c, this);
            categoryObjects.Add(cate);
        }
    }

    public void NewCard(CardData card)
    {
        audio.Stop();
        timerCooldown = 3;
        curTimer = maxTimer;
        timerText.text = curTimer.ToString();
        curCard = card;
        cardPointsText.text = (basePoints * card.difficultyLevel).ToString();
        questionText.text = card.question;
        cardObject.SetActive(true);
        cardAnim.SetTrigger("OpenCard");
        audio.PlayOneShot(suspenseAudio);
        canAnswer = true;
    }

    public void CorrectAnswer()
    {
        if (!canAnswer) return;
        audio.Stop();
        curTeam.AddPoints(basePoints * curCard.difficultyLevel);
       // cardObject.SetActive(false);
        cardAnim.SetTrigger("CloseCard");
        canAnswer = false;
        NextTurn();
        audio.PlayOneShot(correctAudio);
    }

    public void IncorrectAnswer()
    {
        if (!canAnswer) return;
        audio.Stop();
        curTeam.RemovePoints(basePoints * curCard.difficultyLevel);
       // cardObject.SetActive(false);
        cardAnim.SetTrigger("CloseCard");
        canAnswer = false;
        NextTurn();
        audio.PlayOneShot(incorrectAudio);
    }

    public void NextTurn()
    {

       
        if (WinCheck()) return;
        curTeam.highlight.gameObject.SetActive(false);
        int index = teams.IndexOf(curTeam);
        index++;
        if(index >= teams.Count)
        {
            index = 0;
            if (cards.Count < teams.Count)
            {
                EndGame();
                return;
            }
        }
        curTeam = teams[index];
        curTeam.highlight.gameObject.SetActive(true);

    }

    public bool WinCheck()
    {
        if(cards.Count <= 0)
        {
            EndGame();
            return true;
        }
        return false;
    }

    public void EndGame()
    {
        TeamObject winner = teams[0];
        foreach (TeamObject team in teams)
        {
            if (team.points > winner.points)
            {
                winner = team;
            }
        }
        winScreenManager.gameObject.SetActive(true);
        winScreenManager.Initialize(winner);
    }


    public float PrefsPull(string key, float defaultValue = 0)
    {
        float ret = defaultValue;
        if (PlayerPrefs.HasKey(key))
        {
            ret = PlayerPrefs.GetFloat(key, defaultValue);
        }
        return ret;
    }
    public int PrefsPull(string key, int defaultValue = 0)
    {
        int ret = defaultValue;
        if (PlayerPrefs.HasKey(key))
        {
            ret = PlayerPrefs.GetInt(key, defaultValue);
        }
        return ret;
    }
    public string PrefsPull(string key, string defaultValue = "")
    {
        string ret = defaultValue;
        if (PlayerPrefs.HasKey(key))
        {
            ret = PlayerPrefs.GetString(key, defaultValue);
        }
        return ret;
    }


}
