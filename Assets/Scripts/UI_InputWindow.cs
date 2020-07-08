using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_InputWindow : Hideable
{
    [SerializeField]
    private GameObject inputField, genreSelector;


    private void Awake()
    {
        Hide();
    }

    public override void Hide()
    {
        inputField.GetComponent<TMP_InputField>().text = null;
        genreSelector.GetComponent<TMP_Dropdown>().value = 0;
        base.Hide();
    }
}
