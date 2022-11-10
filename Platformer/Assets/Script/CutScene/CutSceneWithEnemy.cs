
using UnityEngine;

public class CutSceneWithEnemy : MonoBehaviour
{
    [SerializeField] GameObject _enemyForCutScene;
    public void CutScene1()
    {
        _enemyForCutScene.SetActive(true);
    }
}
