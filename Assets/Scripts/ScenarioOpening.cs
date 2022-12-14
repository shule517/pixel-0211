using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ScenarioOpening : MonoBehaviour
{
    public Light2D light2D;

    // Start is called before the first frame update
    void Start()
    {
        light2D.intensity = 10;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
