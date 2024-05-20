using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGroundMusic : MonoBehaviour
{
    private static backGroundMusic bgM;

    private void Awake()
    {
        if (bgM == null)
        {
            bgM = this;
            DontDestroyOnLoad(bgM);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
