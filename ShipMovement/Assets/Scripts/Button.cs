using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public int sceneToLoad = 0;
    // Start is called before the first frame update
    public void onClickMainScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
