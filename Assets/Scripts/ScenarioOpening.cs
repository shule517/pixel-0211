using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class ScenarioOpening : MonoBehaviour
{
    public Light2D light2D;

    // Start is called before the first frame update
    void Start()
    {
        // 最初は真っ暗
        light2D.intensity = 0;
        Sequence moveSequence = DOTween.Sequence();

        // 目をあけた
        moveSequence.Append(DOTween.To(() => 0, (float x) => light2D.intensity = x, 1f, 5f).SetDelay(2.0f).SetEase(Ease.InQuad));
        // 光で飛ばす
        moveSequence.Append(DOTween.To(() => 1, (float x) => light2D.intensity = x, 10f, 5f).SetDelay(3.0f));

        // 社畜シーンへ切り替え
        moveSequence.OnComplete(() => SceneManager.LoadScene("社畜Scene"));
    }

    // Update is called once per frame
    void Update()
    {
    }
}
