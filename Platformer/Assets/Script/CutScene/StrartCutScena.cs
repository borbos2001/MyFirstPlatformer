using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrartCutScena : MonoBehaviour
{

    [SerializeField] private Animator _camAnim;
    [SerializeField] private int _numOfCutScene;
    [SerializeField] private Image _upImage;
    [SerializeField] private Image _downImage;
    [SerializeField] private GameObject _textOfHero;
    [SerializeField] private Image _coverLayer;
    [SerializeField] private float _maxTime;
    [SerializeField] private GameObject _objectToStart;
    [SerializeField] private GameObject _plaaceForText;
    private bool _startOrStopText = false;
    private bool _catSceneStartOrStop = false;
    private float _currentTime, _timeToText;
    private bool _endOfCutScene = false;

    private void Start()
    {
        _currentTime = 0;
        _timeToText = _maxTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "adventurer" && !_endOfCutScene)
        {
            _plaaceForText.SetActive(true);
            _objectToStart.SetActive(true);
            collision.gameObject.GetComponent<Animator>().SetFloat("speed", 0f);
            _camAnim.SetBool("cutscene"+_numOfCutScene, true);
            _catSceneStartOrStop = true;
            Invoke(nameof(StopCutScene), 6f);
            GlobalString._canMove = false;
            StartCoroutine(Delay());
        }
    }
    private void ChangeSprite(bool _startOrStop)
    {
        if (_currentTime >= 0 && _startOrStop== false)
        {
            _currentTime -= Time.deltaTime;
            _upImage.fillAmount = _currentTime / _maxTime;
            _downImage.fillAmount = _currentTime / _maxTime;
        }
        if (_currentTime < _maxTime && _startOrStop)
        {
            _currentTime += Time.deltaTime;
            _upImage.fillAmount = _currentTime / _maxTime;
            _downImage.fillAmount = _currentTime / _maxTime;
        }
        if (_timeToText >= 0 && _startOrStopText)
        {  
           _timeToText -= Time.deltaTime;
           _coverLayer.fillAmount = _timeToText / _maxTime;
        }
    }
    private void StopCutScene()
    {
        _catSceneStartOrStop = false;
        _camAnim.SetBool("cutscene"+_numOfCutScene, false);
        GlobalString._canMove = true;
        _endOfCutScene = true;
    }
    private void Update()
    {
              ChangeSprite(_catSceneStartOrStop);
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        _startOrStopText = true;
        yield return new WaitForSeconds(0.1f);
        _textOfHero.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        _textOfHero.SetActive(false);
        _startOrStopText = false;
        _coverLayer.fillAmount = 0;
        yield return new WaitForSeconds(1.5f);
        _plaaceForText.SetActive(false);
    }
}
