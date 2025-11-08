using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Animator _listPage;
    [SerializeField] private Animator _playPage;

    public void btn_Language()
    {
        _listPage.SetBool("Page", true);
        LoadContent.instance.LoadData();
    }

    public void btn_Back(int value) {
        switch (value) {
            case 0:
                _listPage.SetBool("Page", false);
                break;
            case 1:
                _playPage.SetBool("Page", false);
                break;
        }
    }
}