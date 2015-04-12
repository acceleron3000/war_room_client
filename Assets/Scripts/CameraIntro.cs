using UnityEngine;
using System.Collections;

public class CameraIntro : MonoBehaviour {

    public Vector3 endPosition;
    public float smoothTime = 0.3F;
    public Canvas canvas;

    private Vector3 velocity = Vector3.zero;
    
    private float endAlpha = 1f;
    private float alphaVelocity = 0f;
    private CanvasGroup cg;

    void Start()
    {
        cg = canvas.GetComponent<CanvasGroup>();
        cg.alpha = 0f;
    }
	
	void Update () {
        transform.position = Vector3.SmoothDamp(transform.position, endPosition, ref velocity, smoothTime);
        Debug.Log(velocity.y);
        if (velocity.y > -0.05)
        {
            canvas.enabled = true;
            cg.alpha = Mathf.SmoothDamp(cg.alpha, endAlpha, ref alphaVelocity, smoothTime);
        }

    }
}
