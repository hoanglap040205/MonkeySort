using UnityEngine;
using UnityEngine.SceneManagement;

public class UiPlayGame : MonoBehaviour
{

    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
