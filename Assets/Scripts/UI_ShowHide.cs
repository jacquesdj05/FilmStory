﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ShowHide : Hideable
{
    public bool isCreateFilmButton = false;

    private void Awake()
    {
        if (!isCreateFilmButton)
            Hide();
    }
}
