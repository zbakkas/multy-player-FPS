using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    public Text fpsText;
    private float deltaTime;

    void Start()
    {
        // Make sure you have a Text component attached to this GameObject
        if (fpsText == null)
        {
            Debug.LogError("FPSDisplay script requires a Text component. Attach it in the inspector.");
            enabled = false; // Disable the script if Text component is missing
        }
    }

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = "FPS: " + Mathf.Round(fps);
    }
}
