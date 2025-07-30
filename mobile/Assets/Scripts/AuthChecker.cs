using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AuthChecker : MonoBehaviour
{
    [SerializeField] private float delayBeforeRedirect = 2f; // задержка на splash

    void Start()
    {
        StartCoroutine(CheckAuthorization());
    }

    IEnumerator CheckAuthorization()
    {
        yield return new WaitForSeconds(delayBeforeRedirect);

        if (PlayerPrefs.HasKey("authToken"))
        {
            Debug.Log("✅ Пользователь авторизован, загружаем сцену 5");
            SceneManager.LoadScene(4); // MainScene
        }
        else
        {
            Debug.Log("🚫 Пользователь не авторизован, загружаем сцену 4");
            SceneManager.LoadScene(5); // LoginScene
        }
    }
}
