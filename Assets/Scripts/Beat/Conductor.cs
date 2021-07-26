using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private float bpm = 150;
    [SerializeField]
    private float crotchet;
    [SerializeField]
    private float songPosition; // SongPosition is the dsp position of a song.
    [SerializeField]
    private int measurePosition; // The position of the measure, this can be 1 to 8
    [SerializeField]
    private float offset = 0.2f; // Offset is the time it takes for a song to start within an mp3
    [SerializeField]
    private float startTime; // The dsp time when we start our song, since this could be a high number when the game starts.

    public static Conductor RhythmConductor;

    private void Awake()
    {
        if (RhythmConductor != null)
            Destroy(gameObject);
        RhythmConductor = this;

        audio.Play();
        startTime = (float) AudioSettings.dspTime;
        crotchet = 60 / bpm;
        CalculateSongProgress();
    }

    private void Update()
    {
        CalculateSongProgress();
    }

    private void CalculateSongProgress()
    {
        songPosition = (float)(AudioSettings.dspTime - startTime) * audio.pitch - offset;
        measurePosition = Mathf.FloorToInt(1 + ((songPosition / crotchet) * 2) % 8);
    }
}
