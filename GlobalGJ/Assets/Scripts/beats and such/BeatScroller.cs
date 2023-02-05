using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float tempoIncreaseAdjuster;
    static int currentBeat = 0;
    static int beatCount = 1;

    public static bool frogInBasE, birdInBasE, frogOutOfBasE, birdOutOfBasE; //i know, veri stuupid
    public GameObject playerManager;

    //music lists
    public AudioSource[] frogNoteList, birdNoteList;

    //stays - don't touch lul
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

        print(currentBeat);
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

        if(frogInBasE)
        {
            playerManager.GetComponent<PlayerManager>().frogLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
            switch (currentBeat)
            {
                case 1:
                    frogNoteList[0].Play();
                    break;

                case 2:
                    frogNoteList[1].Play();
                    break;

                case 3:
                    frogNoteList[2].Play();
                    break;

                case 4:
                    frogNoteList[3].Play();
                    break;

                case 5:
                    frogNoteList[4].Play();
                    break;

                case 6:
                    frogNoteList[5].Play();
                    break;

                case 7:
                    frogNoteList[6].Play();
                    break;

                case 8:
                    frogNoteList[7].Play();
                    break;

                case 9:
                    frogNoteList[8].Play();
                    break;

                case 10:
                    frogNoteList[9].Play();
                    break;

                case 11:
                    frogNoteList[10].Play();
                    break;

                case 12:
                    frogNoteList[11].Play();
                    break;

                case 13:
                    frogNoteList[12].Play();
                    break;

                case 14:
                    frogNoteList[13].Play();
                    break;

                case 15:
                    frogNoteList[14].Play();
                    break;

                case 16:
                    frogNoteList[15].Play();
                    break;

                default:
                    break;
            } //depending on which beat we are on, a certain note plays
        }

        if (birdInBasE)
        {
            playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
            switch (currentBeat)
            {
                case 1:
                    birdNoteList[0].Play();
                    break;

                case 2:
                    birdNoteList[1].Play();
                    break;

                case 3:
                    birdNoteList[2].Play();
                    break;

                case 4:
                    birdNoteList[3].Play();
                    break;

                case 5:
                    birdNoteList[4].Play();
                    break;

                case 6:
                    birdNoteList[5].Play();
                    break;

                case 7:
                    birdNoteList[6].Play();
                    break;

                case 8:
                    birdNoteList[7].Play();
                    break;

                case 9:
                    birdNoteList[8].Play();
                    break;

                case 10:
                    birdNoteList[9].Play();
                    break;

                case 11:
                    birdNoteList[10].Play();
                    break;

                case 12:
                    birdNoteList[11].Play();
                    break;

                case 13:
                    birdNoteList[12].Play();
                    break;

                case 14:
                    birdNoteList[13].Play();
                    break;

                case 15:
                    birdNoteList[14].Play();
                    break;

                case 16:
                    birdNoteList[15].Play();
                    break;

                default:
                    break;
            } //depending on which beat we are on, a certain note plays
        }

        if (frogOutOfBasE)
        {
            switch (currentBeat)
            {
                case 1:
                    playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
                    frogNoteList[0].Play();
                    break;

                case 3:
                    playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
                    frogNoteList[2].Play();
                    break;

                case 5:
                    playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
                    frogNoteList[4].Play();
                    break;

                case 7:
                    playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
                    frogNoteList[6].Play();
                    break;

                case 9:
                    playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
                    frogNoteList[8].Play();
                    break;

                case 11:
                    playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
                    frogNoteList[10].Play();
                    break;

                case 13:
                    playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
                    frogNoteList[12].Play();
                    break;

                case 15:
                    playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
                    frogNoteList[14].Play();
                    break;

                default:
                    break;
            } //depending on which beat we are on, a certain note plays
        }

        if (birdOutOfBasE)
        {
            switch (currentBeat)
            {
                case 1:
                    playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
                    birdNoteList[0].Play();
                    break;

                case 3:
                    playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
                    birdNoteList[2].Play();
                    break;

                case 5:
                    playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
                    birdNoteList[4].Play();
                    break;

                case 7:
                    playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
                    birdNoteList[6].Play();
                    break;

                case 9:
                    playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
                    birdNoteList[8].Play();
                    break;

                case 11:
                    playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
                    birdNoteList[10].Play();
                    break;

                case 13:
                    playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
                    birdNoteList[12].Play();
                    break;

                case 15:
                    playerManager.GetComponent<PlayerManager>().birdLinePoints += playerManager.GetComponent<PlayerManager>().linePointMultiplier;
                    birdNoteList[14].Play();
                    break;

                default:
                    break;
            } //depending on which beat we are on, a certain note plays
        }


        currentBeat++;
        beatCount++;

        //increase beat and song speed after 124 beats / 45-ish seconds
        if (beatCount >= 90)
        {
            BPM *= tempoIncreaseAdjuster;
            music.pitch *= tempoIncreaseAdjuster;

            foreach (var item in birdNoteList)
            {
                item.pitch *= tempoIncreaseAdjuster;
            }
            foreach (var item in frogNoteList)
            {
                item.pitch *= tempoIncreaseAdjuster;
            }
        }

        if(currentBeat > 16)
        {
            currentBeat = 1;
        }

    }
}
