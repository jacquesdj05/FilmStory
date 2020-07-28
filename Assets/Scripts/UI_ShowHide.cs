using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ShowHide : Hideable
{
    public bool startVisible = false;

    private void Awake()
    {
        if (!startVisible)
            Hide();
    }
}
