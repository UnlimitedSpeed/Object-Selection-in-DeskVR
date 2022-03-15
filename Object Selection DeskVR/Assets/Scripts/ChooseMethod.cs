using UnityEngine;

public class ChooseMethod : MonoBehaviour
{

    [SerializeField]
    MonoBehaviour[] methods;

    int activeMethod = 0;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            methods[activeMethod].enabled = false;
            methods[0].enabled = true;
            activeMethod = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            methods[activeMethod].enabled = false;
            methods[1].enabled = true;
            activeMethod = 1;
        }

        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            methods[activeMethod].enabled = false;
            methods[0].enabled = true;
            activeMethod = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            methods[activeMethod].enabled = false;
            methods[0].enabled = true;
            activeMethod = 0;
        }*/
    }
}
