using GreenOnions.BotMain;
using System.Windows.Forms;

namespace GreenOnions.BotManagerWindow
{
    public partial class FrmPlugins : Form
    {
        public FrmPlugins()
        {
            InitializeComponent();

            foreach (string pluginName in PluginManager.Plugins.Keys)
            {
                lstPlugins.Items.Add(pluginName);
            }
        }
    }
}
