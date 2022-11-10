
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class LeveManager : MonoBehaviour

{
    [SerializeField] private GameObject _loaderScene;
    [SerializeField] private Image _progressBar;
    public static LeveManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        _loaderScene.SetActive(true);
        do
        {
            await Task.Delay(100);
            _progressBar.fillAmount = scene.progress;
                
        } while (scene.progress < 0.9f);
        scene.allowSceneActivation = true;
        _loaderScene.SetActive(false);
    }

}
