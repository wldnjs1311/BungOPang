using UnityEngine;

public class PageSetting : MonoBehaviour
{
    public GameObject[] childPages;

    private void Start()
    {
        var cameraHeight = Camera.main.orthographicSize * 2;
        var cameraWidth = cameraHeight * Camera.main.aspect;

        childPages[0].transform.position = new Vector3(-cameraWidth, 0, 0);
        childPages[1].transform.position = Vector3.zero;
        childPages[2].transform.position = new Vector3(cameraWidth, 0, 0);
    }
}
