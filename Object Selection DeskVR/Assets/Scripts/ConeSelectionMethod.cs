using System.Collections.Generic;
using UnityEngine;

public class ConeSelectionMethod : MonoBehaviour
{
    [SerializeField]
    GameObject cone;

    GameObject coneClone;
    GameObject coneParent;
    int state = 1;
    float xRotation = 0f;
    float yRotation = 0f;
    public float mouseSensitivity = 50f;
    MethodControls mc;

    void Start()
    {
        mc = transform.GetComponent<MethodControls>();
    }
    
    void Update()
    {
        float scroll = Input.mouseScrollDelta.y;

        if(coneClone != null)
        {
            coneClone.transform.localScale += new Vector3(scroll, scroll, 0); 
        }

        if (state == 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                coneClone = Instantiate(cone, transform.position, Quaternion.Euler(45, 45, 45));
                coneClone.transform.SetParent(transform);
                coneClone.name = "SelectionCone";

                coneClone.transform.localPosition = new Vector3(0, -1, 1);
                coneClone.transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }

        if (state == 2)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                yRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                xRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

                coneParent.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            state++;

            switch (state)
            {
                case 2:
                    coneParent = new GameObject("coneParent");
                    coneParent.transform.rotation = transform.rotation;
                    coneParent.transform.localPosition = new Vector3(
                                            transform.position.x + transform.forward.x,
                                            transform.position.y + transform.forward.y,
                                            transform.position.z + transform.forward.z);

                    coneClone.transform.SetParent(coneParent.transform);

                    xRotation = coneParent.transform.eulerAngles.x;
                    yRotation = coneParent.transform.eulerAngles.y;

                    // Only aplicable in Desktop
                    transform.gameObject.GetComponent<RotateCamera>().enabled = false;

                    break;

                case 3:
                    CheckObject co = coneClone.GetComponent<CheckObject>();
                    int numberOfObj = co.getNumberOfObj();
                    List<string> names = co.getNamesOfObj();
                    Destroy(coneParent);
                    Debug.Log("Selected " + numberOfObj + " objects:");
                    for (int i = 0; i < names.Count; i++)
                    {
                        Debug.Log(names[i]);
                    }

                    if (mc.isFadeOutActive)
                    {
                        mc.FadeOut(names);
                    }

                    state = 1;

                    // Only aplicable in Desktop
                    transform.gameObject.GetComponent<RotateCamera>().enabled = true;

                    break;
            }
        }
        
    }
}
