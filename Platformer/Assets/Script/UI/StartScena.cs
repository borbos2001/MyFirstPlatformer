
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartScena : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Animator _animatorPlayer;
    private float _maxTime, _currentTime;
    private Image _image;
    private Color _color;
    private bool _canStart = false;
    void Start()
    {
        _gameObject.SetActive(true);
        _maxTime = 3;
        _currentTime = _maxTime;
        _image = GetComponent<Image>();
        _color = _image.color;
        _animatorPlayer.SetTrigger("WakeUp");
        StartCoroutine(Dilay());
    }
    void Update()
    {
       if(_canStart)
        {
            if (_currentTime > 0.3)
            {
                _currentTime -= Time.deltaTime;
                _color.a = _currentTime / _maxTime;
                _image.color = _color;
            }
            else
            {
                Destroy(_gameObject);
            }
        }

    }
    private IEnumerator Dilay()
    {
        yield return new WaitForSeconds(1f);
        _canStart = true;
    }

}
