using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    InputMaster InputMaster;

    void Awake()
    {

        InputMaster = new InputMaster();

        InputMaster.SceneManager.Scene1.performed += ctx => { SceneManager.LoadScene(0); };
        InputMaster.SceneManager.Scene2.performed += ctx => { SceneManager.LoadScene(1); };
        InputMaster.SceneManager.Scene3.performed += ctx => { SceneManager.LoadScene(2); };
        InputMaster.SceneManager.Scene4.performed += ctx => { SceneManager.LoadScene(3); };
        InputMaster.SceneManager.Scene5.performed += ctx => { SceneManager.LoadScene(4); };

    }

    private void OnEnable()
    {
        InputMaster.SceneManager.Enable();
    }

    private void OnDisable()
    {
        InputMaster.SceneManager.Disable();
    }

}
