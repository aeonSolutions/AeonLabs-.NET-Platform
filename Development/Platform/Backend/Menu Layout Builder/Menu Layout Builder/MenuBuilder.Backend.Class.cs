using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using AeonLabs.Environment.Core;
using AeonLabs.Layouts.Dialogs;
using FontAwesome.Sharp;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using static AeonLabs.Environment.Core.menuEnvironmentVarsClass;

namespace AeonLabs.Layouts.MenuBuilder
{
    public class MenuBuilderClass
    {
        #region Public Vars
        public const int MENU_HORIZONTAL = 100;
        public const int MENU_VERTICAL = 200;

        public menuPosition position { get; set; } = new menuPosition();

        public class menuPosition
        {
            public int x { get; set; } = 0;
            public int y { get; set; } = 0;
        }

        public event updateStausMessageEventHandler updateStausMessage;
        public delegate void updateStausMessageEventHandler(object sender, string message);
        public event menuPanelClickEventHandler menuPanelClick;
        public delegate void menuPanelClickEventHandler(object sender, int menuPos);

        public event menuPanelMouseOverEventEventHandler menuPanelMouseOverEvent;

        public delegate void menuPanelMouseOverEventEventHandler(object sender, int menuPos);

        public event menuExpandPanelClickEventHandler menuExpandPanelClick;

        public delegate void menuExpandPanelClickEventHandler(object sender, EventArgs e);

        public event menuNotificationClickEventHandler menuNotificationClick;

        public delegate void menuNotificationClickEventHandler(object sender, EventArgs e);

        public event menuStateUpdateLayoutEventHandler menuStateUpdateLayout;

        public delegate void menuStateUpdateLayoutEventHandler(object sender, bool menuState);

        public menuSetup setup { get; set; } = new menuSetup();
        public bool menuIsBeingUpdated { get; set; } = false;
        public class menuSetup
        {
            public PanelDoubleBuffer MenuContainer = new PanelDoubleBuffer();
            public PanelDoubleBuffer menuPanel;
            public int menuTotalHeight = 0;
        }
        #endregion

        #region Private vars
        private SizeF sizeOfString = new SizeF();
        private int menuOrientation;
        private environmentVarsCore enVars;
        private Form mainForm;
        private PanelDoubleBuffer menuPanel;
        private string previousPanelName = null;
        private Control previousPanelmouseOver = null;
        private Control previousControlmouseOver = null;
        private Control previousPanelToToggle = null;
        private Timer previousPanelTimer = new Timer();
        private object entry = "";
        private ResourceManager resources;
        private environmentVarsCore.updateMainLayoutDelegate updateMainApp;
        #endregion

        #region constructor
        public MenuBuilderClass(Form _mainform, PanelDoubleBuffer _menuPanel, environmentVarsCore _envars, int _menuOrientation, ref environmentVarsCore.updateMainLayoutDelegate _updateMainApp)
        {
            resources = new ResourceManager(GetType().Namespace + ".config.strings", Assembly.GetExecutingAssembly());
            updateMainApp = _updateMainApp;
            mainForm = _mainform;
            enVars = _envars;
            menuOrientation = _menuOrientation;
            menuPanel = _menuPanel;
            if (enVars.layoutDesign.fontTitle.Families.Count() < 1)
            {
                Interaction.MsgBox("Font files not loaded properly:" + ToString());
                return;
            }

            var fontToMeasure = new Font(enVars.layoutDesign.fontTitle.Families[0], enVars.layoutDesign.subMenuTitleFontSize, FontStyle.Regular);
            var g = mainForm.CreateGraphics();
            sizeOfString = g.MeasureString("PQWER", fontToMeasure);
            previousPanelTimer.Interval = 300;
            previousPanelTimer.Tick += (_, __) => delayActiveBar();
        }
        #endregion

        #region Build Menu

        public environmentVarsCore buildMenu()
        {
            IList<menuItemClass> menuItems = (IList<menuItemClass>)(from s in enVars.layoutDesign.menu.items
                                                                    where s.subMenuIndex==0
                                                                    select s).ToList();
            if (menuItems.Count == 0)
            {
                Interaction.MsgBox("No menu items found!");
            }
            int previousSubMenuItemsCounter = 0;
            setup.menuTotalHeight = 0;
            int menuItemsCount = 0;
            Point panelPos;
            for (int i = 0, loopTo = menuItems.Count - 1; i <= loopTo; i++)
            {
                if (menuOrientation.Equals(MENU_VERTICAL))
                {
                    panelPos = new Point(position.x, position.y + previousSubMenuItemsCounter * enVars.layoutDesign.menu.properties.height);
                }
                else // MENU IS HORIZONTAL
                {
                    panelPos = new Point(position.x + enVars.layoutDesign.menu.properties.width * i, position.y);
                }

                setup.menuPanel = new PanelDoubleBuffer()
                {
                    Width = enVars.layoutDesign.menu.properties.width,
                    Location = panelPos,
                    Height = enVars.layoutDesign.menu.properties.height,
                    Name = menuItems[i].menuTitle,
                    Parent = setup.MenuContainer,
                    BackColor = Color.Transparent // Color.FromArgb(255, CInt(Math.Ceiling(Rnd() * 255)) + 1, CInt(Math.Ceiling(Rnd() * 255)) + 1, CInt(Math.Ceiling(Rnd() * 255)) + 1)
                };
                enVars.layoutDesign.menu.items[i].menuListIndex = i;
                int d = i;

                // build top menu option
                buildMenuOption(menuItems[i], 0, i, menuItemsCount);
                menuItemsCount += 1;
                IList<menuItemClass> subMenuItems = (from s in enVars.layoutDesign.menu.items
                                                     where !s.subMenuIndex.Equals(0) & s.menuIndex.Equals(menuItems[d].menuIndex)
                                                     select s).ToList();
                setup.menuTotalHeight += subMenuItems.Count * enVars.layoutDesign.menu.properties.height;
                for (int j = 1, loopTo1 = subMenuItems.Count; j <= loopTo1; j++)
                {
                    buildMenuOption(subMenuItems[j - 1], j, i, menuItemsCount);
                    menuItemsCount += 1;
                }

                previousSubMenuItemsCounter += subMenuItems.Count + 1;
                menuItems[i].menuWrapperOpenHeight = enVars.layoutDesign.menu.properties.height * subMenuItems.Count + subMenuItems.Count;
                var index = enVars.layoutDesign.menu.items.FindIndex(c => c.menuUID.Equals(menuItems[d].menuUID));
                setup.menuPanel.Height = (subMenuItems.Count + 1) * enVars.layoutDesign.menu.properties.height;
                enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperOpenHeight = (subMenuItems.Count + 1) * enVars.layoutDesign.menu.properties.height;
                enVars.layoutDesign.menu.items[index].menuWrapperPanel = setup.menuPanel;
                setup.MenuContainer.Controls.Add(setup.menuPanel);
            }

            {
                var withBlock = setup.MenuContainer;
                withBlock.Parent = menuPanel;
                // hack to hide the scrool bars
                withBlock.Width = menuPanel.Width + enVars.layoutDesign.PANEL_SCROOL_UNDERLAY;
                withBlock.Location = new Point(0, 0);
                withBlock.BackColor = Color.Transparent;
                withBlock.Dock = DockStyle.Top;
                withBlock.AutoSize = true;
                withBlock.AutoScroll = false;
            }

            enVars.layoutDesign.menu.menuPanelContainer = setup.MenuContainer;
            return enVars;
        }
        #endregion

        #region Build Menu Option
        private void buildMenuOption(menuItemClass menuItem, int placeIndex, int firstmenuItemListIndex, int menuItemsCount)
        {
            int titlePosY = 0;
            int menuPosX = enVars.layoutDesign.menu.properties.ClosedStateSize;
            int iconSize = Convert.ToInt16(enVars.layoutDesign.menu.properties.ClosedStateSize * 0.7);
            var subMenuExpandIcon = new IconPictureBox();
            var subMenuIcon = new PictureBox();
            menuItem.iconPicHolder = new List<PictureBox>();
            PanelDoubleBuffer activeBar;
            var index = enVars.layoutDesign.menu.items.FindIndex(c => c.menuUID.Equals(menuItem.menuUID));
            var subMenuPanel = new PanelDoubleBuffer()
            {
                Width = enVars.layoutDesign.menu.properties.width,
                Height = enVars.layoutDesign.menu.properties.height,
                BackColor = enVars.layoutDesign.menu.properties.backColor,
                Parent = setup.menuPanel,
                Name = menuItem.menuUID + "-" + index,
                Location = new Point(0, enVars.layoutDesign.menu.properties.height * placeIndex)
            };
            subMenuPanel.Click += menuPanel_Click;
            if (placeIndex.Equals(0))
            {

                subMenuIcon = new PictureBox()
                {
                    Width = iconSize,
                    Height = iconSize,
                    Location = new Point((enVars.layoutDesign.menu.properties.height - iconSize) / 2, (enVars.layoutDesign.menu.properties.height - iconSize) / 2),
                    Parent = subMenuPanel,
                    Cursor = Cursors.Hand
                };
                if (menuItem.menuTitle.Equals("username"))
                {
                    if (enVars.userPhoto.Equals(""))
                    {
                        subMenuIcon.Image = Image.FromFile(enVars.imagesPath + "worker.icon.png");
                    }
                    else
                    {
                        subMenuIcon.InitialImage = Image.FromFile(enVars.imagesPath + Convert.ToString("loading.png"));
                        subMenuIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                        var tClient = new WebClient();
                        try
                        {
                            // TODO where to save the files 
                            Bitmap tImage = (Bitmap)Image.FromStream(new MemoryStream(tClient.DownloadData(enVars.ServerBaseAddr + "/csl/photos/" + enVars.userPhoto)));
                            subMenuIcon.Image = tImage;
                        }
                        catch (Exception ex)
                        {
                            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(enVars.currentLang);
                            subMenuIcon.Image = Image.FromFile(enVars.imagesPath + Convert.ToString("worker.icon.png"));
                            updateStausMessage?.Invoke(this, resources.GetString("errorDownloadingPhoto"));
                        }
                    }
                }
                else if (!menuItem.icon.Equals(""))
                {
                    var checkFile = new FileInfo(enVars.imagesPath + menuItem.icon);
                    checkFile.Refresh();
                    if (checkFile.Exists)
                    {
                        subMenuIcon.Image = Image.FromFile(enVars.imagesPath + menuItem.icon);
                    }
                }

                subMenuIcon.SizeMode = PictureBoxSizeMode.StretchImage;
                subMenuIcon.Click += menuPanel_Click;
                subMenuPanel.Controls.Add(subMenuIcon);
                
                //expand icon
                subMenuExpandIcon = new IconPictureBox()
                {
                    IconColor = enVars.layoutDesign.labelForeColor,
                    BackColor = Color.Transparent,
                    Cursor = Cursors.Hand,
                    IconChar = IconChar.ArrowDown,
                    IconSize = iconSize,
                    Location = new Point(enVars.layoutDesign.menu.properties.width - enVars.layoutDesign.menu.properties.height, Convert.ToInt16(enVars.layoutDesign.menu.properties.height / 2 - iconSize / 2)),
                    Name = menuItem.menuUID + "_expandIcon-" + index,
                    Size = new Size(enVars.layoutDesign.menu.properties.height - 6, enVars.layoutDesign.menu.properties.height - 6),
                    Parent = subMenuPanel
                };

                // TODO add tooltips
                subMenuExpandIcon.Click += menuExpandPanel_Click;
                subMenuPanel.Controls.Add(subMenuExpandIcon);
            }

            // MENU ITEM ACTIVE BAR  =====================================================================================================================
            // TODO: ????
            if (placeIndex.Equals(0))
            {
                menuPosX = enVars.layoutDesign.menu.properties.height;
            }
            else
            {
                menuPosX = enVars.layoutDesign.menu.properties.activeBarWidth + 5;
            }

            if (placeIndex > 0)
            {
                activeBar = new PanelDoubleBuffer()
                {
                    Width = enVars.layoutDesign.menu.properties.activeBarWidth,
                    Height = subMenuPanel.Height - 1,
                    BackColor = Color.Transparent,
                    Location = new Point(0, 0),
                    Parent = subMenuPanel,
                    Name = menuItem.menuUID + "_activeBar-" + index
                };
                subMenuPanel.Controls.Add(activeBar);
            }
            else
            {
                activeBar = default;
            }

            // MENU ITEM NOTIFICATION  =====================================================================================================================
            var notif = new LabelDoubleBuffer()
            {
                Location = new Point(subMenuPanel.Width - enVars.layoutDesign.menu.properties.ClosedStateSize, 5),
                Font = new Font(enVars.layoutDesign.fontTitle.Families[0], enVars.layoutDesign.subMenuTitleFontSize, FontStyle.Regular),
                Text = "",
                Parent = subMenuPanel,
                ForeColor = Color.Orange,
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand,
                Name = menuItem.menuUID + "_notificationIcon-" + index
            };
            if (menuItem.notifications > 0)
            {
                if (menuItem.notifications < 10)
                {
                    notif.Text = "0" + menuItem.notifications.ToString();
                }
                else
                {
                    notif.Text = menuItem.notifications.ToString();
                }
            }

            notif.Click += menuNotification_Click;
            subMenuPanel.Controls.Add(notif);

            // MENU ITEM TITLE TEXT =====================================================================================================================
            if (menuItem.menuTitle.Equals("username"))
            {
                var subtitle = new LabelDoubleBuffer()
                {
                    Font = new Font(enVars.layoutDesign.fontTitle.Families[0], enVars.layoutDesign.subMenuTitleFontSize, FontStyle.Regular),
                    Location = new Point(menuPosX, 26),
                    Text = enVars.customization.businessname,
                    Parent = setup.menuPanel,
                    ForeColor = Color.White,
                    BackColor = Color.Transparent,
                    Width = enVars.layoutDesign.menu.properties.width,
                    Cursor = Cursors.Hand
                };
                subtitle.Click += menuPanel_Click;
                setup.menuPanel.Controls.Add(subtitle);
                titlePosY = 5;
            }
            else if (placeIndex.Equals(0))
            {
                titlePosY = Convert.ToInt16((setup.menuPanel.Height - sizeOfString.Height) / 2);
            }
            else
            {
                titlePosY = Convert.ToInt16((setup.menuPanel.Height - sizeOfString.Height) / 2);
            }

            var title = new LabelDoubleBuffer()
            {
                Font = new Font(enVars.layoutDesign.fontTitle.Families[0], enVars.layoutDesign.menuTitleFontSize, FontStyle.Regular),
                Location = new Point(menuPosX, titlePosY),
                Text = menuItem.menuTitle.Equals("username") ? enVars.username.Equals("") ? "user" : enVars.username : menuItem.menuTitle,
                Parent = setup.menuPanel,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Width = enVars.layoutDesign.menu.properties.width,
                Cursor = Cursors.Hand,
                Name = menuItem.menuUID + "_title-" + index
            };
            title.Click += menuPanel_Click;
            subMenuPanel.Controls.Add(title);
            setup.menuPanel.Controls.Add(subMenuPanel);
            enVars.layoutDesign.menu.items[index].menuListIndex = firstmenuItemListIndex;
            enVars.layoutDesign.menu.items[index].menuItemPanel = subMenuPanel;
            enVars.layoutDesign.menu.items[index].menuActiveBarPanel = activeBar;
            enVars.layoutDesign.menu.items[index].iconPicHolder = new List<PictureBox>();
            enVars.layoutDesign.menu.items[index].iconPicHolder.Add(subMenuIcon);
            enVars.layoutDesign.menu.items[index].iconPicHolderFontAwesome[1] = subMenuExpandIcon;
        }
        #endregion region

        #region Menu Events
        private void menuPanelToggleActiveBar(object sender, EventArgs e)
        {
            string menukey = "";
            int subMenuPos = 0;
            Control ctrl = (Control)sender;
            var clickedMenuPanel = new Control();
            if (sender is Panel)
            {
                if (!ctrl.Name.Equals(menuPanel.Name))
                {
                    clickedMenuPanel = ctrl;
                }
                else if (ctrl.Parent is object)
                {
                    if (ctrl.Parent.Parent.Name.Equals("panelLateral"))
                    {
                        clickedMenuPanel = ctrl.Parent;
                    }
                }
            }

            if (sender is LabelDoubleBuffer)
            {
                clickedMenuPanel = ctrl.Parent;
            }

            if (sender is PictureBox) // menu icon
            {
                clickedMenuPanel = ctrl.Parent;
            }

            if (clickedMenuPanel.Name.IndexOf("-") > 0)
            {
                if (clickedMenuPanel.Name.IndexOf("_") > 0)
                {
                    menukey = clickedMenuPanel.Name.Substring(0, clickedMenuPanel.Name.IndexOf("_"));
                }
                else
                {
                    menukey = clickedMenuPanel.Name.Substring(0, clickedMenuPanel.Name.IndexOf("-"));
                }

                subMenuPos = Conversions.ToInteger(clickedMenuPanel.Name.Substring(clickedMenuPanel.Name.IndexOf("-") + 1));
                clickedMenuPanel.SuspendLayout();
                if (previousPanelmouseOver is object)
                {
                    previousPanelToToggle = previousPanelmouseOver;
                    if (!previousPanelmouseOver.Parent.Equals(clickedMenuPanel)) // if menu items are diferent 
                    {
                        clickedMenuPanel.Controls[menukey + "_title-" + subMenuPos].Text = VBMath.Rnd().ToString();
                        entry = "1";
                        previousPanelmouseOver.BackColor = Color.Transparent;
                        clickedMenuPanel.Controls[menukey + "_activeBar-" + subMenuPos].BackColor = enVars.layoutDesign.menu.properties.activeBarColor;
                    }
                    else if (previousPanelmouseOver.Equals(clickedMenuPanel))
                    {
                        previousPanelTimer.Start();
                        entry = "2";
                    }
                    else if (previousControlmouseOver.Equals(ctrl)) // exiting the previous= current control
                    {
                        previousPanelTimer.Start();
                        entry = "3";
                    }
                    else if (!previousControlmouseOver.Equals(ctrl)) // entering control inside same panel
                    {
                        // If entry.Equals("3") Then
                        // previousPanelTimer.Start()
                        // Else
                        clickedMenuPanel.Controls[menukey + "_activeBar-" + subMenuPos].BackColor = enVars.layoutDesign.menu.properties.activeBarColor;
                        previousPanelTimer.Stop();
                        entry = "4";
                    }
                    // End If

                    else if (previousPanelmouseOver.Parent.Equals(clickedMenuPanel)) // exiting the menu item panel
                    {
                        entry = "5";
                        previousPanelmouseOver = null;
                        previousPanelTimer.Start();
                    }
                }
                else
                {
                    entry = "6";
                    previousPanelTimer.Stop();
                    clickedMenuPanel.Controls[menukey + "_activeBar-" + subMenuPos].BackColor = enVars.layoutDesign.menu.properties.activeBarColor;
                }

                clickedMenuPanel.ResumeLayout();
                mainForm.Controls["panelMain"].Controls["Label1"].Text += Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(ctrl.Name + "(", entry), ")"), " >> ");
                previousPanelmouseOver = clickedMenuPanel.Controls[menukey + "_activeBar-" + subMenuPos];
                previousPanelName = menukey + "_activeBar-" + subMenuPos;
                previousControlmouseOver = ctrl;
            }
        }

        private void delayActiveBar()
        {
            previousPanelToToggle.BackColor = Color.Transparent;
            previousPanelmouseOver = null;
            entry = "";
            mainForm.Controls["panelMain"].Controls["Label1"].Text = "";
            previousPanelTimer.Stop();
        }

        private void menuPanel_Click(object sender, EventArgs e)
        {
            string menukey = "";
            int subMenuPos = 0;
            Control ctrl = (Control)sender;
            var clickedMenuPanel = new Control();
            if (sender is Panel)
            {
                if (!ctrl.Name.Equals(menuPanel.Name))
                {
                    clickedMenuPanel = ctrl;
                }
                else if (ctrl.Parent is object)
                {
                    if (ctrl.Parent.Parent.Name.Equals("panelLateral"))
                    {
                        clickedMenuPanel = ctrl.Parent;
                    }
                }
            }

            if (sender is LabelDoubleBuffer)
            {
                clickedMenuPanel = ctrl.Parent;
            }

            if (sender is PictureBox) // menu icon
            {
                clickedMenuPanel = ctrl.Parent;
                menukey = clickedMenuPanel.Name.Substring(0, clickedMenuPanel.Name.IndexOf("-"));
                subMenuPos = Conversions.ToInteger(clickedMenuPanel.Name.Substring(clickedMenuPanel.Name.IndexOf("-") + 1));
                if (clickedMenuPanel.Width.Equals(enVars.layoutDesign.MENU_OPEN_STATE)) // ' its open the lateral bar
                {
                    if (enVars.layoutDesign.menu.items.ElementAt(subMenuPos).isOpen.Equals(false)) // ' menu is closed
                    {
                        enVars.layoutDesign.menu.items.ElementAt(subMenuPos).isOpen = true;
                        MenuUpdate(true);
                    }
                    else
                    {
                        MenuItemStateReset(false);
                        MenuUpdate(false);
                    }
                }
                else
                {
                    enVars.layoutDesign.menu.items.ElementAt(subMenuPos).isOpen = true;
                    MenuUpdate(true);
                }

                return;
            }

            // 'is the submenu wrapper panel ?
            if (clickedMenuPanel.Name.IndexOf("-") > -1)
            {
                menukey = clickedMenuPanel.Name.Substring(0, clickedMenuPanel.Name.IndexOf("-"));
                subMenuPos = Conversions.ToInteger(clickedMenuPanel.Name.Substring(clickedMenuPanel.Name.IndexOf("-") + 1));
            }
            else
            {
                menukey = clickedMenuPanel.Name;
                subMenuPos = 0;
            }

            // 'no content to load and is also menu title
            if (enVars.layoutDesign.menu.items.ElementAt(subMenuPos).formWithContentsToLoad is null & enVars.layoutDesign.menu.items.ElementAt(subMenuPos).subMenuIndex.Equals(0))
            {
                enVars.layoutDesign.menu.items.ElementAt(subMenuPos).isOpen = !enVars.layoutDesign.menu.items.ElementAt(subMenuPos).isOpen;
                // 'leave lateral pane open
                MenuUpdate(true);
            }

            //Load contents 
            Type loadedType;
            FormCustomized formToLoad;

            loadedType = enVars.AssembliesManager.friendlyLoadTypeObjectFromAssembly(enVars.layoutDesign.menu.items.ElementAt(subMenuPos).assemblyFriendlyUID);
            if (loadedType is null)
            {
                messageBoxForm msgbox = new messageBoxForm(resources.GetString("errorPlugIn", CultureInfo.CurrentCulture) + " ! \n\r" + enVars.AssembliesManager.errorMessage, resources.GetString("exclamation", CultureInfo.CurrentCulture), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                msgbox.ShowDialog();
                return;
            }
            formToLoad = Activator.CreateInstance(loadedType, enVars, updateMainApp) as FormCustomized;

            if (enVars.layoutDesign.menu.items.ElementAt(subMenuPos).formWithContentsToLoad != null)
            {
                MenuUpdate(false);
                MenuItemActiveBarReset();
                enVars.layoutDesign.menu.items.ElementAt(subMenuPos).menuActiveBarPanel.BackColor = enVars.layoutDesign.menu.properties.activeBarColor;
                menuPanelClick?.Invoke(sender, subMenuPos);
            }
        }

        private void menuExpandPanel_Click(object sender, EventArgs e)
        {
            Panel menuPanel;
            Control ctrl;
            ctrl = (Control)sender;
            menuPanel = (Panel)ctrl.Parent;
            string menuKey = menuPanel.Name.Substring(0, menuPanel.Name.IndexOf("-"));
            int submenuPos = Conversions.ToInteger(menuPanel.Name.Substring(menuPanel.Name.IndexOf("-") + 1));
            if (enVars.layoutDesign.menu.items.ElementAt(submenuPos).subMenuIndex.Equals(0))
            {
                enVars.layoutDesign.menu.items.ElementAt(submenuPos).isOpen = !enVars.layoutDesign.menu.items.ElementAt(submenuPos).isOpen;
                MenuUpdate(true);
                return;
            }

            // TODO
            bool menuState = true;
            if (enVars.layoutDesign.menu.items.ElementAt(0).menuWrapperPanel.Width.Equals(enVars.layoutDesign.MENU_OPEN_STATE))
            {
                menuState = false;
            }

            menuExpandPanelClick?.Invoke(sender, e);
        }

        private void menuNotification_Click(object sender, EventArgs e)
        {
            menuNotificationClick?.Invoke(sender, e);
        }
        #endregion

        #region Menu Update
        public void MenuUpdate(bool menuState)
        {
            if (menuIsBeingUpdated)
                return;
            menuIsBeingUpdated = true;
            menuStateUpdateLayout.Invoke(this, menuState);
            int menuPosY = 0;
            IList<menuItemClass> menuItems = (from s in enVars.layoutDesign.menu.items
                                              where s.subMenuIndex.Equals(0)
                                              select s).ToList();
            for (int i = 0, loopTo = menuItems.Count - 1; i <= loopTo; i++)
            {
                int d = i;
                var index = enVars.layoutDesign.menu.items.FindIndex(c => c.menuUID.Equals(menuItems[d].menuUID));

                // 'do opeing / closing of menu
                if (enVars.layoutDesign.menu.items.ElementAt(index).isOpen)
                {
                    enVars.layoutDesign.menu.items.ElementAt(index).iconPicHolderFontAwesome[1].IconChar = IconChar.AngleUp;
                    enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperPanel.Height = enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperOpenHeight;
                }
                else
                {
                    enVars.layoutDesign.menu.items.ElementAt(index).iconPicHolderFontAwesome[1].IconChar = IconChar.AngleDown;
                    enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperPanel.Height = enVars.layoutDesign.menu.properties.height;
                }

                if (menuState.Equals(true))
                {
                    enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperPanel.Width = enVars.layoutDesign.MENU_OPEN_STATE;
                }
                else
                {
                    enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperPanel.Width = enVars.layoutDesign.MENU_CLOSED_STATE;
                }

                enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperPanel.Location = new Point(enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperPanel.Location.X, menuPosY);
                menuPosY = menuPosY + enVars.layoutDesign.menu.items.ElementAt(index).menuWrapperPanel.Height;
            }
            menuIsBeingUpdated = false;
        }

        public void MenuItemActiveBarReset()
        {
            var loopTo = enVars.layoutDesign.menu.items.Count - 1;
            for (int i = 0; i <= loopTo; i++)
                enVars.layoutDesign.menu.items.ElementAt(i).menuActiveBarPanel.BackColor = Color.Transparent;
        }

        public void MenuItemStateReset(bool menuState)
        {
            var loopTo = enVars.layoutDesign.menu.items.Count - 1;
            for (int i = 0; i <= loopTo; i++)
                enVars.layoutDesign.menu.items.ElementAt(i).isOpen = menuState;
        }
        #endregion
    }
}
