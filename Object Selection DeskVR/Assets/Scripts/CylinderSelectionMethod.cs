using System.Collections.Generic;
using UnityEngine;

public class CylinderSelectionMethod : MonoBehaviour
{
    [SerializeField]
    GameObject cylinder;

    GameObject cylinderClone;
    GameObject cylinderParent;
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
        if (state == 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                cylinderClone = Instantiate(cylinder, transform.position, Quaternion.Euler(45, 45, 45));
                cylinderClone.transform.SetParent(transform);
                cylinderClone.name = "SelectionCylinder";

                cylinderClone.transform.localPosition = new Vector3(0, -1, 26);
                cylinderClone.transform.localRotation = Quaternion.Euler(90, 0, 0);
            }
        }


        if(state == 2)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                yRotation += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                xRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

                cylinderParent.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            state++;
            
            switch(state)
            {
                case 2:
                    cylinderParent = new GameObject("cylinderParent");
                    cylinderParent.transform.rotation = transform.rotation;
                    cylinderParent.transform.localPosition = new Vector3(
                                            transform.position.x + transform.forward.x,
                                            transform.position.y + transform.forward.y,
                                            transform.position.z + transform.forward.z);

                    cylinderClone.transform.SetParent(cylinderParent.transform);

                    xRotation = cylinderParent.transform.eulerAngles.x;
                    yRotation = cylinderParent.transform.eulerAngles.y;

                    // Only aplicable in Desktop
                    transform.gameObject.GetComponent<RotateCamera>().enabled = false;
                    
                    break;

                case 3:
                    CheckObject co = cylinderClone.GetComponent<CheckObject>();
                    int numberOfObj = co.getNumberOfObj();
                    List<string> names = co.getNamesOfObj();
                    Destroy(cylinderParent);
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
