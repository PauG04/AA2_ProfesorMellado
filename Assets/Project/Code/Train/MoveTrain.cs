using UnityEngine;

public class MoveTrain : MonoBehaviour
{
   private Animator animator;

    [SerializeField] private AudioClip door;
    [SerializeField] private AudioClip trainArrive;
    [SerializeField] private AudioClip trainLeave;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            AudioManager.Instance.PlaySFX(door);
            AudioManager.Instance.PlaySFX(trainLeave);
            LeaveTrain();
        }
    }

    private void LeaveTrain()
    {
        animator.SetBool("LeaveTrain", true);
    }

    public void CameraFadeIn()
    {
        Camera.main.GetComponent<FadeController>().StartFadeIn("Train");
    }

    public void ArriveTrain()
    {
        PlayerController.Instance.ChangeState(PlayerState.MOVE);
    }

    public void StartTrainAnimation()
    {
        AudioManager.Instance.PlaySFX(trainArrive);
        animator.SetBool("MoveTrain", true);
    }
}
