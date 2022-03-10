using System.Collections.Generic;
using UnityEngine;

public class CylinderSelectionMethod : MonoBehaviour
{
    GameObject cylinder;
    GameObject cylinderParent;
    int state = 1;

    float xRotation = 0f;
    float yRotation = 0f;
    public float mouseSensitivity = 50f;

    void Update()
    {
        if (state == 1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("First Stage");
                cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                cylinder.transform.SetParent(transform);
                cylinder.name = "SelectionCylinder";
                cylinder.GetComponent<CapsuleCollider>().isTrigger = true;
                cylinder.AddComponent<CheckObject>();

                cylinder.transform.localScale = new Vector3(0.1f, 50f, 0.1f);
                cylinder.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
                cylinder.transform.localPosition = new Vector3(0f, -0.5f, 51f);
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

                    cylinder.transform.SetParent(cylinderParent.transform);

                    xRotation = cylinderParent.transform.eulerAngles.x;
                    yRotation = cylinderParent.transform.eulerAngles.y;
                    Debug.Log(xRotation + " " + yRotation);

                    // Only aplicable in Desktop
                    transform.gameObject.GetComponent<RotateCamera>().enabled = false;
                    
                    break;
                case 3:
                    CheckObject co = cylinder.GetComponent<CheckObject>();
                    int numberOfObj = co.getNumberOfObj();
                    List<string> names = co.getNamesOfObj();
                    Destroy(cylinderParent);
                    Debug.Log("Selected " + numberOfObj + " objects:");
                    for (int i = 0; i < names.Count; i++)
                    {
                        Debug.Log(names[i]);
                    }

                    state = 1;

                    // Only aplicable in Desktop
                    transform.gameObject.GetComponent<RotateCamera>().enabled = true;

                    break;
            }
        }
    }
}
