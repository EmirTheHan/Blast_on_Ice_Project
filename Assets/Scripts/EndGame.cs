using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public static bool Gameover = false;
    public Animator cameraAnimator, p1Animator, p2Animator;
    public AudioSource p1fan, p2fan, whistle;
    public GameObject endGameButtons, fps, Skills, Scorboard, Esc, MainCamera, endGameCamera, endGamePositions, p1, p2;
    public Text p1score, p2score;
    private void Start()
    {
        Gameover = false;
    }
    void Update()
    {
        if (!Gameover && (GoalControl1.puan1 == 5 || GoalControl2.puan2 == 5))
        {
            Gameover = true;
            Invoke(nameof(CameraEnd), 5);
            Invoke(nameof(EGMenu), 7.5f);
            Invoke(nameof(ShowButtons), 11f);
            InvokeRepeating(nameof(Animations), 9, 2.5f);
        }
    }
    void EGMenu()
    {
        endGamePositions.SetActive(true);
        p1.SetActive(false);
        p2.SetActive(false);
        Skills.SetActive(false);
        Scorboard.SetActive(false);
        Esc.SetActive(false);
        fps.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        PauseMenu.isPaused = false;
    }
    public void CameraEnd()
    {
        whistle.Play();
        endGameCamera.SetActive(true);
        MainCamera.SetActive(false);
        cameraAnimator.SetBool("isEndGame", true);
    }
    public void Animations()
    {
        if (GoalControl2.puan2 == 5)
        {
            p1Animator.SetInteger("k", Random.Range(1, 6));
        }
        else if (GoalControl1.puan1 == 5)
        {
            p2Animator.SetInteger("k", Random.Range(1, 6));
        }
    }
    public void ShowButtons()
    {
        if (GoalControl2.puan2 == 5)
        {
            p1fan.Play();
        }
        else if (GoalControl1.puan1 == 5)
        {
            p2fan.Play();
        }
        p1score.text = GoalControl2.puan2.ToString();
        p2score.text = GoalControl1.puan1.ToString();
        endGameButtons.SetActive(true);
    }
}
