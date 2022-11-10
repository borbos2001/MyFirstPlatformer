using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject _thisPlatform;
    private void Awake()
    {
        Dilay();
    }
    private IEnumerator Dilay()
    {
        Debug.Log("fac");
        yield return new WaitForSeconds(3f);
        _thisPlatform.SetActive(false);
    }
}
