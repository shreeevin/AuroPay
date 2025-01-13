using AuroPay.Models;
using AuroPay.Helpers;
using AuroPay.Components;
using AuroPay.Controllers;
using AuroPay.Components.Assistants;

namespace AuroPay.Views.Profile
{
    partial class ProfileScreen
    {
        private Panel profilePanel;
        private Panel bannerPanel;
        private PictureBox logoPictureBox;
        private Label descriptionLabel;        
        private Label goBackTextLabel;
        private RoundedTextBox fullnameTextBox;  
        private RoundedTextBox emailTextBox;  
        private RoundedTextBox phoneTextBox; 
        private Button saveButton;
        private Label fullnameLabel;
        private Label emailLabel;
        private Label phoneLabel;
        private User currentUser;
        private void InitializeComponent()
        {
            profilePanel = new Panel();
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


            goBackTextLabel = new Label();

            this.SuspendLayout();
            ScreenHelper.SetupScreen(this, "AuroPay - Profile");

            profilePanel.SuspendLayout();

            profilePanel.Dock = DockStyle.Right;
            profilePanel.Width = (int)(this.ClientSize.Width * 0.4);
            profilePanel.BackColor = Color.White;
            profilePanel.Padding = new Padding(40);

            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.Size = new Size(150, 75);
            logoPictureBox.Image = Image.FromFile("Resources/Images/logo.color.png");
            logoPictureBox.Location = new Point(
                (profilePanel.Width - logoPictureBox.Width) / 2,
                60
            );

            descriptionLabel.AutoSize = true;
            descriptionLabel.Text = "Update your AuroPay account details";
            descriptionLabel.Font = new Font("Inter", 12F);
            descriptionLabel.Location = new Point(
                (profilePanel.Width - descriptionLabel.Width) / 2,
                180
            );            

            fullnameLabel.AutoSize = true;
            fullnameLabel.Text = "Name";
            fullnameLabel.Font = new Font("Inter", 10F);
            fullnameLabel.Location = new Point(40, 240);

            fullnameTextBox.Size = new Size(profilePanel.Width - 80, 55);
            fullnameTextBox.Location = new Point(40, 270);
            fullnameTextBox.Font = new Font("Inter", 12F);
            fullnameTextBox.BackColor = Color.White;
            fullnameTextBox.Height = 55;
            fullnameTextBox.Padding = new Padding(10, 15, 10, 15);

            emailLabel.AutoSize = true;
            emailLabel.Text = "Email";
            emailLabel.Font = new Font("Inter", 10F);
            emailLabel.Location = new Point(40, 330);

            emailTextBox.Size = new Size(profilePanel.Width - 80, 55);
            emailTextBox.Location = new Point(40, 360);
            emailTextBox.Font = new Font("Inter", 12F);
            emailTextBox.BackColor = Color.White;
            emailTextBox.Height = 55;
            emailTextBox.Padding = new Padding(10, 15, 10, 15);

            phoneLabel.AutoSize = true;
            phoneLabel.Text = "Phone";
            phoneLabel.Font = new Font("Inter", 10F);
            phoneLabel.Location = new Point(40, 420);

            phoneTextBox.Size = new Size(profilePanel.Width - 80, 55);
            phoneTextBox.Location = new Point(40, 450);
            phoneTextBox.Font = new Font("Inter", 12F);
            phoneTextBox.BackColor = Color.White;
            phoneTextBox.Height = 55;
            phoneTextBox.MaxLength = 10;
            phoneTextBox.Padding = new Padding(10, 15, 10, 15);
            phoneTextBox.KeyPress += ValidatePhoneNumber;

            saveButton.Size = new Size(profilePanel.Width - 80, 55);
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

            goBackTextLabel.AutoSize = true;
            goBackTextLabel.Text = "Have a change of mind? Go back";
            goBackTextLabel.Font = new Font("Inter", 12F);
            goBackTextLabel.ForeColor = Color.Gray;
            goBackTextLabel.Cursor = Cursors.Hand;
            goBackTextLabel.Location = new Point(
                (profilePanel.Width - goBackTextLabel.Width) / 2, 
                saveButton.Bottom + 30 
            );
            goBackTextLabel.Click += (sender, e) => HomeController.NavigateToHome(this);

            bannerPanel.Dock = DockStyle.Fill;
            bannerPanel.BackgroundImage = Image.FromFile("Resources/Images/profile.banner.png");
            bannerPanel.BackgroundImageLayout = ImageLayout.Stretch;

            profilePanel.Controls.Add(logoPictureBox);
            profilePanel.Controls.Add(descriptionLabel);
            profilePanel.Controls.Add(fullnameLabel);
            profilePanel.Controls.Add(fullnameTextBox);
            profilePanel.Controls.Add(emailLabel);
            profilePanel.Controls.Add(emailTextBox);
            
            profilePanel.Controls.Add(phoneLabel);
            profilePanel.Controls.Add(phoneTextBox);

            profilePanel.Controls.Add(saveButton);

            profilePanel.Controls.Add(goBackTextLabel);

            this.Controls.Add(profilePanel);
            this.Controls.Add(bannerPanel);

            this.Resize += new EventHandler(AdjustLayout);

            profilePanel.ResumeLayout();
            this.ResumeLayout();
        }
    }
}