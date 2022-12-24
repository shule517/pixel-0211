using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class ScenarioOpening : MonoBehaviour
{
    public Light2D light2D;
    public AudioSource audioSource;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        // 最初は真っ暗
        light2D.intensity = 0;
        //Sequence moveSequence = DOTween.Sequence();

        // BaseSceneのロード待ち
        //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
        //yield return null;

        yield return new WaitForSeconds(1.5f);

        BgmManager.Instance.Play("バイブ音＃01");

        //TextManager.Instance.Assign("アラーム音");
        TextManager.Instance.Assign("");
        yield return new WaitForSeconds(2.5f);

        // 目をあけた
        yield return DOTween.Sequence().Append(DOTween.To(() => 0, (float x) => light2D.intensity = x, 1f, 5f).SetEase(Ease.InQuad)).WaitForCompletion();
        TextManager.Instance.Speech("もう朝だ… (A)", 0.8f);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
        yield return null;

        TextManager.Instance.Speech("─ アラームを止める ─ (A)", 0f);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
        yield return null;

        //TextManager.Instance.Assign("アラームを止める (A)");

        //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
        //yield return null;

        // アラームを止める
        BgmManager.Instance.Stop();
        audioSource.Pause();
        TextManager.Instance.Assign("");

        yield return new WaitForSeconds(2.5f);
        TextManager.Instance.Speech("つかれた… (A)", 0.8f);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
        yield return null;

        TextManager.Instance.Speech("でも、もう行かなきゃ (A)", 0.8f);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
        yield return null;

        TextManager.Instance.Assign("");
        yield return new WaitForSeconds(2.5f);

        SeManager.Instance.Play("お着替え");
        yield return new WaitForSeconds(5.5f);
        SeManager.Instance.Stop();
        yield return new WaitForSeconds(3.5f);
        SeManager.Instance.Play("ドアを開ける3");
        yield return new WaitForSeconds(1.5f);
        SeManager.Instance.Play("ドアを閉める2");
        yield return new WaitForSeconds(2.5f);
        SeManager.Instance.Play("電車通過1");

        // 光で飛ばす
        yield return DOTween.Sequence().Append(DOTween.To(() => 1, (float x) => light2D.intensity = x, 4f, 5f)).WaitForCompletion();
        yield return new WaitForSeconds(2.5f);
        BgmManager.Instance.Stop();

        // 社畜シーンへ切り替え
        SceneManager.LoadScene("社畜Scene");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
