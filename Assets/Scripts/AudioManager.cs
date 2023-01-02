using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class AudioManager : MonoBehaviour
{

    private void Awake() => instance = this;

    // ==================================================================================

    public void SelectAudio(string data)
    {
        ResetAudio(data);
        _slider.maxValue = _audioClip.length;
        if (corutine != null) { StopCoroutine(corutine); }
        corutine = StartCoroutine(FillSliderAndTime());
        _audioSource.Play();
        isPlaying = true;
        playPauseButton.sprite = pauseSprite;


        _slider.onValueChanged.AddListener((value) =>
        {
            if (corutine != null)
            {
                StopCoroutine(corutine);
            }
            _audioSource.time = value;
            corutine = StartCoroutine(FillSliderAndTime());
        });
    }

    // ==================================================================================

    private void ResetAudio(string data)
    {
        List<string> mediaData = JsonManager.instance.GetAudioData(data);
        string path = mediaData[0].Substring(0, mediaData[0].Length - 4);
        _audioClip = Resources.Load<AudioClip>(path);
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClip;
        _audioSource.time = 0;
        _slider.value = 0;
        _slider.maxValue = Mathf.Round(_audioClip.length);
    }

    // ==================================================================================

    string FormatTime(float time)
    {
        int Audiominutes = Mathf.FloorToInt(_audioSource.time / 60);
        int Audioseconds = Mathf.FloorToInt(_audioSource.time % 60);

        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        return string.Format("{0:00}:{1:00} / {2:00}:{3:00}", Audiominutes, Audioseconds, minutes, seconds);
    }

    // ==================================================================================

    public void TogglePlayPause()
    {
        if (isPlaying)
        {
            if (corutine != null) { StopCoroutine(corutine); }
            _audioSource.Pause();
            playPauseButton.sprite = playSprite;
            isPlaying = false;
        }
        else
        {
            _audioSource.Play();
            playPauseButton.sprite = pauseSprite;
            isPlaying = true;
            corutine = StartCoroutine(FillSliderAndTime());
        }
    }

    // ==================================================================================

    IEnumerator FillSliderAndTime()
    {
        while (_slider.value < _slider.maxValue)
        {
            _slider.value = _audioSource.time;

            _textTime.text = FormatTime(_audioSource.clip.length);

            yield return new WaitForSeconds(1f);
        }
    }

    // ==================================================================================

    public Slider _slider;
    public TextMeshProUGUI _textTime;
    public static AudioManager instance;

    private AudioSource _audioSource;
    private AudioClip _audioClip;
    private Coroutine corutine;

    public Image playPauseButton;
    public Sprite playSprite;
    public Sprite pauseSprite;

    private bool isPlaying;
}
