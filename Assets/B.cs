using UnityEngine; // Đây là gọi thư viện Unity nè

public class B: MonoBehaviour // Đây chắc là object B, cái : này là kế thừa ở trong C# à,, nó cũng kiểu OOP là đây đúng không
{
    [Header("Di chuyển")] // Đây là cái header của mục này để biết cái file này tên là d=gì và để làm gì đúng không
    [SerializeField] private float tocDo = 5f; // Đây là tốc độ di chuyển của Object, Cái SerializeField chắc được sử dụng để có thể tuỳ chỉnh cái thông số đúng không
    [SerializeField] private float lucNhay = 7f; // Cái này là lực nhảy, f là như nào, kiểu nếu nói từng f là block thì 7f là nhảy cao 7 block à

    private Rigidbody rb; // Cái này tôi chưa hiểu mấy, sao phải khai private, Rigidbody là như nào, rb hẳn là cái viết tắt để code cho dễ rồi
    private bool isGround = false; // Cái này là để kiểm tra xem có đang trên mặt đất hay không
    void Start() // đây hẳn là hàm bắt đầu, void là kiểu trả về lúc nào nó được gọi, còn khi nào không gọi thì nó không lưu đúng không, giải thích lại cho tôi
    {
        rb = GetComponent<Rigidbody>(); // Sao phải khai như này, giải thích
        Debug.Log("Khởi động! Tìm thấy Rigidbody: " + (rb != null)); // Cái này tôi đoán là để in ra console xem nó hoạt động không vì nãy bạn bảo kiểm tra thì bảo cần kiểm tra dòng này
    }

    void Update() // Cái này tôi đoán để nó cập nhật tình hình liên tục à
    {
        float ngang = Input.GetAxis("Horizontal"); // này khai báo, có gì nói rõ hơn
        float doc = Input.GetAxis("Vertical");// này cũng vậy, giải thích rõ hơn

        UnityEngine.Vector3 huong = new UnityEngine.Vector3(ngang, 0f, doc); //không hiểu luôn, à tôi đoán là nó dùng thư viện Vector3 chiều,, giải thích thêm

        if (rb != null) // if này là để xem có rb thì mới thực hiện 
        {
            rb.linearVelocity = new UnityEngine.Vector3( //từ đây là không hiểu rồi, giải thích rõ
                huong.x * tocDo,
                rb.linearVelocity.y,
                huong.z * tocDo
            );
        }

        if (Input.GetKeyDown(KeyCode.Space) && rb != null && isGround){ // Cái này là để sử dụng phím space để nhảy // isGround là để xem có trên mặt đất không?(Buổi 2)
            rb.AddForce(UnityEngine.Vector3.up * lucNhay, ForceMode.Impulse);
            Debug.Log("Nhảy!");
        }
    }
    void OnCollisionEnter(Collision collision) // OnCollisionEnter được dùng khi bóng va chạm bất cứ thứ gì
    {
        if (collision.gameObject.CompareTag("Ground"))//CompareTag là để kiểm tra xem  nó va chạm với tag nào, ở đây là "Untagged" tức là không có tag nào, thường thì đất sẽ không có tag nên nó sẽ là "Untagged", nếu va chạm với đất thì isGround sẽ là true
        {
            isGround = true; // khi va chạm đất thì cái isGround là true
        }
   }
   void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = false; // khi rời khỏi đất thì isground là false
        }
    }  
}