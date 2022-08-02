using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackScript : MonoBehaviour
{
 public AudioClip[] Soundtrack;

 AudioSource Source;

 public bool MusicFade;

 void Start()
 {
    Source = GetComponent<AudioSource>();
 }

 void FixedUpdate()
 {
  if(MusicFade)
  {
    Source.volume -= Time.deltaTime / 2.8f;
  }
 }

 public void Phase2()
 {
   Source.Stop();
   Source.clip = Soundtrack[1];
   MusicFade = false;
   Source.volume = 1f;
   Source.Play();
 }

 public void Phase3()
 {
   Source.Stop();
   Source.clip = Soundtrack[2];
   MusicFade = false;
   Source.volume = 1f;
   Source.Play();
 }


}
