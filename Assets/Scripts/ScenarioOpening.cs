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
        // �ŏ��͐^����
        light2D.intensity = 0;
        //Sequence moveSequence = DOTween.Sequence();

        // BaseScene�̃��[�h�҂�
        //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
        //yield return null;

        yield return new WaitForSeconds(1.5f);

        BgmManager.Instance.Play("�o�C�u����01");

        //TextManager.Instance.Assign("�A���[����");
        TextManager.Instance.Assign("");
        yield return new WaitForSeconds(2.5f);

        // �ڂ�������
        yield return DOTween.Sequence().Append(DOTween.To(() => 0, (float x) => light2D.intensity = x, 1f, 5f).SetEase(Ease.InQuad)).WaitForCompletion();
        TextManager.Instance.Speech("���������c (A)", 0.8f);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
        yield return null;

        TextManager.Instance.Speech("�� �A���[�����~�߂� �� (A)", 0f);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
        yield return null;

        //TextManager.Instance.Assign("�A���[�����~�߂� (A)");

        //yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
        //yield return null;

        // �A���[�����~�߂�
        BgmManager.Instance.Stop();
        audioSource.Pause();
        TextManager.Instance.Assign("");

        yield return new WaitForSeconds(2.5f);
        TextManager.Instance.Speech("���ꂽ�c (A)", 0.8f);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
        yield return null;

        TextManager.Instance.Speech("�ł��A�����s���Ȃ��� (A)", 0.8f);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
        yield return null;

        TextManager.Instance.Assign("");
        yield return new WaitForSeconds(2.5f);

        SeManager.Instance.Play("�����ւ�");
        yield return new WaitForSeconds(5.5f);
        SeManager.Instance.Stop();
        yield return new WaitForSeconds(3.5f);
        SeManager.Instance.Play("�h�A���J����3");
        yield return new WaitForSeconds(1.5f);
        SeManager.Instance.Play("�h�A��߂�2");
        yield return new WaitForSeconds(2.5f);
        SeManager.Instance.Play("�d�Ԓʉ�1");

        // ���Ŕ�΂�
        yield return DOTween.Sequence().Append(DOTween.To(() => 1, (float x) => light2D.intensity = x, 4f, 5f)).WaitForCompletion();
        yield return new WaitForSeconds(2.5f);
        BgmManager.Instance.Stop();

        // �В{�V�[���֐؂�ւ�
        SceneManager.LoadScene("�В{Scene");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
