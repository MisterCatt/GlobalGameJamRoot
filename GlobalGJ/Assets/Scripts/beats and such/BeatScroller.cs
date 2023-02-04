using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    //do-stuff stuff
    public AudioSource note;
    public float tempoIncreaseAdjuster;
    static int currentBeat = 1;

    public float BPM;
    float beatsPerSecond;
    NoteObject noteObject;
    public GameObject notePrefab;
    public AudioSource music;

    private void Awake()
    {
        noteObject = this.gameObject.GetComponent<NoteObject>();
    }

    private void Update()
    {
        beatsPerSecond = noteObject.getBPS(BPM);

        transform.position -= new Vector3(0f, beatsPerSecond*Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "conductor")
        {
            DoStuffOnBeat();

            if (this.gameObject.name == "first")
            {
                music.Play();
            }

            GameObject temp = Instantiate(notePrefab, new Vector3(notePrefab.gameObject.transform.position.x, notePrefab.gameObject.transform.position.y + 1, notePrefab.gameObject.transform.position.z), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public void DoStuffOnBeat()
    {
        currentBeat += 1;
        print(currentBeat);

        //increase beat and song speed after 124 beats / 45-ish seconds
        if (currentBeat >= 70)
        {
            music.pitch *= tempoIncreaseAdjuster;
            BPM *= tempoIncreaseAdjuster;
        }

    }
}
