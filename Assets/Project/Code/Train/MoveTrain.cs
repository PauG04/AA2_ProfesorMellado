using UnityEngine;

public class MoveTrain : MonoBehaviour
{
   private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
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
        animator.SetBool("MoveTrain", true);
    }
}
