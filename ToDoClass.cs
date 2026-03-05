namespace ToDoList;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class ToDoClass : INotifyPropertyChanged
{
    int _id;
    string _title;
    string _detail;

    public int id
    {
        get => _id;
        set { _id = value; OnPropertyChanged(); }
    }

    public string title
    {
        get => _title;
        set { _title = value; OnPropertyChanged(); }
    }

    public string detail
    {
        get => _detail;
        set { _detail = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}