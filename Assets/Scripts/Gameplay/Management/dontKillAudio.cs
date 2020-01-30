using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontKillAudio : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
