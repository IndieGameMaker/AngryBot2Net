using UnityEngine;

public class PlaySfxRandom : MonoBehaviour
{
    public AudioClip[] sfxs;
    private new AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        int idx = Random.Range(0, sfxs.Length);
        audio.PlayOneShot(sfxs[idx]);

        
        Destroy(this.gameObject, 1.5f);
    }
}
