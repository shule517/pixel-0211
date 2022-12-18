using DG.Tweening;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class ScenarioOpening : MonoBehaviour
{
    public Light2D light2D;

    // Start is called before the first frame update
    void Start()
    {
        // Å‰‚Í^‚ÁˆÃ
        light2D.intensity = 0;
        Sequence moveSequence = DOTween.Sequence();

        // –Ú‚ð‚ ‚¯‚½
        moveSequence.Append(DOTween.To(() => 0, (float x) => light2D.intensity = x, 1f, 5f).SetDelay(2.0f).SetEase(Ease.InQuad));
        // Œõ‚Å”ò‚Î‚·
        moveSequence.Append(DOTween.To(() => 1, (float x) => light2D.intensity = x, 10f, 5f).SetDelay(3.0f));

        // ŽÐ’{ƒV[ƒ“‚ÖØ‚è‘Ö‚¦
        moveSequence.OnComplete(() => SceneManager.LoadScene("ŽÐ’{Scene"));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
