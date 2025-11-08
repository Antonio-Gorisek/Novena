using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadContent : MonoBehaviour
{
    [SerializeField] private Transform _contentPrefab;
    [SerializeField] private GameObject _contentParent;
    [SerializeField] private GameObject _parent;

    private Coroutine _loadInstance;
    private List<GameObject> _children;
    private GameObject go;
    private int _index = 0;

    public static LoadContent instance;

    private void Awake() => instance = this;
    public void LoadData() => _loadInstance = StartCoroutine(StartLoading());

    IEnumerator StartLoading() {
        while (_index < JsonManager.instance.GetTopicLenght()) {

            yield return new WaitForSeconds(0.1f);
            Transform trans = Instantiate(_contentPrefab, Vector3.zero, Quaternion.identity);
            trans.transform.SetParent(_contentParent.gameObject.transform);
            SetTopicData(trans);
            _index++;

            SetButtonListener(trans);
        }
    }

    void SetTopicData(Transform trans)
    {
        List<string> mediaData = JsonManager.instance.GetTopicNames();
        Transform _textChild = trans.GetChild(0);
        _textChild.GetComponent<TextMeshProUGUI>().text = mediaData[_index];

        int value = _index + 1;
        GameObject _numberChild = trans.GetChild(1).GetChild(0).gameObject;
        _numberChild.GetComponent<TextMeshProUGUI>().text = value.ToString();
    }

    void SetButtonListener(Transform trans)
    {
        Button button = trans.GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            if (go == null) { go = GameObject.FindGameObjectWithTag("PlayPage"); }
            go.GetComponent<Animator>().SetBool("Page", true);

            PlayPageData.instance.SetData(
                trans.GetChild(0).GetComponent<TextMeshProUGUI>().text, 
                trans.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text);
        });
    }

    public void DestroyData()  {
        _index = 0;
        StopCoroutine(_loadInstance);
        _children = GetAllChildren(_parent);
        foreach (var item in _children) { Destroy(item); }
        _children.Clear();
    }

    List<GameObject> GetAllChildren(GameObject obj) {
        List<GameObject> children = new List<GameObject>();

        foreach (Transform child in obj.transform) {
            children.Add(child.gameObject);
            children.AddRange(GetAllChildren(child.gameObject));
        }
        return children;
    }
}
