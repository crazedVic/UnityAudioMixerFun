using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider sliderMusic;
    [SerializeField] Slider sliderMenu;
    [SerializeField] Slider sliderGame;
    [SerializeField] AudioSource audioMenu;
    [SerializeField] AudioSource audioMusic;
    [SerializeField] AudioSource audioGame;

    // Update is called once per frame
    void Update()
    {
        float volume;
        audioMixer.GetFloat("MusicVolume", out volume);
        sliderMusic.value = volume;

        audioMixer.GetFloat("GameVolume", out volume);
        sliderGame.value = volume;

        audioMixer.GetFloat("MenuVolume", out volume);
        sliderMenu.value = volume;
    }

    public void ButtonClick()
    {
      
         audioMenu.Play();
        
    }

    public void MusicSliderChange()
    {
        audioMixer.SetFloat("MusicVolume", sliderMusic.value);
    }

    public void MenuSliderChange()
    {
        audioMixer.SetFloat("MenuVolume", sliderMenu.value);
    }

    public void GameSliderChange()
    {
        audioMixer.SetFloat("GameVolume", sliderGame.value);
    }

    public void OnDragStart(BaseEventData data) {
        switch (data.selectedObject.name)
        {
            case "SliderMenu":
                audioMenu.loop = true;
                audioMenu.Play();
                break;
            case "SliderGame":
                audioGame.Play();
                break;
            case "SliderMusic":
                audioMusic.Play();
                break;
        }
    }

    public void OnDragEnd(BaseEventData data) {
        switch (data.selectedObject.name)
        {
            case "SliderMenu":
                audioMenu.loop = false;
                audioMenu.Stop();
                break;
            case "SliderGame":
                audioGame.Stop();
                break;
            case "SliderMusic":
                audioMusic.Stop();
                break;
        }
    }
}
