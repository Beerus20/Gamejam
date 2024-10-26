using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
	{
		private static Animator     animator;

		public Move(Animator _animator)
		{
			animator = _animator;
		}

		public void Run(string action, bool activate)
		{
			animator.SetBool(action, activate);
		}
	}

public class RunningController : MonoBehaviour
{
    // DATA BASIC
    private Animator                    animator;
    public float                        walkspeed = 5f;
    
    // HASH STATE
    private int                         WalkingHash;
    private int                         WalkingBackHash;
    private int                         RunningHash;
    
    // VARIABLES
    private float                       rotspeed = 100.0f;
    private Move                        move;

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
        bool    up = Input.GetKey(KeyCode.UpArrow);
        bool    down = Input.GetKey(KeyCode.DownArrow);
        bool    left = Input.GetKey(KeyCode.LeftArrow);
        bool    right = Input.GetKey(KeyCode.RightArrow);
        bool    shift = Input.GetKey("left shift");
        bool    isWalking = animator.GetBool(WalkingHash);
        bool    isWalkingBack = animator.GetBool(WalkingBackHash);
        bool    isRunning = animator.GetBool(RunningHash);

        if (left)
            transform.Rotate(Vector3.up * -1 * rotspeed * Time.deltaTime);
        if (right)
            transform.Rotate(Vector3.up * 1 * rotspeed * Time.deltaTime);
        if (!isWalkingBack && down)
            move.Run("isWalkingBack", true);
        if (isWalkingBack && !down)
            move.Run("isWalkingBack", false);
        if (!isWalking && up)
            move.Run("isWalking", true);
        if (up)
            transform.Translate(0, 0, 2.0f * Time.deltaTime);
        if (isWalking && !up)
            move.Run("isWalking", false);
        if (!isRunning && (up && shift))
            move.Run("isRunning", true);
        if (isRunning && (!up || ! shift))
            move.Run("isRunning", false);
    }

    // velocity += Time.deltaTime * acceleration;
    // animator.SetFloat(VelocityHash, velocity);
    
    //void    Hetsika(string action, bool activate)
    //{
    //    animator.SetBool(action, activate);
    //    velocity += Time.deltaTime * acceleration;
    //    animator.SetFloat(VelocityHash, velocity);
    //}
}
