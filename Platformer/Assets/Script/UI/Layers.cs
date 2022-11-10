using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layers : MonoBehaviour
{
    [SerializeField] private Transform[] _layers;
    [SerializeField] private float[] _coeff;
    private int _layersCount;
    // Start is called before the first frame update
    void Start()
    {
        _layersCount = _layers.Length;
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < _layersCount; i++)
        {
            _layers[i].position = new Vector2(transform.position.x * _coeff[i], 0);
        }
    }
}
