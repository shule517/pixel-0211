using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

public class Scenario�В{ : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        // BaseScene�̃��[�h�҂�
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        while (true)
        {
            TextManager.Instance.Speech("�����c");

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
            yield return null;

            TextManager.Instance.Speech("��������� ��߂��Ⴄ��ł����c");
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
            yield return null;

            TextManager.Instance.Speech("�킩��܂���");
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
            yield return null;
        }
    }

    //// Start is called before the first frame update
    //async void Start()
    //{
    //    await Task.Delay(3000); // BaseScene�̃��[�h�҂�

    //    TextManager.Instance.Speech("�����c");
    //    while (!Input.GetKeyDown(KeyCode.Z)) { await Task.Delay(1); }

    //    while (true)
    //    {
    //        await Task.Delay(1);
    //        TextManager.Instance.Speech("��������� ��߂��Ⴄ��ł����c");
    //        while (!Input.GetKeyDown(KeyCode.Z)) { await Task.Delay(1); }
    //    }

    //    TextManager.Instance.Speech("�킩��܂���");
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("����Scene");
        }
    }
}
