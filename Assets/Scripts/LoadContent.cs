using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoadContent : MonoBehaviour
{
    private void Awake() => instance = this;
    public void LoadData() => _loadInstance = StartCoroutine(StartLoading());

    // =================================================================

    IEnumerator StartLoading() {
        while (_index <= 100) {

            yield return new WaitForSeconds(0.1f);
            Transform go = Instantiate(_contentPrefab, Vector3.zero, Quaternion.identity);
            go.parent = _contentParent.transform;
            _index++;
        }
    }

    // =================================================================

    public void DestroyData()  {
        _index = 0;
        StopCoroutine(_loadInstance);
        _children = GetAllChildren(_parent);
        foreach (var item in _children) { Destroy(item); }
        _children.Clear();
    }

    // =================================================================
    List<GameObject> GetAllChildren(GameObject obj) {
        List<GameObject> children = new List<GameObject>();

        foreach (Transform child in obj.transform) {
            children.Add(child.gameObject);
            children.AddRange(GetAllChildren(child.gameObject));
        }
        return children;
    }

    // =================================================================


    [SerializeField] Transform _contentPrefab;
    [SerializeField] GameObject _contentParent;
    [SerializeField] GameObject _parent;

    private Coroutine _loadInstance;
    private List<GameObject> _children;
    public static LoadContent instance;
    private int _index = 0;
}
