using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinScreenManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI pointText;

    [SerializeField] ParticleSystem particles;

    [SerializeField] private TeamObject winner;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Initialize(TeamObject winTeam)
    {
        winner = winTeam;
        particles.startColor = winner.teamColor;
        winText.text = winTeam.teamName;
        pointText.text = winTeam.points.ToString();
        anim.SetTrigger("Win");
    }

}
