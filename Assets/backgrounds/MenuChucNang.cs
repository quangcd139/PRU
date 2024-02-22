using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuChucNang : MonoBehaviour
{
    // Start is called before the first frame update
   public void ChonMan()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
   public void Thoat()
    {
        Application.Quit();
    }
}
