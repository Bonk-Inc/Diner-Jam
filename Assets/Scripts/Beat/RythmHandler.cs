using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmHandler : MonoBehaviour {
    [SerializeField]
    private bool[] _defaultRythm = new bool[8];
    [SerializeField]
    private AudioVisualizer _audioVisualizer;
    private bool[] _currentRythm;
    private Conductor _conductor;

    private void Start() {
        _conductor = Conductor.RhythmConductor;
        _conductor.OnMeasureChange += StartRythm;
        _currentRythm = _defaultRythm;
    }

    private void OnDisable() {
        _conductor.OnMeasureChange -= StartRythm;
    }

    public void StartRythm() {
        _audioVisualizer.ShowBeat(_currentRythm, _conductor.MeasurePosition -1);
    }

    public void ChangeRythm(bool[] BeatsToShow) {
        if (BeatsToShow != null) {
            _currentRythm = BeatsToShow;
        }
    }
}
