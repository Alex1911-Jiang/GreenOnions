namespace GreenOnions.BotManagerWindows.Controls
{
    public interface IConfigSetting
    {
        void LoadConfig();
        void SaveConfig();
        void UpdateCache();

        internal void AddItemToListView(ListView listView, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                foreach (ListViewItem item in listView.Items)
                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                        if (subItem.Text == value)
                            return;
                listView.Items.Add(value);
            }
        }

        internal void RemoveItemFromListView(ListView listView)
        {
            if (listView.SelectedItems.Count > 0)
            {
                listView.Items.Remove(listView.SelectedItems[0]);
            }
        }
    }
}
