using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Auth()
    {
        SceneManager.LoadScene(3);
    }

    public void Registration()
    {
        SceneManager.LoadScene(6);
    }
}
