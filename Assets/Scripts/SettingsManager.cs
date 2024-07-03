using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameManager gameManager;

    [Header("UI Components")]
    [SerializeField] private GameObject optionScreen;
    [SerializeField] private Slider timerSlider;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Slider soundSlider;

    [Header("Setting Values")]
    public int maxTimer;
    public float soundVolume;

    private int timer_cache;
    private float sound_cache;

    private void Start()
    {
        PullSettings();
    }

    private void PullSettings()
    {
        maxTimer = PrefsPull("int_Timer", 30);
        soundVolume = PrefsPull("float_Sound", 1f);

        timer_cache = maxTimer;
        sound_cache = soundVolume;

        timerSlider.value = timer_cache / 5;
        timerText.text = (timerSlider.value * 5).ToString();
        soundSlider.value = sound_cache;

    }

    public void OnSettingsOpen()
    {
        timer_cache = maxTimer;
        sound_cache = soundVolume;

        timerSlider.value = timer_cache / 5;
        timerText.text = timer_cache.ToString();
        soundSlider.value = sound_cache;
        optionScreen.SetActive(true);
    }

    public void OnSettingsApply()
    {
        maxTimer = timer_cache;
        soundVolume = sound_cache;

        PlayerPrefs.SetInt("int_Timer", maxTimer);
        PlayerPrefs.SetFloat("float_Sound", soundVolume);
        PlayerPrefs.Save();

        timer_cache = maxTimer;
        timerText.text = (timerSlider.value * 5).ToString();
        sound_cache = soundVolume;
        optionScreen.SetActive(false);

        if(gameManager != null)
        {
            gameManager.PullSettings();
        }

    }

    public void OnBack()
    {
        timer_cache = maxTimer;
        sound_cache = soundVolume;
        timerSlider.value = timer_cache / 5;
        timerText.text = (timerSlider.value * 5).ToString();
        soundSlider.value = sound_cache;
        optionScreen.SetActive(false);
    }

    public void OnTimerChange()
    {
        timer_cache = (int)timerSlider.value * 5;
        timerText.text = timer_cache.ToString();
    }

    public void OnSoundChange()
    {
        sound_cache = soundSlider.value;
    }

    public float PrefsPull(string key, float defaultValue = 0)
    {
        float ret = defaultValue;
        if(PlayerPrefs.HasKey(key))
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
            ret = PlayerPrefs.GetString(key,defaultValue);
        }
        return ret;
    }

}
