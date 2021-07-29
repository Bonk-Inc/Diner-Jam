using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmHandler : MonoBehaviour {

    [SerializeField]
    private AudioVisualizer _audioVisualizer;
    [SerializeField]
    private ConductorEventKeeper _eventKeeper;
    [SerializeField]
    private string _defaultBeat;
    private RhythmCombo _currentRythm;
    private Conductor _conductor;

    private void Start() {
        _conductor = Conductor.RhythmConductor;
        _conductor.OnMeasureChange += StartRythm;
        _currentRythm = _eventKeeper.FindCombo(_defaultBeat);
    }

    private void OnDisable() {
        _conductor.OnMeasureChange -= StartRythm;
    }

    public void StartRythm() {
        _audioVisualizer.ShowBeat(_currentRythm, _conductor.MeasurePosition -1);
    }

    public void ChangeRythm(RhythmCombo BeatsToShow) {
        if (BeatsToShow != null) {
            _currentRythm = BeatsToShow;
        }
    }
}
