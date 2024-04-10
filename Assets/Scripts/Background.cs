using UnityEngine;

public class Background : MonoBehaviour
{
    private SpriteRenderer sr_;

    private void Awake()
    {
        sr_ = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        var cameraHeight = Camera.main.orthographicSize * 2;
        var cameraWidth = cameraHeight * Camera.main.aspect;
        
        if(sr_ != null)
        {
            var spriteSize = sr_.sprite.bounds.size;

            var scaleFactorX = cameraWidth / spriteSize.x;
            var scaleFactorY = cameraHeight / spriteSize.y;
            var scaleFactor = Mathf.Max(scaleFactorX, scaleFactorY);

            transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
        }
    }
}
