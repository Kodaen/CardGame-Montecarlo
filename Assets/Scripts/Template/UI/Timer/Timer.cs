using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private VoidEventChannel _timesUpEvent;
    [SerializeField] private float _startingTime = 30f;
    [SerializeField] private bool _isLooping;

    private TextMeshProUGUI _tmpText;
    private float _currentTime;
    private bool _isFinished;

    private void Awake()
    {
        _tmpText = GetComponent<TextMeshProUGUI>();
        ResetTime();
    }

    private void ResetTime()
    {
        _currentTime = _startingTime;
    }

    private void Update()
    {
        if (_isFinished) return;

        _currentTime = Mathf.Max(0, _currentTime - Time.deltaTime);
        _tmpText.text = _currentTime.ToString("0");

        if (_currentTime == 0)
        {
            _timesUpEvent.RaiseEvent();
            if (_isLooping) ResetTime();
            else _isFinished = true;
        }
    }
}
