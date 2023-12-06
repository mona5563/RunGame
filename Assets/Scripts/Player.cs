/* Player
 * 2023/11/07
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //�ړ��X�s�[�h
    [SerializeField] float speed = 3.0f;
    //�����x
    [SerializeField] float acceleration = 0.01f;
    //���E�̈ړ��X�s�[�h
    [SerializeField] float leftRightSpeed = 4.0f;
    //�ړ��͈�
    [SerializeField] float movingLimit = 5.0f;
    //�A�j���[�^�[
    [SerializeField] Animator animator;

    //�W�����v�ʒu
    [SerializeField] Vector3 jump;
    //�W�����v��
    [SerializeField] float jumpForce = 2.0f;
    //�n�ʂɂ��邩����
    [SerializeField] bool isGround;
    //�������Z�p
    Rigidbody rb;
    //���x���
    //private float maxSpeed = 6.0f;

    //�Q�[����������
    public bool isGamePlaying;

    [SerializeField]
    private SceneController sceneController;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody�̏�����
        rb = GetComponent<Rigidbody>();
        //�W�����v�ʒu�̏�����
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        //�Q�[�����ɐݒ肷��
        isGamePlaying = true;
    }

    /// <summary>
    /// �L�����N�^�[���n�ʂɐڂ��Ă��邩���肷��
    /// </summary>
   void OnCollisionStay()
    {
        isGround = true;
    }

    /// <summary>
    /// �L�����N�^�[���n�ʂƐڂ��Ă����ԂłȂ��Ȃ����������m����
    /// </summary>
    void OnCollisionExit()
    {
        isGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[���v���C���Ȃ�
        if (isGamePlaying)
        {
            //���ʕ����Ɏw�肵���X�s�[�h�őO�i������(���[���h��ԓ�)
            //�ړ����x�����ɒ������邽�߂�deltaTime���g�p
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);

            //����������
            speed += Time.deltaTime * acceleration;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                //A�L�[�܂��͍����L�[�������ꂽ
                if (transform.position.x > -movingLimit)
                {
                    //�ړ��͈͓��������獶�ֈړ�����
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                //D�L�[�܂��͉E���L�[�������ꂽ
                if (transform.position.x < movingLimit)
                {
                    //�ړ��͈͓���������E�ֈړ�����
                    transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && isGround)
            {
                //�X�y�[�X�L�[�������ꂽ���n�ʂɂ�����
                //�W�����v�A�j���[�V�������N��
                animator.SetTrigger("Jump");
                //�W�����v������
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                //�W�����v���͒n�ʂɂ��Ȃ�����ɂ���
                isGround = false;
            }
        }
        else
        {
            //�Q�[�����I������
            EndGame();
        }
    }

    /// <summary>
    /// �Q�[�����I��������
    /// </summary>
    /// <returns></returns>
    public void EndGame()
    {
        //Idle�A�j���[�V�������Đ�
        animator.SetBool("Death", true);
        //���U���g�V�[���֑J�ڂ���
        sceneController.ChangeScene(2);
    }
}
