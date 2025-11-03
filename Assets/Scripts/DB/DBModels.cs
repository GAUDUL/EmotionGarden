using SQLite4Unity3d;

public class Character
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int emotion_points { get; set; }
}

public class CharacterItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int item_id { get; set; }
}

public class Diary
{
    [PrimaryKey]
    public string date { get; set; }
    public string mood { get; set; }
}

public class Garden
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; } 
    public string layout { get; set; }
}

public class Item
{
    [PrimaryKey]
    public int item_id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public int price { get; set; }
    public string flowers_lang { get; set; }
}
