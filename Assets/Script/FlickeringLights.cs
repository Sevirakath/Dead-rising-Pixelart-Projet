using UnityEngine;

public class FlickeringLights : MonoBehaviour
{
    public float flickerInterval = 0.1f; // Time interval between flickers
    public float minIntensity = 0.5f; // Minimum intensity of the light
    public float maxIntensity = 1f; // Maximum intensity of the light
    public float minNonZeroIntensity = 0.1f; // Minimum intensity to prevent complete disappearance

    private UnityEngine.Rendering.Universal.Light2D light2D;
    private float timer;
    private float targetIntensity;

    private void Start()
    {
        light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        targetIntensity = Random.Range(minIntensity, maxIntensity);
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            light2D.intensity = targetIntensity;

            if (targetIntensity <= minNonZeroIntensity)
            {
                targetIntensity = Random.Range(minNonZeroIntensity, maxIntensity);
            }
            else
            {
                targetIntensity = Random.Range(minIntensity, maxIntensity);
            }

            timer = flickerInterval;
        }
    }
}