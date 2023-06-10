using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovePlatform : MonoBehaviour
{
    [Space(20)]
    [SerializeField]
    private float _speed = 1;

    [FormerlySerializedAs("_initPos")]
    [Space(20)]
    [SerializeField]
    private Transform _initPosTransform;
    [FormerlySerializedAs("_endPos")]
    [SerializeField]
    private Transform _endPosTransform;
    private bool move = false;


    private Vector3 _initPos, _endPos;

    void Start()
    {
        _initPos = _initPosTransform.position;
        _endPos = _endPosTransform.position;
    }
    private void Update()
    {
    }
    public void setMove(bool move)
    {
        this.move = move;
    }

    public void Move()
    {
        float d = (_initPos - _endPos).magnitude;
        float delta = Mathf.PingPong(Time.time * _speed, d);
        transform.position = Vector3.Lerp(_initPos, _endPos, delta / d);
    }

}
