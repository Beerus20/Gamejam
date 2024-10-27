using UnityEngine;
using UnityEngine.SceneManagement;

public class RunningController : MonoBehaviour
{
    // DATA BASIC
    private Animator animator;
    public float walkspeed = 5f;
    public float baseSpeed = 2.0f;
    public float runMultiplier = 2.0f;

    // HASH STATE
    private int WalkingHash;
    private int WalkingBackHash;
    private int RunningHash;

    // VARIABLES
    private float rotspeed = 100.0f;
    private Move move;

    // Move Class
    private class Move
    {
        private Animator animator;

        public Move(Animator _animator)
        {
            animator = _animator;
        }

        public void Run(string action, bool activate)
        {
            animator.SetBool(action, activate);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        move = new Move(animator);
        WalkingHash = Animator.StringToHash("isWalking");
        WalkingBackHash = Animator.StringToHash("isWalkingBack");
        RunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);
        bool left = Input.GetKey(KeyCode.LeftArrow);
        bool right = Input.GetKey(KeyCode.RightArrow);
        bool shift = Input.GetKey(KeyCode.LeftShift);
        bool isWalking = animator.GetBool(WalkingHash);
        bool isWalkingBack = animator.GetBool(WalkingBackHash);
        bool isRunning = animator.GetBool(RunningHash);

        if (left)
            transform.Rotate(Vector3.up * -1 * rotspeed * Time.deltaTime);
        if (right)
            transform.Rotate(Vector3.up * 1 * rotspeed * Time.deltaTime);

        // Walking Back
        if (!isWalkingBack && down)
            move.Run("isWalkingBack", true);
        if (isWalkingBack && !down)
            move.Run("isWalkingBack", false);
        if (down)
        {
            float currentSpeed = isRunning ? baseSpeed * runMultiplier : baseSpeed;
            transform.Translate(0, 0, -currentSpeed * Time.deltaTime);
        }

        // Walking Forward
        if (!isWalking && up)
            move.Run("isWalking", true);
        if (up)
        {
            float currentSpeed = isRunning ? baseSpeed * runMultiplier : baseSpeed;
            transform.Translate(0, 0, currentSpeed * Time.deltaTime);
        }
        if (isWalking && !up)
            move.Run("isWalking", false);

        // Running Logic
        if (!isRunning && (up && Input.GetKey(KeyCode.LeftShift)))
        {
            isRunning = true;
            move.Run("isRunning", true);
        }
        if (isRunning && (!up || !Input.GetKey(KeyCode.LeftShift)))
        {
            isRunning = false;
            move.Run("isRunning", false);
        }
    }

    // Check for collision with enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
