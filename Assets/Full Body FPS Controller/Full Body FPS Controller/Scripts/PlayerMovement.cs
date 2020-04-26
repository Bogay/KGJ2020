using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasySurvivalScripts
{
    public enum PlayerStates
    {
        Idle,
        Walking,
        Running,
        Jumping
    }

    public class PlayerMovement : MonoBehaviour
    {
        public List<NewBehaviourScript1> pointInTime;
        public PlayerStates playerStates;

        [Header("Inputs")]
        public string HorizontalInput = "Horizontal";
        public string VerticalInput = "Vertical";
        public string RunInput = "Run";
        public string JumpInput = "Jump";

        [Header("Player Motor")]
        [Range(1f,15f)]
        public float walkSpeed;
        [Range(1f,15f)]
        public float runSpeed;
        [Range(1f,15f)]
        public float JumpForce;
        public Transform FootLocation;

        [Header("Animator and Parameters")]
        public Animator CharacterAnimator;
        public float HorzAnimation;
        public float VertAnimation;
        public bool JumpAnimation;
        public bool LandAnimation;

        [Header("Sounds")]
        public List<AudioClip> FootstepSounds;
        public List<AudioClip> JumpSounds;
        public List<AudioClip> LandSounds;

        CharacterController characterController;

        float _footstepDelay;
        AudioSource _audioSource;
        float footstep_et = 0;
        bool startRecord = true;
        bool pressE = false;

        // Use this for initialization
        void Start()
        {
            characterController = GetComponent<CharacterController>();
            _audioSource = gameObject.AddComponent<AudioSource>();
            this.pointInTime = new List<NewBehaviourScript1>();
        }

        // Update is called once per frame
        void Update()
        {
            //handle controller
            HandlePlayerControls();

            //sync animations with controller
            SetCharacterAnimations();

            //sync footsteps with controller
            PlayFootstepSounds();
            if (Input.GetKey(KeyCode.B))
            {
                this.Play();
            }
            if (Input.GetKey(KeyCode.E))
            {
                this.pressE = true;
            }
            else
            {
                this.pressE = false;
            }
        }

        void HandlePlayerControls()
        {
            float hInput = Input.GetAxisRaw(HorizontalInput);
            float vInput = Input.GetAxisRaw(VerticalInput);

            Vector3 fwdMovement = characterController.isGrounded == true ? transform.forward * vInput : Vector3.zero;
            Vector3 rightMovement = characterController.isGrounded == true ? transform.right * hInput : Vector3.zero;

            float _speed = Input.GetButton(RunInput) ? runSpeed : walkSpeed;
            characterController.SimpleMove(Vector3.ClampMagnitude(fwdMovement + rightMovement, 1f) * _speed);

            if (characterController.isGrounded)
                Jump();

            //Managing Player States
            if (characterController.isGrounded)
            {
                if (hInput == 0 && vInput == 0)
                    playerStates = PlayerStates.Idle;
                else
                {
                    if (_speed == walkSpeed)
                        playerStates = PlayerStates.Walking;
                    else
                        playerStates = PlayerStates.Running;

                    _footstepDelay = (2/_speed);
                }
            }
            else
                playerStates = PlayerStates.Jumping;
        }

        void Jump()
        {
            if (Input.GetButtonDown(JumpInput))
            {
                StartCoroutine(PerformJumpRoutine());
                JumpAnimation = true;
            }
        }

        IEnumerator PerformJumpRoutine()
        {
            //play jump sound
            if (_audioSource)
                _audioSource.PlayOneShot(JumpSounds[Random.Range(0, JumpSounds.Count)]);

            float _jump = JumpForce;

            do
            {
                characterController.Move(Vector3.up * _jump * Time.deltaTime);
                _jump -= Time.deltaTime;
                yield return null;
            }
            while (!characterController.isGrounded);

            //play land sound
            if (_audioSource)
                _audioSource.PlayOneShot(LandSounds[Random.Range(0, LandSounds.Count)]);

        }

        void SetCharacterAnimations()
        {
            if (!CharacterAnimator)
                return;

            switch (playerStates)
            {
                case PlayerStates.Idle:
                    HorzAnimation = Mathf.Lerp(HorzAnimation, 0, 5 * Time.deltaTime);
                    VertAnimation = Mathf.Lerp(VertAnimation, 0, 5 * Time.deltaTime);
                    break;

                case PlayerStates.Walking:
                    HorzAnimation = Mathf.Lerp(HorzAnimation, 1 * Input.GetAxis("Horizontal"), 5 * Time.deltaTime);
                    VertAnimation = Mathf.Lerp(VertAnimation, 1 * Input.GetAxis("Vertical"), 5 * Time.deltaTime);
                    break;

                case PlayerStates.Running:
                    HorzAnimation = Mathf.Lerp(HorzAnimation, 2 * Input.GetAxis("Horizontal"), 5 * Time.deltaTime);
                    VertAnimation = Mathf.Lerp(VertAnimation, 2 * Input.GetAxis("Vertical"), 5 * Time.deltaTime);
                    break;

                case PlayerStates.Jumping:
                    if (JumpAnimation)
                    {
                        CharacterAnimator.SetTrigger("Jump");
                        JumpAnimation = false;
                    }
                    break;
            }

            LandAnimation = characterController.isGrounded;
            CharacterAnimator.SetFloat("Horizontal", HorzAnimation);
            CharacterAnimator.SetFloat("Vertical", VertAnimation);
            CharacterAnimator.SetBool("isGrounded", LandAnimation);
        }

        bool onGround()
        {
            bool retVal = false;

            if (Physics.Raycast(FootLocation.position, Vector3.down, 0.1f))
                retVal = true;
            else
                retVal = false;

            return retVal;
        }

        void PlayFootstepSounds()
        {
            if (playerStates == PlayerStates.Idle || playerStates == PlayerStates.Jumping)
                return;

            if (footstep_et < _footstepDelay)
                footstep_et += Time.deltaTime;
            else
            {
                footstep_et = 0;
                _audioSource.PlayOneShot(FootstepSounds[Random.Range(0, FootstepSounds.Count)]);
            }
        }
        /// <summary>
        /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
        /// </summary>
        void FixedUpdate()
        {
            if (this.startRecord)
            {
                this.Record();
            }
            
        }
        void Record()
        {
            this.pointInTime.Add(new NewBehaviourScript1(transform.position, transform.rotation, this.HorzAnimation, this.VertAnimation, this.LandAnimation, this.JumpAnimation, this.pressE));
        }
        void Play()
        {
            this.startRecord = false;
            Debug.Log("playing");
            transform.position = pointInTime[0].pos;
            transform.rotation = pointInTime[0].rotation;
            this.HorzAnimation = pointInTime[0].horizontal;
            this.VertAnimation = pointInTime[0].vertical;
            this.LandAnimation = pointInTime[0].isGround;
            this.JumpAnimation = pointInTime[0].jumpAnimation;
            this.pressE = pointInTime[0].pressE;
            pointInTime.RemoveAt(0);
        }

    }
}