using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScenefirst : MonoBehaviour
{
    [SerializeField] private GameObject _roop;
    [SerializeField] private FixedJoint2D _bridge;
    [SerializeField] private GameObject _enemyCutSceneObj;
    [SerializeField] private GameObject _enemy;
    private void Start()
    {
    }
    public void bridgeBreak()
    {
        _roop.gameObject.SetActive(false);
        _bridge.breakForce = 0;
        StartCoroutine(TimeToDelete());
    }
    private IEnumerator TimeToDelete()
    {
        yield return new WaitForSeconds(3);
        _enemyCutSceneObj.gameObject.SetActive(false);
        _enemy.gameObject.SetActive(true);
    }
}
