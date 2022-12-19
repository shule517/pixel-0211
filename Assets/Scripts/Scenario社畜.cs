using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenario社畜 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float audioPitch = 2.5f;
        var talkingText = "カタカタ・・・ ・・・";
        TextManager.Instance.TalkText(audioPitch, talkingText);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("踏切Scene");
        }
    }
}
