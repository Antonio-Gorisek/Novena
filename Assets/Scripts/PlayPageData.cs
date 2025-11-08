using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PlayPageData : MonoBehaviour
{
    private List<Sprite> _sprites = new List<Sprite>();
    public Image _imgDataBox;
    public TextMeshProUGUI _txtDataNumber;
    public TextMeshProUGUI _txtDataTitle;
    public static PlayPageData instance;
    private Coroutine coruntine;

    private void Awake() => instance = this;

    public void SetData(string title, string number)
    {
        _txtDataNumber.text = number;

        if (coruntine != null) { StopCoroutine(coruntine); }
        _txtDataTitle.text = title;

        coruntine = StartCoroutine(ChangeImage());

        AudioManager.instance.SelectAudio(title);
    }

    IEnumerator ChangeImage()
    {
        LoadAllSprites();
        int index = 0;
        while (true)
        {
            _imgDataBox.sprite = _sprites[index];
            index++;
            if (index >= _sprites.Count)
            {
                index = 0;
            }
            yield return new WaitForSeconds(5f);
        }
    }

    private void LoadAllSprites()
    {
        List<string> mediaData = JsonManager.instance.GetMediaData(_txtDataTitle.text);
        _sprites.Clear();
        foreach (var item in mediaData)
        {
            Sprite sprite = Resources.Load<Sprite>(item);
            _sprites.Add(sprite);
        }
    }
}
