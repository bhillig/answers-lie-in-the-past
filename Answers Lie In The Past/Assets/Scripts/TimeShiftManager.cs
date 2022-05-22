using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// this class will hold the state of timeshift mechanic as well as store config info for the time shift
public class TimeShiftManager : MonoBehaviour
{
    [SerializeField]
    private string _pastSceneName;

    [SerializeField]
    private string _presentSceneName;

    private bool _inPresent = true; // is the player in the present
    private bool _inPast = false; // is the player in the past


    public static TimeShiftManager instance { get; set; }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void TimeShift()
    {
        string sceneToLoad = _pastSceneName;

        if(_inPresent)
        {
            _inPresent = false;
            _inPast = true;
            sceneToLoad = _pastSceneName;
        }
        else if(_inPast)
        {
            _inPast = false;
            _inPresent = true;
            sceneToLoad = _presentSceneName;
        }

        
        StartCoroutine(LoadSceneAfterOneSecond(sceneToLoad));
    }

    IEnumerator LoadSceneAfterOneSecond(string sceneToLoad)
    {
        FindObjectOfType<TimeShiftDissolve>().TurnOnDissolve();
        PlayerController.instance.DisableMovement();
        PlayerController.instance.SetGravity(0);
        yield return new WaitForSeconds(1.0f);

        if (_inPast)
            SoundManager.instance.PlayMusicTrack("past");
        else
            SoundManager.instance.PlayMusicTrack("present");

        SceneManager.LoadScene(sceneToLoad);
        PlayerController.instance.TransferPositionOnTimeShift();
        PlayerController.instance.EnableMovement();
        PlayerController.instance.SetGravity(1);
        FindObjectOfType<TimeShiftDissolve>().TurnOnCondense();
    }
    
}
