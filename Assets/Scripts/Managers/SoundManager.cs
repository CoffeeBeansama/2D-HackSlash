using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HackSlash.Enemies;

namespace HackSlash
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance { get; private set; }
        private AudioSource source;
        
        public AudioSource HurtSource;


        private void OnEnable()
        {
            instance = this;
            source = GetComponent<AudioSource>();
            
        }

       
     


        public void PlaySound(AudioClip sfx)
        {
            source.PlayOneShot(sfx);
        }
    }
}
