using System.Data;
using GreenOnions.BotMain;
using GreenOnions.Utility;
using GreenOnions.Utility.Helper;

namespace GreenOnions.BotManagerWindows
{
    public partial class FrmPlugins : Form
    {
        public FrmPlugins()
        {
            InitializeComponent();

            DataTable dtPlugins = new DataTable();
            dtPlugins.Columns.Add("Index");
            dtPlugins.Columns.Add("Name");
            dtPlugins.Columns.Add("Description");
            dtPlugins.Columns.Add("Setting");
            dtPlugins.Columns.Add("Enabled");

            for (int i = 0; i < PluginManager.Plugins.Count; i++)
                dtPlugins.Rows.Add(i + 1, PluginManager.Plugins[i].Name, PluginManager.Plugins[i].Description, "设置", BotInfo.PluginStatus[PluginManager.Plugins[i].Name]);
            dgvPlugins.DataSource = dtPlugins;
        }

        private void dgvPlugins_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (dgv.CurrentCell.OwningColumn is DataGridViewButtonColumn btnCol)
                {
                    if (btnCol.Name == "colSetting")
                        if (!PluginManager.Plugins[e.RowIndex].WindowSetting())
                            PluginManager.Plugins[e.RowIndex].ConsoleSetting();
                }
                else if (dgv.CurrentCell.OwningColumn is DataGridViewCheckBoxColumn chkCol)
                {
                    if (chkCol.Name == "colEnabled" && dgv.CurrentCell is DataGridViewCheckBoxCell chkCell)
                    {
                        Dictionary<string, bool> dicPluginStatus = BotInfo.PluginStatus;
                        dicPluginStatus[PluginManager.Plugins[e.RowIndex].Name] = Convert.ToBoolean(chkCell.EditingCellFormattedValue);
                        BotInfo.PluginStatus = dicPluginStatus;
                        ConfigHelper.SaveConfigFile();
                    }
                }
            }
        }
    }
}
