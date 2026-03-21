using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI")] 
    [SerializeField] private TextMeshProUGUI timeText; // này là để hiện thị thời gian 
    [SerializeField] private TextMeshProUGUI scoreText; // Cái này là để hiển thị điểm số, TextMeshProUGUI là một loại text trong Unity, scoreText là tên biến để code cho dễ
    [SerializeField] private TextMeshProUGUI victoryText; // Hiển thị thông báo chiến thắng
    [Header("Game Settings")]
    [SerializeField] private float timelimit = 30f; // này là để limit thời gian chơi, ban đầu là 30 giây
    [SerializeField] private int Victorypoint = 50; // Cái này là để thiết lập điểm số chiến thắng, ban đầu là 50 điểm
    [SerializeField] private Button restartButton; // Cái này là để hiển thị nút khởi động lại trò chơi

    private int score = 0; // Cái này là để lưu điểm số, ban đầu là 0
    private float timer; // đếm thời gian còn lại
    private bool playgame = true; // Cái này là để kiểm tra xem trò chơi có đang diễn ra hay không, ban đầu là true
    void Start()
    {
        timer = timelimit;
        victoryText.gameObject.SetActive(false); // Ẩn thông báo chiến thắng khi bắt đầu trò chơi
    }
    void Update()
    {
        if (playgame)
        {
            timelimit -= Time.deltaTime; // này hàm giảm thời gian, Time.deltaTime là thời gian giữa các khung hình, nó giúp giảm thời gian một cách mượt mà
            timeText.text = "Time: " + Mathf.CeilToInt(timelimit); // Cái này là để cập nhật thời gian trên UI, nó sẽ hiển thị "Thời gian: " và sau đó là giá trị của biến timelimit được làm tròn lên
            if (timelimit <= 0)
            {
                playgame = false;
                timelimit = 0; // Cái này là để đảm bảo rằng thời gian không âm, nếu timelimit nhỏ hơn hoặc bằng 0, nó sẽ được đặt lại thành 0
                timeText.text = "Time: 0"; // Cái này là để cập nhật thời gian trên UI khi thời gian kết thúc, nó sẽ hiển thị "Thời gian: 0"
                victoryText.gameObject.SetActive(true); // Cái này là để hiển thị thông báo chiến thắng trên UI khi thời gian kết thúc, nó sẽ kích hoạt game object của victoryText
                victoryText.text = "Game Over!"; // Cái này là để cập nhật nội dung của victoryText thành "Game Over!" khi thời gian kết thúc
                victoryText.color = UnityEngine.Color.red; // Cái này là để thay đổi màu

                Debug.Log("Game Over!"); // Cái này là để in ra thông báo "Game Over!" trong console của Unity khi thời gian kết thúc
            }
        }
    }

    public void Addscore(int soluong)
    {
        score += soluong;
        scoreText.text = "Score: " + score; // Cái này là để cập nhật điểm số trên UI, nó sẽ hiển thị "Điểm số: " và sau đó là giá trị của biến score
        Isgameover(); // Cái này là để kiểm tra xem trò chơi đã kết thúc chưa sau khi điểm số được cập nhật
    }
    void Isgameover()
    {
        if (score >= Victorypoint)
        {
            playgame = false;
            victoryText.gameObject.SetActive(true); // Cái này là để hiển thị thông báo chiến thắng trên UI khi điểm số đạt đến Victorypoint, nó sẽ kích hoạt game object của victoryText
            victoryText.text = "You Win!"; // Cái này là để cập nhật nội dung của victoryText thành "You Win!" khi người chơi chiến thắng
            Debug.Log("You Win!"); // Cái này là để in ra thông báo "
            victoryText.color = UnityEngine.Color.green; // Cái này là để thay đổi màu sắc của victoryText thành màu xanh lá cây khi người chơi chiến thắng
        }
    }    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Cái này là để tải lại cảnh hiện tại, nó sẽ khởi động lại trò chơi khi được gọi
    }
}
