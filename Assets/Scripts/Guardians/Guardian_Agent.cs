using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;
using Random=UnityEngine.Random;

public class Guardian_Agent : MonoBehaviour
{
    public Transform[] outposts;
    public GameObject player;
    private NavMeshAgent _agent;
    private int _outpostsNumber;
    private bool _isChasing = true;
    private int _selectedOutpost = 0;
    public AudioClip clicker;
    private float _soundTimeout = 5;
    private AudioSource _audioSource;

    void Start ()
    {        
        _audioSource = gameObject.GetComponent<AudioSource>();
        for (int i = 0; i < outposts.Length; i++)
        {
            _outpostsNumber++;
        }

        for (int j = 0; j < _outpostsNumber; j++)
        {
            Debug.Log("Point " + (j+1));
            outposts[j] = GameObject.Find("Point " + (j + 1)).transform.transform;
        }
        
        player = GameObject.Find("Player");
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 50)
        {
            ChasePlayer();
            _isChasing = true;

            if (Vector3.Distance(player.transform.position, transform.position) < 25)
            {
                _soundTimeout -= Time.deltaTime * 1f;

                if (_soundTimeout < 0)
                {
                    _audioSource.PlayOneShot(clicker);
                    _soundTimeout = Random.Range(0, 10);
                }
            }
        }
        else
        {
            if (_isChasing)
            {
                _selectedOutpost = ChooseOutpost();
                _isChasing = false;
            }
            
            _agent.destination = outposts[_selectedOutpost].transform.position;
            Debug.Log(outposts[_selectedOutpost].gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Outpost"))
        {
            _selectedOutpost = ChooseOutpost();
        }
    }

    int ChooseOutpost()
    { return Random.Range(0, _outpostsNumber); }

    private void ChasePlayer()
    {
        _agent.destination = player.transform.position;
    }
}
