using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoDJScript : MonoBehaviour
{
    [SerializeField]private AudioClip[] songs;
    public AudioSource audioSource;
    private int _selectedIndex = -1;
    private int _playedIndex = -1;
    
    private void ChangeSong()
    {
        while (_playedIndex == _selectedIndex)
        {
            _selectedIndex = Random.Range(0, songs.Length);
        }

        _playedIndex = _selectedIndex;
        
        PlaySong(_selectedIndex);
    }

    private void PlaySong(int index)
    {
        audioSource.clip = songs[index];
        audioSource.Play();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            ChangeSong();
        }
    }
}
