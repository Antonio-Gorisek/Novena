using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void btn_Language()
    {
        _listPage.SetBool("Page", true);
        LoadContent.instance.LoadData();
    }

    public void btn_Back() => _listPage.SetBool("Page", false);

    [SerializeField] Animator _listPage;
}
