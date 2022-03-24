using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    public GameObject model;
    public PlayerInput playerInput;

    public float walkSpeed = 1.4f;
    public float runMultiplier = 3.0f;


    [SerializeField]
    private Animator anim;

    private Rigidbody rigid;

    private Vector3 movingVec;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        anim = model.GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    // 每秒跑60次
    void Update()
    {
        // 两帧间隔 Time.deltaTime
        // print(playerInput.Dup);
        var real_runMultiplier = ((playerInput.run) ? 2.0f : 1.0f);
        anim.SetFloat("forward", playerInput.Dmag * real_runMultiplier);
        if (playerInput.Dmag > 0.1f)
        {
            // TODO
            model.transform.forward = playerInput.Dvec;
        }
        // 玩家的移动量 * 当前的方向
        movingVec = playerInput.Dmag * model.transform.forward * walkSpeed * real_runMultiplier;
    }

    // 物理引擎每秒模拟50遍 
    void FixedUpdate()
    {
        // 物理引擎两帧间隔Time.fixedDeltaTime
        // 改位置：速度*时间
        rigid.position += movingVec * Time.fixedDeltaTime;
        // 直接修改速度
        // TODO
        // rigid.velocity = new Vector3(movingVec.x, rigid.velocity.y, movingVec.z);
    }
}
