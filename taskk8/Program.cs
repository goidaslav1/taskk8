using System;
using System.Drawing;
using System.Windows.Forms; 


namespace taskk8

{

    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Form form = new InteractiveForm("Приложение");
            Application.Run(form);
        }
    }

    public class InteractiveForm : Form
    {
        private bool _mouseonForm = false;
        public InteractiveForm(string title)
        {
            Text = title;
            Height = 600;
            Width = 800;
            StartPosition = FormStartPosition.CenterScreen;

            Button exitButton = CreateButton(new Size(60, 30), new Point(700, 500), "Exit");
            exitButton.Click += (sender, e) => Application.Exit();
            Label label = CreateLabel(new Size(200, 30), new Point(300, 200), "Кликни 2 раза чтоб убрать это соообщение");
            label.Visible = true;
            DoubleClick += (sender, e) => HideLabel(label);
            MouseEnter += (sender, e) => _mouseonForm = true;
            MouseLeave += (sender, e) => _mouseonForm = false;
        }

        private void HideLabel(Label label)
        {
            if (_mouseonForm) label.Visible = false;
        }
        private void SetCommonParameters(Control element, Size size, Point position, string title)
        {
            element.Size = size;
            element.Location = position;
            element.Text = title;
            Controls.Add(element);
        }
        private Button CreateButton(Size size, Point position, string title)
        {
            Button button = new Button();
            SetCommonParameters(button, size, position, title);
            return button;
        }

        private Label CreateLabel(Size size, Point position, string title)
        {
            Label label = new Label();
            SetCommonParameters(label, size, position, title);
            return label;
        }
    }
}