using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText; // Cái này là để hiển thị điểm số, TextMeshProUGUI là một loại text trong Unity, scoreText là tên biến để code cho dễ

    private int score = 0; // Cái này là để lưu điểm số, ban đầu là 0

    public void Addscore(int soluong)
    {
        score += soluong;
        scoreText.text = "Score: " + score; // Cái này là để cập nhật điểm số trên UI, nó sẽ hiển thị "Điểm số: " và sau đó là giá trị của biến score
    }
}
