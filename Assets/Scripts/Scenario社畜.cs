using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

public class Scenario社畜 : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        // BaseSceneのロード待ち
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        while (true)
        {
            TextManager.Instance.Speech("えっ…");

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
            yield return null;

            TextManager.Instance.Speech("ヨルちゃん やめちゃうんですか…");
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
            yield return null;

            TextManager.Instance.Speech("わかりました");
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
            yield return null;
        }
    }

    //// Start is called before the first frame update
    //async void Start()
    //{
    //    await Task.Delay(3000); // BaseSceneのロード待ち

    //    TextManager.Instance.Speech("えっ…");
    //    while (!Input.GetKeyDown(KeyCode.Z)) { await Task.Delay(1); }

    //    while (true)
    //    {
    //        await Task.Delay(1);
    //        TextManager.Instance.Speech("ヨルちゃん やめちゃうんですか…");
    //        while (!Input.GetKeyDown(KeyCode.Z)) { await Task.Delay(1); }
    //    }

    //    TextManager.Instance.Speech("わかりました");
    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("踏切Scene");
        }
    }
}
