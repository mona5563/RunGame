/*Collectable
 * 2023/11/10
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //�A�C�e���̉�]���x
    [SerializeField] float rotateSpeed = 0.5f;
    //�Q�[���}�l�[�W���[
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //�Q�[���N������GameManager��ݒ肷��
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Y����]���s��
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }

    /// <summary>
    /// �Փ˔��菈��
    /// </summary>
    /// <param name="other">���������I�u�W�F�N�g</param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //player�ɓ���������X�R�A�̌v�Z��SE�̍Đ����s��
            gameManager.UpdateScore();
            //�I�u�W�F�N�g��j�󂷂�
            Destroy(gameObject);

        }
    }
}
