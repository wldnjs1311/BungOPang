using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PageSetting : MonoBehaviour
{
    public GameObject[] childPages;

    private void Start()
    {
        if(childPages != null)
        {
            SetChildTransform();
            //SetChildSize();
        }
    }

    private void SetChildTransform()
    {
        var cameraHeight = Camera.main.orthographicSize * 2;
        var cameraWidth = cameraHeight * Camera.main.aspect;

        childPages[0].transform.position = new Vector3(-cameraWidth, 0, 0);
        childPages[1].transform.position = Vector3.zero;
        childPages[2].transform.position = new Vector3(cameraWidth, 0, 0);
    }
    
    private void SetChildSize()
    {
        var cameraHeight = Camera.main.orthographicSize * 2;
        var cameraWidth = cameraHeight * Camera.main.aspect;

        foreach (var page in childPages)
        {
            var scaleFactorX = cameraWidth / page.transform.localScale.x;
            var scaleFactorY = cameraHeight / page.transform.localScale.y;
            var scaleFactor = Mathf.Max(scaleFactorX, scaleFactorY);

            transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
        }

    }
}
