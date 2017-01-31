using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour {

    //  explosion sounds
    public AudioClip medium_explosionSoundsClip;

    //  sound when object is being thrown
    public AudioClip throuwSoundClip;

    //  sound when player is being damaged
    public AudioClip damageSoundClip;

    //  sound when player place the object
    public AudioClip objectPlacedSoundClip;

    //  sound when objects collide
    public AudioClip collisionSoundClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private float RandomNumber(float min, float max)
    {
        float randomNumber = Random.Range(min, max);
        return randomNumber;
    }

    public void PlayExplosionMedium(){
        audioSource.PlayOneShot(medium_explosionSoundsClip, 0.6f);
    }

    public void PlayThrowSound(){
        audioSource.PlayOneShot(throuwSoundClip, 1 );
    }

    public void PlayDamageSound() {
        audioSource.PlayOneShot(damageSoundClip, 0.6f);
    }

    public void PlayObjectPlacementSound(){
        audioSource.PlayOneShot(objectPlacedSoundClip, 0.6f);
    }

    public void PlayCollisionSound(){
        audioSource.PlayOneShot(collisionSoundClip, 0.6f);
    }
}
