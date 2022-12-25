namespace GreenOnions.BotManagerWindows.ItemFroms
{
    public partial class InputBox : Form
    {
        private InputBox()
        {
            InitializeComponent();
        }

        public string Message { get => lblMessage.Text; set => lblMessage.Text = value; }

        public string InputText { get => txbInput.Text; set => txbInput.Text = value; }

        public static string Show(string message, string titile = "")
        {
            InputBox inputBox = new InputBox();
            inputBox.Message = message;
            inputBox.Text = titile;
            inputBox.ShowDialog();
            return inputBox.InputText;
        }
    }
}
