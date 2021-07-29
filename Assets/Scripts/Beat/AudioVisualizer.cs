using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioVisualizer : MonoBehaviour {
    private AudioSource _audioSource;

    private static float[] _samples = new float[512];
    private static float[] _freqBand = new float[8];

    [SerializeField]
    private float _startScale = 1, _scaleMultiplier = 10;
    [SerializeField]
    private Transform[] _soundBars = new Transform[8];
    [SerializeField]
    private  float _scaleOffset;

    private bool[] _showBeat;
    private int _currentBeat;
    private SpriteRenderer[] _barSprites;

    // Start is called before the first frame update
    private void Start() {
        _audioSource = GetComponent<AudioSource>();
        _barSprites = new SpriteRenderer[_soundBars.Length];
        for (int i = 0; i < _soundBars.Length; i++) {
            _barSprites[i] = _soundBars[i].GetComponentInChildren<SpriteRenderer>();
        }
    }

    public void ShowBeat(bool[] show, int currentBeat) {
        _showBeat = show;
        _currentBeat = currentBeat;
    }

    // Update is called once per frame
    private void LateUpdate() {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        ScaleBars();
    }

    private void GetSpectrumAudioSource() {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }
    private void MakeFrequencyBands() {
        int count = 0;
        for (int i = 0; i < 8; i++) {
            float avarage = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7) {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++) {
                avarage += _samples[count] * (count + 1);
                count++;
            }
            avarage /= count;
            _freqBand[i] = avarage * 10;
        }
    }
    private void ScaleBars() {
        float scaleY;

        for (int i = 0; i < _showBeat.Length; i++) {
            if (_showBeat[i]) {
                _barSprites[i].color = Color.green;
            } else {
                _barSprites[i].color = Color.red;
            }
        }

        for (int i = 0; i < _soundBars.Length; i++) {
            if (i == _currentBeat) {
                scaleY = (_freqBand[i] * _scaleMultiplier) + _startScale + _scaleOffset;
            } else {
                scaleY = _startScale;
            }
            _soundBars[i].localScale = new Vector3(_soundBars[i].localScale.x, scaleY, _soundBars[i].localScale.z);
        }
    }
}
