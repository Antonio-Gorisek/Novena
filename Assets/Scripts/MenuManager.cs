using UnityEngine;

public class MenuManager : MonoBehaviour
{
    void Start() => Application.targetFrameRate = 300;

    public void btn_Language()
    {
        _listPage.SetBool("Page", true);
        LoadContent.instance.LoadData();
    }

    public void btn_Back(int value)
    {
        if (value == 0) { _listPage.SetBool("Page", false); }
        if (value == 1) { _playPage.SetBool("Page", false); }
    }

    [SerializeField] Animator _listPage;
    [SerializeField] Animator _playPage;
}
