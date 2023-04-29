using System.Collections;
using UnityEngine.Serialization;
using UnityEngine;

public class UpDown : MonoBehaviour
{

    [Space(20)]
    [SerializeField]
    private float _speed = 1;
    
    [FormerlySerializedAs("_initPos")]
    [Space(20)]
    [SerializeField]
    private Transform _initPosTransform;
    [FormerlySerializedAs("_endPos")] [SerializeField]


    private Transform _endPosTransform;
    private Vector3 _initPos, _endPos;




    // Start is called before the first frame update
    protected void Start()
    {
        _initPos = _initPosTransform.position;
        _endPos = _endPosTransform.position;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float d = (_initPos - _endPos).magnitude;
        float delta = Mathf.PingPong(Time.time * _speed, d);
        transform.position = Vector3.Lerp(_initPos, _endPos, delta / d);
    }


}
