using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;
using AeonLabs.Environment;
using Microsoft.VisualBasic;
using AeonLabs.BasicLibraries;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace AeonLabs.Layouts.Main
{

    public partial class mainAppLayoutForm : FormCustomized
    {

        #region Register Configurable Layout Controls

        private void registerConfigurableLayoutControls()
        {
            // REGISTER CONFIGURABLE LAYOUT PANELS 
            registeredPanels.Add(panelLeftSide.Name);
            registeredPanels.Add(panelBottom.Name);
            registeredPanels.Add(panelTop.Name);
        }
        #endregion

        #region Assign Controls to Assembly
        private void assignControlToAssembly()
        {

            if (ENABLE_TESTING_ENVIRONMENT.Equals(true))
            {
                return;
            }
            bool error = false;
            error = !AssembliesManager.assignControlAssembly("sideBarSettings", panelMenuOptionsContainer);

            if (error)
            {
                Interaction.MsgBox("Error: assembly cound not be assigned a panel, " + AssembliesManager.errorMessage);
                this.Close();
                return;
            }
        }
        #endregion

        #region Constants, Variables and Fields

        #region Layout Settings
        private const int LATERAL_MENU_OPEN_WIDTH = 400;
        #endregion

        // AssembliesToLoadAtStart = {({"Filename.Dll", "FormName", "NameSpace","UUID"}), ({"Filename.Dll", "FormName", "NameSpace","UUID"}), ({"Filename.Dll", "FormName", "NameSpace","UUID"}), ({"Filename.Dll", "FormName", "NameSpace","UUID"})}
        public readonly object AssembliesToLoadAtStartOLD = new[] { new[] { "", "", "", "" }, new[] { "", "", "", "" }, new[] { "", "", "", "" }, new[] { "", "", "", "" } };

        #region Constants
        private const bool ENABLE_TESTING_ENVIRONMENT = true;
        #endregion

        #region Public Fields
        public environmentVarsCore.updateMainLayoutDelegate updateMainApp;
        public environmentVarsCore enVars { get; set; } = new environmentVarsCore();
        public string statusMessage { get; set; } = "";
        #endregion

        #region Private fields
        private ResourceManager resources;
        private EnvironmentAssembliesLoadClass AssembliesManager;

        // Flag to check if there are loading errors 
        private bool ErrorLoading = false;
        // panel registered for layout color and background changes
        private List<string> registeredPanels = new List<string>();
        private messageBoxForm msgbox;
        // menu builder
        private MenuBuilderClass _menuBuilder;
        private MenuBuilderClass menuBuilder
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _menuBuilder;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_menuBuilder != null)
                {
                    _menuBuilder.menuPanelClick -= menuPanel_Click;
                    _menuBuilder.menuNotificationClick -= menuPanelNotifications_click;
                    _menuBuilder.menuStateUpdateLayout -= menuStateUpdateLayout;
                }

                _menuBuilder = value;
                if (_menuBuilder != null)
                {
                    _menuBuilder.menuPanelClick += menuPanel_Click;
                    _menuBuilder.menuNotificationClick += menuPanelNotifications_click;
                    _menuBuilder.menuStateUpdateLayout += menuStateUpdateLayout;
                }
            }
        }

        // STATUS MESSAGE 
        private string statusMessageLast = "";
        private int statusMessageTimeout = 10;
        private List<string> statusMessagePile = new List<string>();
        private Timer _StatusMessagesDisplayTime;

        private Timer StatusMessagesDisplayTime
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _StatusMessagesDisplayTime;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_StatusMessagesDisplayTime != null)
                {
                    _StatusMessagesDisplayTime.Tick -= StatusMessagesDisplayTime_Tick;
                }

                _StatusMessagesDisplayTime = value;
                if (_StatusMessagesDisplayTime != null)
                {
                    _StatusMessagesDisplayTime.Tick += StatusMessagesDisplayTime_Tick;
                }
            }
        }

        private Timer _UpdateStatusMessageTimer;

        private Timer UpdateStatusMessageTimer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _UpdateStatusMessageTimer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_UpdateStatusMessageTimer != null)
                {
                    _UpdateStatusMessageTimer.Tick -= UpdateStatusMessageTimer_Tick;
                }

                _UpdateStatusMessageTimer = value;
                if (_UpdateStatusMessageTimer != null)
                {
                    _UpdateStatusMessageTimer.Tick += UpdateStatusMessageTimer_Tick;
                }
            }
        }

        // TOOLTIPS
        private ToolTip settingsToolTip = new ToolTip();
        private ToolTip menuToggleToolTip = new ToolTip();

        // CHANGE BACKGROUND IMAGE
        private Timer _ChangeBackgroundTimer;
        private Timer ChangeBackgroundTimer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ChangeBackgroundTimer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ChangeBackgroundTimer != null)
                {
                    _ChangeBackgroundTimer.Tick -= ChangeBackgroundTimer_Tick;
                }

                _ChangeBackgroundTimer = value;
                if (_ChangeBackgroundTimer != null)
                {
                    _ChangeBackgroundTimer.Tick += ChangeBackgroundTimer_Tick;
                }
            }
        }

        private BackgroundWorker _bwChangeBackground;

        private BackgroundWorker bwChangeBackground
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _bwChangeBackground;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_bwChangeBackground != null)
                {
                    _bwChangeBackground.DoWork -= BackgroundWorker1_DoWork;
                    _bwChangeBackground.RunWorkerCompleted -= BackgroundWorker1_RunWorkerCompleted;
                }

                _bwChangeBackground = value;
                if (_bwChangeBackground != null)
                {
                    _bwChangeBackground.DoWork += BackgroundWorker1_DoWork;
                    _bwChangeBackground.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;
                }
            }
        }

        #endregion

        public Form CurrentWrapperForm;
        public Form LoadedFrm;
        public bool loaded = false;
        private bool BusyMenuOption = false;

        public PictureBox usernamePhoto { get; set; } = null;

        private int eDelta;
        private int Sensitivity = 20;

        #region ToolTips

        private void addToolTips()
        {
            // ADD TOOLTIPS 
            var menuToggleToolTip = new ToolTip();
            menuToggleToolTip.SetToolTip(menuToggleIcon, resources.GetString("MenuToggle"));
            var settingsToolTip = new ToolTip();
            settingsToolTip.SetToolTip(iconMenuSettings, resources.GetString("settingsToggle"));
        }
        #endregion

        #endregion

        #region Constructor
        public mainAppLayoutForm(environmentVarsCore _envars = default)
        {
            bwChangeBackground = new BackgroundWorker();
            Application.AddMessageFilter((IMessageFilter)this);
            ErrorLoading = false;

            // This call is required by the designer.
            this.SuspendLayout();
            InitializeComponent();
            if (_envars is object)
            {
                enVars = _envars;
            }

            enVars.layoutDesign.menu.properties.ClosedStateSize = LATERAL_MENU_OPEN_WIDTH;

            string resxFile = @".\config\strings.resx";
            ResXResourceSet resources = new ResXResourceSet(resxFile);

            // ASSIGN ASSEMBLIES TO PANELS
            assignControlToAssembly();

            // çheck if external files exist
            enVars = LayoutSettings.loadExternalFilesInUse(enVars);
            if (enVars is null)
            {
                ErrorLoading = true;
                Application.Exit();
                return;
            }
            // Instantiating the delegate for update data from child forms
            updateMainApp = updateMainAppLayout;

            // Me.InactivityTimeOut = enVars.AutomaticLogoutTime

            this.Visible = false;
            this.Opacity = 0;
            this.Refresh();
            registerConfigurableLayoutControls();
            addToolTips();
            if (ENABLE_TESTING_ENVIRONMENT)
            {
                enVars = TestingVars.loadTestingEnvironmentVars(enVars);
            }

            this.ResumeLayout();

            // ' needs to be the last 
            if (!this.IsDisposed & !ErrorLoading)
            {
                this.Show();
            }

        }

        #endregion

        #region Update Envirnment and Layout
        public void updateMainAppLayout(object sender, ref updateMainAppClass updateContents)
        {
            enVars = updateContents.envars;
            if (updateContents.updateTask.Equals(updateMainAppClass.UPDATE_LAYOUT))
            {
                SuspendLayout();
                updateBkColorAndTransparency(this, false, false);
                ResumeLayout();
                Refresh();
            }
            else if (updateContents.updateTask.Equals(updateMainAppClass.UPDATE_LAYOUT_BACKGROUND))
            {
                SuspendLayout();
                this.BackgroundImage = Image.FromFile(updateContents.backGroundFileName);
                this.BackgroundImageLayout = ImageLayout.Stretch;
                updateBkImageOnChildForms(this, false, default);
                ResumeLayout();
                Refresh();
            }
            else if (updateContents.updateTask.Equals(updateMainAppClass.UPDATE_ENVIRONMENT_VARS))
            {
                // REDUNDANT ...
            }
        }

        private void updateBkColorAndTransparency(Control ctrlContainer, bool isOnChildren, bool isOnForm)
        {
            foreach (Control ctrl in ctrlContainer.Controls)
            {
                string t = ctrl.Name;
                var typ = ctrl.GetType();
                if (ctrl is PanelDoubleBuffer & !isOnChildren)
                {
                    if (registeredPanels.Contains(ctrl.Name.ToString()))
                    {
                        ctrl.BackColor = Color.FromArgb(Convert.ToInt32(enVars.layoutDesign.PanelTransparencyIndex), enVars.layoutDesign.PanelBackColor);
                        if (ctrl.HasChildren)
                        {
                            updateBkColorAndTransparency(ctrl, true, false);
                        }
                    }
                }
                else if ((ctrl is FormCustomized | ctrl is Form) & isOnChildren)
                {
                    updateBkColorAndTransparency(ctrl, true, true);
                }
                else if (ctrl is PanelDoubleBuffer & isOnChildren & isOnForm)
                {
                    ctrl.BackColor = Color.FromArgb(Convert.ToInt32(enVars.layoutDesign.PanelTransparencyIndex), enVars.layoutDesign.PanelBackColor);
                }
                else if (ctrl is PanelDoubleBuffer & isOnChildren & ctrl.HasChildren)
                {
                    updateBkColorAndTransparency(ctrl, true, false);
                }
            }
        }

        private void updateBkImageOnChildForms(Control ctrlContainer, bool isOnChildren, PanelDoubleBuffer panelHost)
        {
            foreach (Control ctrl in ctrlContainer.Controls)
            {
                string t = ctrl.Name;
                var typ = ctrl.GetType();
                if (ctrl is PanelDoubleBuffer)
                {
                    if (ctrl.HasChildren)
                    {
                        updateBkImageOnChildForms(ctrl, true, (PanelDoubleBuffer)ctrl);
                    }
                }
                else if ((ctrl is FormCustomized | ctrl is Form) & isOnChildren)
                {
                    ctrl.BackgroundImage = imageManipulationLib.cropImage(this.BackgroundImage, panelHost.Location, panelHost.Size, this.Size);
                    ctrl.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }
        #endregion

        #region Form events
        private void mainAppLayoutForm_Load(object sender, EventArgs e)
        {


    }

    private void mainAppLayoutForm_shown(object sender, EventArgs e)
        {
            if (ErrorLoading)
            {
                Application.Exit();
                return;
            }

            SuspendLayout();
            loaded = false;
            {
                var withBlock = panelLeftSide;
                withBlock.Parent = this;
                withBlock.Width = enVars.layoutDesign.menu.properties.ClosedStateSize;
                withBlock.BackColor = Color.Transparent;
                withBlock.AutoScroll = true;
            }

            // TOP OPTIONS ON SIDE PANEL
            {
                var withBlock1 = panelMenuOptions;
                withBlock1.Parent = panelLeftSide;
                withBlock1.Dock = DockStyle.Top;
                withBlock1.BringToFront();
            }

            // lateralPanelMenuOptions.BackColor = Color.FromArgb(50, Color.Red)

            menuToggleIcon.Parent = panelMenuOptions;
            menuToggleIcon.BackColor = Color.Transparent;
            menuToggleIcon.Width = enVars.layoutDesign.MENU_CLOSED_STATE - 3;
            menuToggleIcon.Height = enVars.layoutDesign.MENU_CLOSED_STATE - 3;
            iconMenuSettings.Parent = panelMenuOptions;
            iconMenuSettings.BackColor = Color.Transparent;
            {
                var withBlock2 = panelMenuOptionsContainer;
                withBlock2.Parent = panelLeftSide;
                withBlock2.Height = 0;
                withBlock2.Dock = DockStyle.Top;
                withBlock2.BringToFront();
            }

            menuBuilder = new MenuBuilderClass(this, panelLeftSide, enVars, MenuBuilderClass.MENU_VERTICAL);
            enVars = menuBuilder.buildMenu();
            panelLeftSide.Controls.Add(enVars.layoutDesign.menu.menuPanelContainer);
            enVars.layoutDesign.menu.menuPanelContainer.BringToFront();
            menuBuilder.MenuUpdate(false);

            // TOP PANEL
            panelTop.Parent = this;

            // BOTTOM PANEL
            panelBottom.Parent = this;
            statusText.Parent = panelBottom;
            statusText.BackColor = Color.Transparent;
            statusMessage = "status message test";
            updateBkColorAndTransparency(this, false, false);
            ResumeLayout();

            //  ASSEMBLY Manager
            AssembliesManager = new EnvironmentAssembliesLoadClass(enVars);
        }

        private void mainAppLayoutForm_Resize(object sender, EventArgs e)
        {
            if (this.IsDisposed)
            {
                return;
            }

            if (Information.IsNothing(enVars))
            {
                return;
            }

            if ((WindowState.Equals(FormWindowState.Maximized) | WindowState.Equals(FormWindowState.Normal)) & enVars.successLogin.Equals(false) & loaded)
            {
                doLogin();
            }

            if (WindowState == FormWindowState.Minimized & loaded)
            {
                SuspendLayout();
                this.WindowState = FormWindowState.Minimized;
                ResumeLayout();
            }
            else if (loaded)
            {
                // FormRedraw.Enabled = True
            }

            if (!(WindowState == FormWindowState.Maximized) || !(WindowState == FormWindowState.Minimized))
            {
                mbDoPaintBackground = true;
                SuspendLayout();
                updateBkImageOnChildForms(this, false, default);
                ResumeLayout();
                Refresh();
            }
        }

        private void mainAppLayoutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(enVars.currentLang);
            msgbox = new messageBoxForm(resources.GetString("exitApp", CultureInfo.CurrentCulture) + " ?", resources.GetString("question", CultureInfo.CurrentCulture), MessageBoxButtons.YesNo, MessageBoxIcon.Question, this.Location.X + this.Width / 2, this.Location.Y + this.Height / 2, enVars);
            if (msgbox.ShowDialog().Equals(MsgBoxResult.No))
            {
                e.Cancel = true;
            }
            Application.RemoveMessageFilter((IMessageFilter)this);
        }
        #endregion

        #region App main menu
        private void menuPanel_Click(object sender, int menuPos)
        {
            if (enVars.layoutDesign.menu.items.ElementAt(menuPos).showAsDialog)
            {
                enVars.layoutDesign.menu.items.ElementAt(menuPos).formWithContentsToLoad.ShowDialog();
            }
            else
            {
                openChildForm(panelMain, enVars.layoutDesign.menu.items.ElementAt(menuPos).formWithContentsToLoad);
            }
        }

        private void menuPanelNotifications_click(object sender, EventArgs e)
        {
        }

        public void doMenuAnimmation(string origin)
        {
            if (panelLeftSide.Width.Equals(enVars.layoutDesign.MENU_OPEN_STATE)) // ' is open 
            {
                menuBuilder.MenuItemStateReset(false);
                menuBuilder.MenuUpdate(false);
            }
            else if (origin.Equals("main"))
            {
                menuBuilder.MenuUpdate(true);
            }
        }
        #endregion

        #region Status Message
        private void UpdateStatusMessageTimer_Tick(object sender, EventArgs e)
        {
            if (!statusMessage.Equals(statusText.Text))
            {
                if (StatusMessagesDisplayTime.Enabled.Equals(false))
                {
                    StatusMessagesDisplayTime.Enabled = true;
                }

                if (statusMessageTimeout >= 5)
                {
                    statusText.Text = statusMessage;
                    statusMessageTimeout = 0;
                }
                else
                {
                    statusMessagePile.Add(statusMessage);
                }
            }
        }

        private void StatusMessagesDisplayTime_Tick(object sender, EventArgs e)
        {
            statusMessageTimeout += 1;
            if (statusMessageTimeout.Equals(5))
            {
                if (statusMessagePile.Count > 0)
                {
                    statusMessage = statusMessagePile.ElementAt(0);
                    statusMessagePile.RemoveAt(0);
                }
            }
        }
        #endregion

        #region side panel selection clicks
        private void menuStateUpdateLayout(object sender, bool menuState)
        {
            foreach (Control ctrl in panelMenuOptions.Controls)
                ctrl.Visible = false;
            panelMenuOptions.Refresh();
            if (menuState.Equals(true))
            {
                panelLeftSide.Width = enVars.layoutDesign.MENU_OPEN_STATE;
                menuToggleIcon.Location = new Point(panelLeftSide.Width - menuToggleIcon.Width - 3 - 10, menuToggleIcon.Location.Y);
            }
            else
            {
                panelLeftSide.Width = enVars.layoutDesign.MENU_CLOSED_STATE;
                menuToggleIcon.Location = new Point(5, menuToggleIcon.Location.Y);
            }

            foreach (Control ctrl in panelMenuOptions.Controls)
                ctrl.Visible = true;
            panelMenuOptions.Refresh();
        }

        private void panelLateral_Click(object sender, EventArgs e)
        {
            if (panelLeftSide.Width.Equals(enVars.layoutDesign.MENU_OPEN_STATE)) // ' is open 
            {
                menuBuilder.MenuUpdate(false);
            }
            else
            {
                menuBuilder.MenuUpdate(true);
            }
        }

        private void menuToggleIcon_Click(object sender, EventArgs e)
        {
            if (menuToggleIcon.Location.X.Equals(5))
            {
                menuBuilder.MenuUpdate(true);
            }
            else
            {
                menuBuilder.MenuUpdate(false);
            }
        }

        #region icon quick settings side panel
        private bool optionsIsOnpen = false;

        private void iconMenuSettings_Click(object sender, EventArgs e)
        {
            if (optionsIsOnpen)
            {
                optionsIsOnpen = false;
                if (!Information.IsNothing(currentForm))
                {
                    currentForm.Close();
                }

                panelMenuOptionsContainer.Height = 0;
            }
            else
            {
                optionsIsOnpen = true;

                Type loadedType;
                FormCustomized formToLoad;

                loadedType = AssembliesManager.friendlyLoadTypeObjectFromAssembly("sideBarSettings");
                if (loadedType is null)
                {
                    msgbox = new messageBoxForm(resources.GetString("exitApp", CultureInfo.CurrentCulture) + " ?", resources.GetString("question", CultureInfo.CurrentCulture), MessageBoxButtons.YesNo, MessageBoxIcon.Question, this.Location.X + this.Width / 2, this.Location.Y + this.Height / 2, enVars);
                    msgbox.ShowDialog();
                    return;
                }
                formToLoad = Activator.CreateInstance(loadedType, enVars) as FormCustomized;
                panelMenuOptionsContainer.Height = formToLoad.Height;
                openChildForm(panelMenuOptionsContainer, formToLoad);
            }
        }
        #endregion
        #endregion

        private void panelLateralWrapper_Resize(object sender, EventArgs e)
        {
            // enVars.layoutDesign.menu.menuPanelContainer.Width = panelLeftSide.Width + enVars.layoutDesign.PANEL_SCROOL_UNDERLAY
            // enVars.layoutDesign.menu.menuPanelContainer.Height = panelLeftSide.Height - enVars.layoutDesign.menu.menuPanelContainer.Location.Y
        }

        private void resizeMenuElementsByOrder(Control previous, Control current)
        {
            if (previous is null)
            {
                current.Location = new Point(0, 0);
            }
            else
            {
                current.Location = new Point(0, previous.Location.Y + previous.Height);
            }

            current.Width = panelLeftSide.Width;
            current.Dock = DockStyle.None;
        }

        private Form currentForm = null;

        private void openChildForm(PanelDoubleBuffer targetPanel, Form childForm)
        {
            SuspendLayout();
            if (currentForm is object)
                currentForm.Close();
            currentForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.Parent = targetPanel;
            childForm.Width = targetPanel.Width;
            targetPanel.Height = childForm.Height;
            targetPanel.Controls.Add(childForm);
            targetPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.BackgroundImage = imageManipulationLib.cropImage(this.BackgroundImage, targetPanel.Location, targetPanel.Size, this.Size);
            childForm.BackgroundImageLayout = ImageLayout.Stretch;
            childForm.Show();
            ResumeLayout();
        }

        private void doLogin()
        {
            if (!loaded)
            {
                return;
            }
            // TODO clear session vars
            enVars.successLogin = false;
            if (WindowState.Equals(FormWindowState.Minimized))
            {
                return;
            }

            // 'If Application.OpenForms().OfType(Of SplashScreen).Any Then
            // 'Exit Sub
            // 'End If

            // 'Me.Hide()
            // ' If splashScreenLogin.ShowDialog() = DialogResult.OK Then
            // 'Me.Show()
            // 'Else
            // 'Application.Exit()
            // 'Close()
            // 'End If
        }

        public void NoNetwork()
        {
            if (!Information.IsNothing(CurrentWrapperForm))
            {
                CurrentWrapperForm.Close();
                CurrentWrapperForm.Dispose();
            }

            var mask = new PictureBox();
            mask.Dock = DockStyle.Fill;
            mask.Top = Convert.ToInt16(TopMost);
            mask.Image = Image.FromFile(enVars.imagesPath + enVars.externalFilesToLoad["noNetwork"]);
            mask.SizeMode = PictureBoxSizeMode.CenterImage;
            mask.Parent = panelMain;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(mask);
            mask.BringToFront();
            panelMain.Refresh();
        }

        public void UnloadForms()
        {
            if (!Information.IsNothing(CurrentWrapperForm))
            {
                CurrentWrapperForm.Close();
                CurrentWrapperForm.Dispose();
            }

            panelMain.Refresh();
        }

        private void wrapper_got_focus(object sender, EventArgs e)
        {
            enVars.layoutDesign.menu.menuPanelContainer.Width = 36;
        }

        private void wrapper_Resize(object sender, EventArgs e)
        {
            if (CurrentWrapperForm is object)
            {
                CurrentWrapperForm.Size = panelMain.Size;
                CurrentWrapperForm.Refresh();
            }
        }

        private void ChangeBackgroundTimer_Tick(object sender, EventArgs e)
        {
            bwChangeBackground.RunWorkerAsync();
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // load background files from path or web ?
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // 'Me.BackgroundImage= 
        }

        private void panelLeftSide_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
