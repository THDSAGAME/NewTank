using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using TMPro;
using System;

public class DataPlayer
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Gold { get; set; }
    public List<int> Items { get; set; }
    public DateTime Day { get; set; }
    public List<int> Equipments { get; set; }
    public bool Music { get; set; }
    public bool Sound { get; set; }
}
public class LoadingData : MonoBehaviour
{
    public List<DataPlayer> players;
    string filePath;
    [SerializeField] private LoadingGame LoadingGame;
    [SerializeField] private Player playerMove;
    [SerializeField] private TMP_InputField namePlayer;
    [SerializeField] private ObjectManager objectManager;
    // Start is called before the first frame update
    void Start()
    {
        filePath = "Assets/Datas/dataGame.json";
        players = ReadPlayersFromFile(filePath);

        // Hiển thị thông tin của tất cả người chơi
        foreach (var player in players)
        {
            Debug.Log($"Name: {player.Name}, Level: {player.Level}, Gold: {player.Gold}");
        }
    }
    public void Login()
    {
        string nameNewPlayer = namePlayer.text;
        if (nameNewPlayer.Length > 0)
        {
            int id = -1;
            int i = 0;
            foreach (var player in players)
            {
                if (nameNewPlayer == player.Name)
                {
                    id = i;
                    break;
                }
                i++;
            }
            if (id != -1)
            {
                playerMove.idPlayer = id;
            }
            else
            {
                playerMove.idPlayer = players.Count;
                // Thêm một tài khoản mới
                DataPlayer newPlayer = new DataPlayer
                {
                    Name = nameNewPlayer,
                    Level = 1,
                    Gold = 50,
                    Items = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    Day = DateTime.Now,
                    Equipments = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    Music = true,
                    Sound = true
                };
                players.Add(newPlayer);
                // Lưu lại thông tin vào file JSON
                SavePlayersToFile(filePath, players);
            }
            objectManager.login.SetActive(false);
            objectManager.play.SetActive(true);
            objectManager.play.SetActive(true);
        }    
        
    }    
    static List<DataPlayer> ReadPlayersFromFile(string filePath)
    {
        // Đọc dữ liệu từ file JSON và chuyển đổi thành List<Player>
        if (File.Exists(filePath))
        {
            string jsonContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<DataPlayer>>(jsonContent);
        }

        // Nếu file không tồn tại, trả về một List<Player> mới
        return new List<DataPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    static void SavePlayersToFile(string filePath, List<DataPlayer> players)
    {
        // Chuyển đối List<Player> thành chuỗi JSON và lưu vào file
        string jsonContent = JsonConvert.SerializeObject(players, Formatting.Indented);
        File.WriteAllText(filePath, jsonContent);
    }
}
