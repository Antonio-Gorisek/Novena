using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    Image _img;
    Sprite[] _sprites;

    void Awake() => _sprites = Resources.LoadAll<Sprite>("Photos");

    IEnumerator Start()
    {
        _img = GetComponent<Image>();
        while (true)
        {
            yield return new WaitForSeconds(5f);
            _img.sprite = _sprites[Random.Range(0, _sprites.Length)];

        }
    }
}
