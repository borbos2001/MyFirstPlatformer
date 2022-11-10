using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class boos : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    [SerializeField] private GameObject[] _platforms;
    [SerializeField] private Animator _deadPlace;
    [SerializeField] private Transform[] _firePoint;
    [SerializeField] private Transform[] _firePoint2;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject[] _platforms4;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private float _fiteSpeed;
    [SerializeField] private GameObject _laser;
    [SerializeField] private Image _hp;
    [SerializeField] private GameObject _dead;
    [SerializeField] private SpriteRenderer _boos;
    [SerializeField] private float _hpBossMax;
    [SerializeField] private GameObject _boosText;
    private float _hpBoss;
    private float _currentTime;
    private int _numOfEvent;
    private void Awake()
    {
        _currentTime = _maxTime;
        _hpBoss = _hpBossMax;
    }

    void Update()
    {
        _currentTime -= Time.deltaTime;
        if (_currentTime < 0)
        {
            _currentTime = _maxTime * 1.5f;
            Event();
        }
    }
    private void Event()
    {
        if (_hpBoss > 0)
        {
            _numOfEvent = Random.Range(0, 4);
            Debug.Log(_numOfEvent);
            switch (_numOfEvent)
            {
                case 0:
                    FirstEvent();
                    _hpBoss = _hpBoss - 1;
                    _hp.fillAmount = (_hpBoss / _hpBossMax) ;
                    break;
                case 1:
                    SecoundEvent();
                    _hpBoss = _hpBoss - 1;
                    _hp.fillAmount = (_hpBoss / _hpBossMax) ;
                    break;
                case 2:
                    ThirdEvent();
                    _hpBoss = _hpBoss - 1;
                    _hp.fillAmount = (_hpBoss / _hpBossMax) ;
                    break;
                case 3:
                    FourthEvent();
                    _hpBoss = _hpBoss - 1;
                    _hp.fillAmount = (_hpBoss / _hpBossMax) ;
                    break;
            }
        }
        else
        {
            StartCoroutine(DilayWin());
        }
    }
    private void FirstEvent()
    {
        StartCoroutine(Dilay());
    }
    private IEnumerator Dilay()
    {
        _platforms[0].SetActive(true);
        yield return new WaitForSeconds(2f);
        _deadPlace.SetBool("play", true);
        for (int i = 1; i < _platforms.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            _platforms[i].SetActive(true);
        }
        _platforms[0].SetActive(false);
        yield return new WaitForSeconds(1f);
        for (int i = 1; i < _platforms.Length-1; i++)
        {
            yield return new WaitForSeconds(0.5f);
            _platforms[i].SetActive(false);
        }
        _deadPlace.SetBool("play", false);
        yield return new WaitForSeconds(3f);
        _platforms[_platforms.Length - 1].SetActive(false);
    }
    private void SecoundEvent()
    {
        StartCoroutine(SecoundDilay());
    }
    private IEnumerator SecoundDilay()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
            for (int j = Random.Range(0, 2); j < _firePoint.Length - Random.Range(0, 2); j++)
            {
                GameObject currentBullet = Instantiate(_bullet, _firePoint[j].position, Quaternion.identity);
                Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
                currentBulletVelocity.velocity = new Vector2(_fiteSpeed * -1, 0);
            }
        }
    }
    private void ThirdEvent()
    {
        StartCoroutine(ThirdDilay());
    }
    private IEnumerator ThirdDilay()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1f);
            for (int j = Random.Range(0, 2); j < _firePoint2.Length - Random.Range(0, 2); j++)
            {
                GameObject currentBullet = Instantiate(_bullet, _firePoint2[j].position, Quaternion.identity);
                Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
                currentBulletVelocity.velocity = new Vector2(_fiteSpeed * 1, 0);
            }
        }
    }
    private void FourthEvent()
    {
        StartCoroutine(FourthDilay());
    }
    private IEnumerator FourthDilay()
    {
        for (int i = 0; i < _platforms4.Length/2; i++)
        {
            yield return new WaitForSeconds(0.5f);
            _platforms4[i].SetActive(true);
            _platforms4[i+ _platforms4.Length/2].SetActive(true);
        }

        for (int j = 0; j < 5; j++)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            GameObject currentBullet = Instantiate(_laser, _playerPosition.position, Quaternion.identity);
        }
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < _platforms4.Length/2; i++)
        {
            _platforms4[i].SetActive(false);
            _platforms4[i + _platforms4.Length / 2].SetActive(false);
        }
    }
    private IEnumerator DilayWin()
    {
        yield return new WaitForSeconds(3f);
        _dead.SetActive(true);
        yield return new WaitForSeconds(2f);
        _boos.enabled = false;
        _boosText.SetActive(false);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}