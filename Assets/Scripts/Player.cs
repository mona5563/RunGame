/* Player
 * 2023/11/07
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //移動スピード
    [SerializeField] float speed = 3.0f;
    //加速度
    [SerializeField] float acceleration = 0.01f;
    //左右の移動スピード
    [SerializeField] float leftRightSpeed = 4.0f;
    //移動範囲
    [SerializeField] float movingLimit = 5.0f;
    //アニメーター
    public Animator animator;
    //ジャンプ位置
    [SerializeField] Vector3 jump;
    //ジャンプ力
    [SerializeField] float jumpForce = 2.0f;
    //地面にいるか判定
    [SerializeField] bool isGround;
    //物理演算用
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyの初期化
        rb = GetComponent<Rigidbody>();
        //ジャンプ位置の初期化
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    /// <summary>
    /// キャラクターが地面に接しているか判定する
    /// </summary>
   void OnCollisionStay()
    {
        isGround = true;
    }

    /// <summary>
    /// キャラクターが地面と接している状態でなくなった事を検知する
    /// </summary>
    void OnCollisionExit()
    {
        isGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        //正面方向に指定したスピードで前進させる(ワールド空間内)
        //移動速度を一定に調整するためにdeltaTimeを使用
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);

        //加速させる
        speed += Time.deltaTime * acceleration;

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //Aキーまたは左矢印キーが押された
            if(transform.position.x > -movingLimit)
            {
                //移動範囲内だったら左へ移動する
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //Dキーまたは右矢印キーが押された
            if (transform.position.x < movingLimit)
            {
                //移動範囲内だったら右へ移動する
                transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            //スペースキーが押されたかつ地面にいたら
            //ジャンプアニメーションを起動
            animator.SetTrigger("Jump");
            //ジャンプさせる
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            //ジャンプ中は地面にいない判定にする
            isGround = false;
        }
    }
}
