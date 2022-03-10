using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sifhao : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("x = " + transform.eulerAngles.x);
            Debug.Log("y = " + transform.eulerAngles.y);
            Debug.Log("z = " + transform.eulerAngles.z);
        }

    }
}
