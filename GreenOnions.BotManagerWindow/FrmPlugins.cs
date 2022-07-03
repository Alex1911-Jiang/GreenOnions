using GreenOnions.BotMain;
using GreenOnions.Interface;
using System.Data;
using System.Windows.Forms;

namespace GreenOnions.BotManagerWindow
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
            for (int i = 0; i < PluginManager.Plugins.Count; i++)
            {
                dtPlugins.Rows.Add(i, PluginManager.Plugins[i].Name, PluginManager.Plugins[i].Description, "设置");
            }
            dgvPlugins.DataSource = dtPlugins;
        }

        private void dgvPlugins_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                if (dgv.CurrentCell.OwningColumn is DataGridViewButtonColumn btnCol)
                {
                    if (btnCol.HeaderText == "设置")
                    {
                        PluginManager.Plugins[e.RowIndex].WindowSetting();
                    }
                }
            }
        }
    }
}
