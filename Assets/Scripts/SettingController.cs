using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI musicValueText;
    [SerializeField] private Slider musicSlider;

    private void Awake()
    {
        LoadMusicProperties();
        musicSlider.onValueChanged.AddListener(delegate(float arg)
        {
            musicValueText.text = $"{Mathf.Round(arg)} %";
            AudioManager.Instance.SetMusicStatus(arg);
            
            PlayerPrefs.SetFloat(Utils.MusicPlayerPrefsKey, Mathf.Round(arg));
        });
    }

    private void LoadMusicProperties()
    {
        if (!PlayerPrefs.HasKey(Utils.MusicPlayerPrefsKey))
        {
            PlayerPrefs.SetFloat(Utils.MusicPlayerPrefsKey, 100);
        }

        musicSlider.value = Utils.MusicValue;
        musicValueText.text = $"{Mathf.Round(Utils.MusicValue)} %";
    }
}
