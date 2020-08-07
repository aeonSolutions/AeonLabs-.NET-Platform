using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System;
using Microsoft.VisualBasic.CompilerServices;

public partial class MessageBoxChild : FormCustomized
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.AlphaGradientPanel1 = new BlueActivity.AlphaGradientPanel();
        this.ColorWithAlpha1 = new BlueActivity.ColorWithAlpha();
        this.cancelBtn = new System.Windows.Forms.Button();
        this.ContinueBtn = new System.Windows.Forms.Button();
        this.iconBox = new System.Windows.Forms.PictureBox();
        this.PanelMessage = new System.Windows.Forms.Panel();
        this.message = new System.Windows.Forms.Label();
        this.title = new System.Windows.Forms.Label();
        this.AlphaGradientPanel1.SuspendLayout();

        this.PanelMessage.SuspendLayout();
        this.SuspendLayout();
        // 
        // AlphaGradientPanel1
        // 
        this.AlphaGradientPanel1.BackColor = System.Drawing.Color.Transparent;
        this.AlphaGradientPanel1.Border = false;
        this.AlphaGradientPanel1.BorderColor = System.Drawing.SystemColors.ActiveBorder;
        this.AlphaGradientPanel1.Colors.Add(this.ColorWithAlpha1);
        this.AlphaGradientPanel1.ContentPadding = new System.Windows.Forms.Padding(0);
        this.AlphaGradientPanel1.Controls.Add(this.cancelBtn);
        this.AlphaGradientPanel1.Controls.Add(this.ContinueBtn);
        this.AlphaGradientPanel1.Controls.Add(this.iconBox);
        this.AlphaGradientPanel1.Controls.Add(this.PanelMessage);
        this.AlphaGradientPanel1.Controls.Add(this.title);
        this.AlphaGradientPanel1.CornerRadius = 20;
        this.AlphaGradientPanel1.Corners = BlueActivity.Corner.None;
        this.AlphaGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.AlphaGradientPanel1.Gradient = false;
        this.AlphaGradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
        this.AlphaGradientPanel1.GradientOffset = 1.0F;
        this.AlphaGradientPanel1.GradientSize = new System.Drawing.Size(0, 0);
        this.AlphaGradientPanel1.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
        this.AlphaGradientPanel1.Grayscale = false;
        this.AlphaGradientPanel1.Image = default;
        this.AlphaGradientPanel1.ImageAlpha = 75;
        this.AlphaGradientPanel1.ImagePadding = new System.Windows.Forms.Padding(5);
        this.AlphaGradientPanel1.ImagePosition = BlueActivity.ImagePosition.BottomRight;
        this.AlphaGradientPanel1.ImageSize = new System.Drawing.Size(48, 48);
        this.AlphaGradientPanel1.Location = new System.Drawing.Point(0, 0);
        this.AlphaGradientPanel1.Margin = new System.Windows.Forms.Padding(2);
        this.AlphaGradientPanel1.Name = "this.AlphaGradientPanel1";
        this.AlphaGradientPanel1.Rounded = true;
        this.AlphaGradientPanel1.Size = new System.Drawing.Size(400, 160);
        this.AlphaGradientPanel1.TabIndex = 351;
        // 
        // ColorWithAlpha1
        // 
        this.ColorWithAlpha1.Alpha = 0;
        this.ColorWithAlpha1.Color = System.Drawing.Color.YellowGreen;
        // 
        // cancelBtn
        // 
        this.ColorWithAlpha1.Parent = this.AlphaGradientPanel1;

        //cancelBtn
        this.cancelBtn.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
        this.cancelBtn.Cursor = Cursors.Hand;
        this.cancelBtn.FlatAppearance.BorderSize = 0;
        this.cancelBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        this.cancelBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.cancelBtn.Font = new System.Drawing.Font("Trajan Pro", 9, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.cancelBtn.ForeColor = System.Drawing.Color.White;
        this.cancelBtn.Location = new System.Drawing.Point(271, 127);
        this.cancelBtn.Margin = new System.Windows.Forms.Padding(2);
        this.cancelBtn.Name = "this.cancelBtn";
        this.cancelBtn.Size = new System.Drawing.Size(105, 25);
        this.cancelBtn.TabIndex = 354;
        this.cancelBtn.Text = "Cancelar";
        // 
        // ContinueBtn
        // 
        this.cancelBtn.UseVisualStyleBackColor = true;

                
       //ContinueBtn
       this.ContinueBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        this.ContinueBtn.Cursor = System.Windows.Forms.Cursors.Hand;
        this.ContinueBtn.FlatAppearance.BorderSize = 0;
        this.ContinueBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.ContinueBtn.Font = new System.Drawing.Font("Trajan Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.ContinueBtn.ForeColor = System.Drawing.Color.White;
        this.ContinueBtn.Location = new System.Drawing.Point(15, 127);
        this.ContinueBtn.Margin = new System.Windows.Forms.Padding(2);
        this.ContinueBtn.Name = "this.ContinueBtn";
        this.ContinueBtn.Size = new System.Drawing.Size(105, 25);
        this.ContinueBtn.TabIndex = 353;
        this.ContinueBtn.Text = "Continuar";
        this.ContinueBtn.UseVisualStyleBackColor = true;
        // 
        // iconBox
        // 
        this.iconBox.BackColor = System.Drawing.Color.Transparent;
        this.iconBox.Location = new System.Drawing.Point(23, 54);
        this.iconBox.Name = "this.iconBox";
        this.iconBox.Size = new System.Drawing.Size(53, 53);
        this.iconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.iconBox.TabIndex = 0;
        this.iconBox.TabStop = false;
        // 
        // PanelMessage
        // 
        this.PanelMessage.AutoScroll = true;
        this.PanelMessage.Controls.Add(this.message);
        this.PanelMessage.Location = new System.Drawing.Point(103, 41);
        this.PanelMessage.Margin = new System.Windows.Forms.Padding(2);
        this.PanelMessage.Name = "this.PanelMessage";
        this.PanelMessage.Size = new System.Drawing.Size(293, 77);
        // 
        // message
        // 
        this.PanelMessage.TabIndex = 350;

                
                //message
                
        this.message.Anchor =(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
        this.message.BackColor = System.Drawing.Color.Transparent;
        this.message.Font = new System.Drawing.Font("Bookman Old Style", 11.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.message.ForeColor = System.Drawing.Color.White;
        this.message.Location = new System.Drawing.Point(2, 1);
        this.message.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        this.message.Name = "this.message";
        this.message.Size = new System.Drawing.Size(254, 77);
        this.message.TabIndex = 0;
        // 
        // title
        // 
        this.message.Text = "message";


        //title         
        this.title.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right;
        this.title.AutoSize = true;
        this.title.BackColor = System.Drawing.Color.Transparent;

        this.title.Font = new System.Drawing.Font("Trajan Pro", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);

        this.title.ForeColor = System.Drawing.Color.White;
        this.title.Location = new System.Drawing.Point(178, 11);
        this.title.Name = "this.title";
        this.title.Size = new System.Drawing.Size(55, 20);
        this.title.TabIndex = 1;
        this.title.Text = "Title";
        this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // MessageBoxChild
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(96.0F, 96.0F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.BackColor = System.Drawing.Color.Gainsboro;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.ClientSize = new System.Drawing.Size(400, 160);
        this.ControlBox = false;
        this.Controls.Add(this.AlphaGradientPanel1);
        this.DoubleBuffered = true;

        this.Font = new System.Drawing.Font("Trajan Pro", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Margin = new System.Windows.Forms.Padding(2);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "MessageBoxChild";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Form1";
        this.TransparencyKey = System.Drawing.Color.Gainsboro;
        this.AlphaGradientPanel1.ResumeLayout(false);
        this.AlphaGradientPanel1.PerformLayout();

        this.PanelMessage.ResumeLayout(false);
        this.ResumeLayout(false);
    }


    private System.Windows.Forms.Panel PanelMessage;
    private Label message;
    private System.Windows.Forms.PictureBox iconBox;
    private Label title;
    private BlueActivity.AlphaGradientPanel AlphaGradientPanel1;
    private BlueActivity.ColorWithAlpha ColorWithAlpha1;
    private System.Windows.Forms.Button ContinueBtn;
    private System.Windows.Forms.Button cancelBtn;

    #endregion 
}