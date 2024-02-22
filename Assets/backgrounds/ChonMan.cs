using UnityEngine.SceneManagement;
using UnityEngine;

public class ChonMan : MonoBehaviour
{
    // Start is called before the first frame update
    public void Man1()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    public void Man2()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }
}
