using AuroPay.Helpers;
using AuroPay.Components;
using AuroPay.Controllers;
using AuroPay.Components.Assistants;

namespace AuroPay.Views.Setting
{
    partial class SettingScreen
    {
        private Panel settingPanel;
        private Panel bannerPanel;
        private PictureBox logoPictureBox;
        private Label descriptionLabel;        
        private Label goBackTextLabel;
        private RoundedTextBox oldPasswordTextBox;         
        private RoundedTextBox newPasswordTextBox; 
        private Button saveButton;
        private Label oldPasswordLabel;
        private Label newPasswordLabel;

        private void InitializeComponent()
        {
            settingPanel = new Panel();
            bannerPanel = new Panel();
            
            logoPictureBox = new PictureBox();
            descriptionLabel = new Label();
            
            oldPasswordTextBox = new RoundedTextBox(); 
            newPasswordTextBox = new RoundedTextBox(); 

            saveButton = new Button();
            
            oldPasswordLabel = new Label();
            newPasswordLabel = new Label();

            goBackTextLabel = new Label();

            this.SuspendLayout();
            ScreenHelper.SetupScreen(this, "AuroPay - Setting");

            settingPanel.SuspendLayout();

            settingPanel.Dock = DockStyle.Right;
            settingPanel.Width = (int)(this.ClientSize.Width * 0.4);
            settingPanel.BackColor = Color.White;
            settingPanel.Padding = new Padding(40);

            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.Size = new Size(150, 75);
            logoPictureBox.Image = Image.FromFile("Resources/Images/logo.color.png");
            logoPictureBox.Location = new Point(
                (settingPanel.Width - logoPictureBox.Width) / 2,
                60
            );

            descriptionLabel.AutoSize = true;
            descriptionLabel.Text = "Update your account credentials";
            descriptionLabel.Font = new Font("Inter", 12F);
            descriptionLabel.Location = new Point(
                (settingPanel.Width - descriptionLabel.Width) / 2,
                180
            );            

            oldPasswordLabel.AutoSize = true;
            oldPasswordLabel.Text = "Old Password";
            oldPasswordLabel.Font = new Font("Inter", 10F);
            oldPasswordLabel.Location = new Point(40, 240);

            oldPasswordTextBox.Size = new Size(settingPanel.Width - 80, 55);
            oldPasswordTextBox.Location = new Point(40, 270);
            oldPasswordTextBox.Font = new Font("Inter", 12F);
            oldPasswordTextBox.UseSystemPasswordChar = true; 
            oldPasswordTextBox.BackColor = Color.White;
            oldPasswordTextBox.Height = 55;
            oldPasswordTextBox.CornerRadius = 15;
            oldPasswordTextBox.Padding = new Padding(10, 15, 10, 15);

            newPasswordLabel.AutoSize = true;
            newPasswordLabel.Text = "New Password";
            newPasswordLabel.Font = new Font("Inter", 10F);
            newPasswordLabel.Location = new Point(40, 330);

            newPasswordTextBox.Size = new Size(settingPanel.Width - 80, 55);
            newPasswordTextBox.Location = new Point(40, 360);
            newPasswordTextBox.Font = new Font("Inter", 12F);
            newPasswordTextBox.UseSystemPasswordChar = true; 
            newPasswordTextBox.BackColor = Color.White;
            newPasswordTextBox.Height = 55;
            newPasswordTextBox.Padding = new Padding(10, 15, 10, 15);

            saveButton.Size = new Size(settingPanel.Width - 80, 55);
            saveButton.Location = new Point(40, 430);
            saveButton.Text = "Save";
            saveButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            saveButton.BackColor = Color.Black;
            saveButton.ForeColor = Color.White;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.Cursor = Cursors.Hand;
            saveButton.Region = System.Drawing.Region.FromHrgn(LayoutHelper.CreateRoundRectRgn(0, 0, saveButton.Width, saveButton.Height, 12, 12));  
            saveButton.Click += new EventHandler(SaveButtonClick);

            goBackTextLabel.AutoSize = true;
            goBackTextLabel.Text = "Have a change of mind? Go back";
            goBackTextLabel.Font = new Font("Inter", 12F);
            goBackTextLabel.ForeColor = Color.Gray;
            goBackTextLabel.Cursor = Cursors.Hand;
            goBackTextLabel.Location = new Point(
                (settingPanel.Width - goBackTextLabel.Width) / 2, 
                saveButton.Bottom + 30 
            );
            goBackTextLabel.Click += (sender, e) => HomeController.NavigateToHome(this);

            bannerPanel.Dock = DockStyle.Fill;
            bannerPanel.BackgroundImage = Image.FromFile("Resources/Images/setting.banner.png");
            bannerPanel.BackgroundImageLayout = ImageLayout.Stretch;

            settingPanel.Controls.Add(logoPictureBox);
            settingPanel.Controls.Add(descriptionLabel);
            settingPanel.Controls.Add(oldPasswordLabel);
            settingPanel.Controls.Add(oldPasswordTextBox);
            settingPanel.Controls.Add(newPasswordLabel);
            settingPanel.Controls.Add(newPasswordTextBox);
            settingPanel.Controls.Add(saveButton);

            settingPanel.Controls.Add(goBackTextLabel);

            this.Controls.Add(settingPanel);
            this.Controls.Add(bannerPanel);

            this.Resize += new EventHandler(AdjustLayout);

            settingPanel.ResumeLayout();
            this.ResumeLayout();
        }
    }
}