using UnityEngine;

public class Moving : MonoBehaviour
{
    [Header("Di chuyển")]
    [SerializeField] private float tocDo = 2f;
    [SerializeField] private float khoangCach = 3f;

    private UnityEngine.Vector3 viTriBatDau;
    private UnityEngine.Vector3 viTriKetThuc;

    void Start()
    {
        viTriBatDau = transform.position;
        viTriKetThuc = viTriBatDau + new UnityEngine.Vector3(khoangCach, 0f, 0f);
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * tocDo, 1f);
        transform.position = UnityEngine.Vector3.Lerp(viTriBatDau, viTriKetThuc, t);
    }
}