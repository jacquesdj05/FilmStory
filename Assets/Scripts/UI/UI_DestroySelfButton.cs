using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_DestroySelfButton : MonoBehaviour
{
    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
