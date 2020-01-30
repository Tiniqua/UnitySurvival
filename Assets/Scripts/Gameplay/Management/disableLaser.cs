using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableLaser : MonoBehaviour
{
    public GameObject lasers;

    void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E))
        {
            lasers.SetActive(false);
        }
    }
}
