using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class ScenarioTitle : MonoBehaviour
{
    public Light2D light2D;

    public float interval = 2.5f;
    public float maxIntensity = 1.5f;
    public float minIntensity = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        TextManager.Instance.Assign("");
        Sequence moveSequence = DOTween.Sequence();

        // 光をふわふわ
        moveSequence.Append(DOTween.To(() => minIntensity, (float x) => light2D.intensity = x, maxIntensity, interval).SetEase(Ease.InOutQuad));
        moveSequence.Append(DOTween.To(() => maxIntensity, (float x) => light2D.intensity = x, minIntensity, interval).SetEase(Ease.InOutQuad));
        moveSequence.SetDelay(0.5f);
        moveSequence.SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("決定"))
        {
            SceneManager.LoadScene("ワンルームScene");
        }
    }
}
