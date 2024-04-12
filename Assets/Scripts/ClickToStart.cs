using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToStart : MonoBehaviour
{
    public string sceneName;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
