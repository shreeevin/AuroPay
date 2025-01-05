using AuroPay.Helpers;
using AuroPay.Components;

namespace AuroPay.Views.Onboard
{
    partial class OnboardScreen
    {
        private Panel registerPanel;
        private Panel bannerPanel;
        private PictureBox logoPictureBox;
        private Label descriptionLabel;        
        private Label signUpTextLabel;
        private Label signUpLinkLabel;
        private RoundedTextBox fullnameTextBox;  
        private RoundedTextBox emailTextBox;  
        private RoundedTextBox phoneTextBox; 
        private Button saveButton;
        private Label fullnameLabel;
        private Label emailLabel;
        private Label phoneLabel;
        private void InitializeComponent()
        {
            registerPanel = new Panel();
            bannerPanel = new Panel();
            
            logoPictureBox = new PictureBox();
            descriptionLabel = new Label();
            
            fullnameTextBox = new RoundedTextBox(); 
            emailTextBox = new RoundedTextBox(); 
            phoneTextBox = new RoundedTextBox(); 

            saveButton = new Button();
            
            fullnameLabel = new Label();
            emailLabel = new Label();
            phoneLabel = new Label();


            signUpTextLabel = new Label();
            signUpLinkLabel = new LinkLabel();

            this.SuspendLayout();
            registerPanel.SuspendLayout();

            this.MinimumSize = new Size(800, 450);
            this.ClientSize = new Size(800, 450);
            this.WindowState = FormWindowState.Maximized;
            this.Name = "AuroPay - Onboard";
            this.Text = "AuroPay - Onboard";
            this.BackColor = Color.White;
            this.Icon = new Icon("Resources/AppIcon/icon.ico");

            registerPanel.Dock = DockStyle.Right;
            registerPanel.Width = (int)(this.ClientSize.Width * 0.4);
            registerPanel.BackColor = Color.White;
            registerPanel.Padding = new Padding(40);

            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.Size = new Size(150, 75);
            logoPictureBox.Image = Image.FromFile("Resources/Images/logo.color.png");
            logoPictureBox.Location = new Point(
                (registerPanel.Width - logoPictureBox.Width) / 2,
                60
            );

            descriptionLabel.AutoSize = true;
            descriptionLabel.Text = "Setup your AuroPay account";
            descriptionLabel.Font = new Font("Inter", 12F);
            descriptionLabel.Location = new Point(
                (registerPanel.Width - descriptionLabel.Width) / 2,
                180
            );            

            fullnameLabel.AutoSize = true;
            fullnameLabel.Text = "Name";
            fullnameLabel.Font = new Font("Inter", 10F);
            fullnameLabel.Location = new Point(40, 240);

            fullnameTextBox.Size = new Size(registerPanel.Width - 80, 55);
            fullnameTextBox.Location = new Point(40, 270);
            fullnameTextBox.Font = new Font("Inter", 12F);
            fullnameTextBox.BackColor = Color.White;
            fullnameTextBox.Height = 55;
            fullnameTextBox.Padding = new Padding(10, 15, 10, 15);

            emailLabel.AutoSize = true;
            emailLabel.Text = "Email";
            emailLabel.Font = new Font("Inter", 10F);
            emailLabel.Location = new Point(40, 330);

            emailTextBox.Size = new Size(registerPanel.Width - 80, 55);
            emailTextBox.Location = new Point(40, 360);
            emailTextBox.Font = new Font("Inter", 12F);
            emailTextBox.BackColor = Color.White;
            emailTextBox.Height = 55;
            emailTextBox.Padding = new Padding(10, 15, 10, 15);

            phoneLabel.AutoSize = true;
            phoneLabel.Text = "Phone";
            phoneLabel.Font = new Font("Inter", 10F);
            phoneLabel.Location = new Point(40, 420);

            phoneTextBox.Size = new Size(registerPanel.Width - 80, 55);
            phoneTextBox.Location = new Point(40, 450);
            phoneTextBox.Font = new Font("Inter", 12F);
            phoneTextBox.BackColor = Color.White;
            phoneTextBox.Height = 55;
            phoneTextBox.MaxLength = 10;
            phoneTextBox.Padding = new Padding(10, 15, 10, 15);
            phoneTextBox.KeyPress += ValidatePhoneNumber;

            saveButton.Size = new Size(registerPanel.Width - 80, 55);
            saveButton.Location = new Point(40, phoneTextBox.Bottom + 30);
            saveButton.Text = "Save";
            saveButton.Font = new Font("Inter", 12F, FontStyle.Regular);
            saveButton.BackColor = Color.Black;
            saveButton.ForeColor = Color.White;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.Cursor = Cursors.Hand;
            saveButton.Region = System.Drawing.Region.FromHrgn(LayoutHelper.CreateRoundRectRgn(0, 0, saveButton.Width, saveButton.Height, 12, 12));  
            saveButton.Click += new EventHandler(saveButtonClick);

            bannerPanel.Dock = DockStyle.Fill;
            bannerPanel.BackgroundImage = Image.FromFile("Resources/Images/onboard.banner.png");
            bannerPanel.BackgroundImageLayout = ImageLayout.Stretch;

            registerPanel.Controls.Add(logoPictureBox);
            registerPanel.Controls.Add(descriptionLabel);
            registerPanel.Controls.Add(fullnameLabel);
            registerPanel.Controls.Add(fullnameTextBox);
            registerPanel.Controls.Add(emailLabel);
            registerPanel.Controls.Add(emailTextBox);
            
            registerPanel.Controls.Add(phoneLabel);
            registerPanel.Controls.Add(phoneTextBox);

            registerPanel.Controls.Add(saveButton);

            registerPanel.Controls.Add(signUpTextLabel);

            this.Controls.Add(registerPanel);
            this.Controls.Add(bannerPanel);

            this.Resize += new EventHandler(AdjustLayout);

            registerPanel.ResumeLayout();
            this.ResumeLayout();
        }
    }
}