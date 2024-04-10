using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToStart : MonoBehaviour
{
    public string sceneName;

    private void OnMouseUp()
    {
        SceneManager.LoadScene($"{sceneName}");
    }
}
