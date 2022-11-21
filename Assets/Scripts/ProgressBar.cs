using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform Player;
    public Transform Finish;
    public Slider Slider;
    float _startZ;
    float _endZ;

    // Start is called before the first frame update
    void Start()
    {
        _startZ = Player.position.z;
        _endZ = Finish.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        float _currentZ = Player.position.z;
        float _progress = Mathf.InverseLerp(_startZ, _endZ, _currentZ);
        Slider.value = _progress;
    }
}
