using System.Data;
using System.Diagnostics;
using GreenOnions.BotMain;
using GreenOnions.Interface;
using GreenOnions.Utility;

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
                    if (btnCol.Name == "colSetting" && PluginManager.Plugins[e.RowIndex] is IPluginSetting plugin)
                        plugin.Setting();
                }
                else if (dgv.CurrentCell.OwningColumn is DataGridViewCheckBoxColumn chkCol)
                {
                    if (chkCol.Name == "colEnabled" && dgv.CurrentCell is DataGridViewCheckBoxCell chkCell)
                    {
                        Dictionary<string, bool> dicPluginStatus = BotInfo.PluginStatus;
                        dicPluginStatus[PluginManager.Plugins[e.RowIndex].Name] = Convert.ToBoolean(chkCell.EditingCellFormattedValue);
                        BotInfo.PluginStatus = dicPluginStatus;
                        BotInfo.SavePluginsStatus();
                    }
                }
            }
        }

        private void PluginsRepo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("explorer.exe", "https://github.com/Alex1911-Jiang/GreenOnions.Plugins");
    }
}
