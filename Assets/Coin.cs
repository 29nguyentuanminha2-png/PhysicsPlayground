using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10; // Giá trị điểm số của đồng xu
    [SerializeField] private AudioClip audioClip;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           AudioSource.PlayClipAtPoint(audioClip, transform.position); // Phát âm thanh khi thu thập đồng xu
           FindFirstObjectByType<GameManager>().Addscore(scoreValue); // Gọi hàm Addscore trong GameManager để cộng điểm số
            Debug.Log("Đã thu thập đồng xu");
            Destroy(gameObject); // Xóa đồng xu khỏi scene sau khi thu thập
        }
    }
}