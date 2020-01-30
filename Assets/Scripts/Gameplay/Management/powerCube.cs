using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerCube : MonoBehaviour
{
    public Component laserCollider;
    public GameObject keyGone;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerStay()
    {
        if (Input.GetKey(KeyCode.E))
        {
            laserCollider.GetComponent<BoxCollider>().enabled = true;
            keyGone.SetActive(false);
        }
    }
}