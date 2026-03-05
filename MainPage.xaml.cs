using System.Collections.ObjectModel;

namespace ToDoList;

public partial class MainPage : ContentPage
{
    ObservableCollection<ToDoClass> todoItems = new();
    int currentId = 1;
    ToDoClass selectedItem;

    public MainPage()
    {
        InitializeComponent();
        todoLV.ItemsSource = todoItems;
    }

    void AddToDoItem(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(titleEntry.Text))
            return;

        ToDoClass item = new()
        {
            id = currentId++,
            title = titleEntry.Text,
            detail = detailsEditor.Text
        };

        todoItems.Add(item);

        titleEntry.Text = "";
        detailsEditor.Text = "";
    }

    void DeleteToDoItem(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int id = int.Parse(btn.ClassId);

        var item = todoItems.FirstOrDefault(x => x.id == id);
        if (item != null)
            todoItems.Remove(item);
    }

    void TodoLV_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        selectedItem = (ToDoClass)e.SelectedItem;
    }

    void todoLV_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        selectedItem = (ToDoClass)e.Item;

        titleEntry.Text = selectedItem.title;
        detailsEditor.Text = selectedItem.detail;

        addBtn.IsVisible = false;
        editBtn.IsVisible = true;
        cancelBtn.IsVisible = true;
    }

    void EditToDoItem(object sender, EventArgs e)
    {
        if (selectedItem == null) return;

        selectedItem.title = titleEntry.Text;
        selectedItem.detail = detailsEditor.Text;

        ResetForm();
    }

    void CancelEdit(object sender, EventArgs e)
    {
        ResetForm();
    }

    void ResetForm()
    {
        titleEntry.Text = "";
        detailsEditor.Text = "";

        addBtn.IsVisible = true;
        editBtn.IsVisible = false;
        cancelBtn.IsVisible = false;

        todoLV.SelectedItem = null;
        selectedItem = null;
    }
}