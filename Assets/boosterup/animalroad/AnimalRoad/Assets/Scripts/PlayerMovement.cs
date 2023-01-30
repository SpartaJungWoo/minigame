using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerMovement : MonoBehaviour
{

    public Touch initTouch = new Touch();
    public Vector3 originPos;
    public float positionX, positionY;
    public float speed = 0.5f, computerSpeed, dir = -1f;
    public float rotationSpeed;
    public float mapWidth = 2f;
    public bool touching = false;

    public float max_height = 3f;
    public float jump_speed = 0.6f;

    private Rigidbody rb;
    public int cnt = 0;
    public int cnt_time = 10;


    public int playerStatus = 4;
    public int tempdropdownAnimationValue = 13;



    void Start()
    {
        //Initializations
        rb = GetComponent<Rigidbody>();
        positionX = 0f;
        positionY = transform.localPosition.y;
        originPos = transform.localPosition;
    }

    void FixedUpdate()
    {

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)        //if finger touches the screen
            {
                if (touching == false)
                {
                    touching = true;
                    initTouch = touch;
                }
            }
            else if (touch.phase == TouchPhase.Moved)       //if finger moves while touching the screen
            {
                float deltaX = (initTouch.position.x - touch.position.x) * 0.4f;
                positionX -= deltaX * Time.deltaTime * speed * dir;
                positionX = Mathf.Clamp(positionX, -mapWidth, mapWidth);      //to set the boundaries of the player's position
                transform.localPosition = new Vector3(positionX, positionY, 0f);
                initTouch = touch;
            }
            else if (touch.phase == TouchPhase.Ended)       //if finger releases the screen
            {
                initTouch = new Touch();
                touching = false;
            }
        }




        //else if (touch.phase == TouchPhase.Ended)       //if finger releases the screen
        //{
        //    initTouch = new Touch();
        //    touching = false;
        //    if(touch.position.y > initTouch.position.y &&rb.velocity.y ==0)
        //        FindObjectOfType<PlayerMovement>().Jump();
        //}
        //}

        //if you play on computer---------------------------------
        // horizontal control


        float x = Input.GetAxis("Horizontal") * Time.deltaTime * computerSpeed;     //you can move by pressing 'a' - 'd' or the arrow keys
        Vector3 newPosition_x = rb.transform.localPosition + Vector3.right * x;
        newPosition_x.x = Mathf.Clamp(newPosition_x.x, -mapWidth, mapWidth);
        transform.localPosition = newPosition_x;



        // vertical control
        //float y = Input.GetAxis("Vertical") * Time.deltaTime * computerSpeed; 
        //Vector3 newPosition_y = rb.transform.localPosition + Vector3.up * y;
        //newPosition_y.y = Mathf.Clamp(newPosition_y.y, 0, max_height);
        //transform.localPosition = newPosition_y;
        //--------------------------------------------------------

        if (playerStatus == 1 && rb.transform.localPosition.y == max_height)
        {
            Vector3 newPosition_y = rb.transform.localPosition + Vector3.down * jump_speed;
            newPosition_y.y = Mathf.Clamp(newPosition_y.y, 0, max_height);
            transform.localPosition = newPosition_y;
            playerStatus = 2;
        }
        else if (playerStatus == 2 && rb.transform.localPosition.y == 0)
        {
            playerStatus = 3;
        }
        else if (playerStatus == 5 && rb.transform.localPosition.y == 0)
        {
            playerStatus = 3;
        }



        switch (playerStatus)
        {
            case 1:
                //cnt = cnt + 1;
                if (FindObjectOfType<CharacterChange>().dropdownAnimation.value != 11)
                {
                    tempdropdownAnimationValue = FindObjectOfType<CharacterChange>().dropdownAnimation.value;
                    FindObjectOfType<CharacterChange>().dropdownAnimation.value = 11;
                    FindObjectOfType<CharacterChange>().ChangeAnimation();
                }
                //else if (cnt >= cnt_time)
                //{
                //    //tempdropdownAnimationValue = FindObjectOfType<CharacterChange>().dropdownAnimation.value;
                //    FindObjectOfType<CharacterChange>().dropdownAnimation.value = tempdropdownAnimationValue;
                //    FindObjectOfType<CharacterChange>().ChangeAnimation();
                //    playerStatus = 5;
                //    cnt = 0;
                //}
                Jump();
                //playerStatus = 5;
                break;
            case 2:
                //cnt = cnt + 1;
                Gravity();

                //if (cnt >= cnt_time)
                //    //tempdropdownAnimationValue = FindObjectOfType<CharacterChange>().dropdownAnimation.value;
                //    FindObjectOfType<CharacterChange>().dropdownAnimation.value = tempdropdownAnimationValue;
                //    FindObjectOfType<CharacterChange>().ChangeAnimation();
                //    cnt = 0;


                break;
            case 3:
                FindObjectOfType<CharacterChange>().dropdownAnimation.value = tempdropdownAnimationValue;
                FindObjectOfType<CharacterChange>().ChangeAnimation();
                cnt = 0;
                playerStatus = 4;
                //Gravity();
                break;
            case 4:
                break;

            case 5:
                //cnt = cnt + 1;
                //if (cnt >= cnt_time)
                //    //tempdropdownAnimationValue = FindObjectOfType<CharacterChange>().dropdownAnimation.value;
                //    FindObjectOfType<CharacterChange>().dropdownAnimation.value = tempdropdownAnimationValue;
                //    FindObjectOfType<CharacterChange>().ChangeAnimation();

                //cnt = 0;
                Gravity();
                break;

        }


    }

    public void Jump()
    {
        if (playerStatus == 4)
            playerStatus = 1;
        //} else if (playerStatus == 1)
        //{ 
        //    playerStatus = 5;
        //}else
        //    playerStatus = 5;
        //playerStatus = 1;
        Vector3 newPosition_y = rb.transform.localPosition + Vector3.up * jump_speed;
        newPosition_y.y = Mathf.Clamp(newPosition_y.y, 0, max_height);
        transform.localPosition = newPosition_y;
        if (playerStatus == 1 && rb.transform.localPosition.y == max_height)
            playerStatus = 2;
    }

    public void Gravity()
    {
        Vector3 newPosition_y = rb.transform.localPosition + Vector3.down * jump_speed;
        newPosition_y.y = Mathf.Clamp(newPosition_y.y, 0, max_height);
        transform.localPosition = newPosition_y;

        if (rb.transform.localPosition.y == 0)
            playerStatus = 3;

    }

    //public void Jump()
    //{
    //    //y=-a*x+b에서 (a: 중력가속도, b: 초기 점프속도)
    //    //적분하여 y = (-a/2)*x*x + (b*x) 공식을 얻는다.(x: 점프시간, y: 오브젝트의 높이)
    //    //변화된 높이 height를 기존 높이 _posY에 더한다.
    //    float height = (_jumpTime * _jumpTime * (-_gravity) / 2) + (_jumpTime * _jumpPower);
    //    _transform.position = new Vector3(_transform.position.x, _posY + height, _transform.position.z);
    //    //점프시간을 증가시킨다.
    //    _jumpTime += Time.deltaTime;

    //    //처음의 높이 보다 더 내려 갔을때 => 점프전 상태로 복귀한다.
    //    if (height < 0.0f)
    //    {
    //        _isJumping = false;
    //        _jumpTime = 0.0f;
    //        _transform.position = new Vector3(_transform.position.x, _posY, _transform.position.z);
    //    }
    //}

    //public void Jump()
    //{
    //    //y=-a*x+b에서 (a: 중력가속도, b: 초기 점프속도)
    //    //적분하여 y = (-a/2)*x*x + (b*x) 공식을 얻는다.(x: 점프시간, y: 오브젝트의 높이)
    //    //변화된 높이 height를 기존 높이 _posY에 더한다.
    //    float height = (_jumpTime * _jumpTime * (-_gravity) / 2) + (_jumpTime * _jumpPower);
    //    _transform.position = new Vector3(_transform.position.x, _posY + height, _transform.position.z);
    //    //점프시간을 증가시킨다.
    //    _jumpTime += Time.deltaTime;

    //    //처음의 높이 보다 더 내려 갔을때 => 점프전 상태로 복귀한다.
    //    if (height < 0.0f)
    //    {
    //        _isJumping = false;
    //        _jumpTime = 0.0f;
    //        _transform.position = new Vector3(_transform.position.x, _posY, _transform.position.z);
    //    }
    //}


}