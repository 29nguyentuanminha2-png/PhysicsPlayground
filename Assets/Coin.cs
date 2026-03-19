using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10; // Giá trị điểm số của đồng xu
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           FindFirstObjectByType<GameManager>().Addscore(scoreValue); // Gọi hàm Addscore trong GameManager để cộng điểm số
            Debug.Log("Đã thu thập đồng xu");
            Destroy(gameObject); // Xóa đồng xu khỏi scene sau khi thu thập
        }
    }
}