using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    class Song
    {
        string src;
        float bpm;

        public Song(string src, float bpm)
        {
            this.src = src;
            this.bpm = bpm;
        }
    }

    private AudioSource audio;
    public AudioClip song;
    public int beatsPerBar = 4;
    public float bpm = 80;
    public float beat;
    public float trackOffset = 0.2f;
    public float songposition; // Audiosettings.dspTime
                               // songposition = (float)(AudioSettings.dspTime - dsptimesong) * song.pitch - offset;
    private float dspTimeStart;
    
    void Start () {
        trackOffset = 0;
        audio = GetComponent<AudioSource>();
        audio.clip = song;
        audio.Play();
        dspTimeStart = (float)AudioSettings.dspTime + 0.2f;
	}
	
	void Update () {
        songposition = (float)(AudioSettings.dspTime - dspTimeStart) * audio.pitch - trackOffset;
    }
}
