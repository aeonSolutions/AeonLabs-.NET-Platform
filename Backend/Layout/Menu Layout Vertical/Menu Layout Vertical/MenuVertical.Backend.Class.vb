Imports System.IO
Imports System.Net
Imports AeonLabs.Environment
Imports AeonLabs.Environment.Assembly.assemblyEnvironmentVarsClass

Public Class MenuVerticalClass

    Public Property position As New menuPosition
    Public Class menuPosition
        Public Property x As Integer = 0
        Public Property y As Integer = 0
    End Class

    Public Property subMenuActiveBarColor = Color.FromArgb(80, Color.Orange)

    Public Property enVars As environmentVarsCore
    Public Property mainForm As Form
    Public Property parent As Control

    Public Event updateStausMessage(sender As Object, message As String)
    Public Event menuPanelClick(sender As Object, e As EventArgs)
    Public Event menuExpandPanelClick(sender As Object, e As EventArgs)
    Public Event menuNotificationClick(sender As Object, e As EventArgs)

    Public Property setup As New menuSetup
    Public Class menuSetup
        Public menuPanel As PanelDoubleBuffer
        Public menuTotalHeight As Integer = 0
    End Class

    Private sizeOfString As New SizeF

#Region "CONSTRUCTORS"
    Public Sub New(_mainform As Form, _envars As environmentVarsCore)
        mainForm = _mainform
        enVars = _envars

        Dim fontToMeasure As New Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.subMenuTitleFontSize, Drawing.FontStyle.Regular)
        Dim g As Graphics = mainForm.CreateGraphics
        sizeOfString = g.MeasureString("PQWER", fontToMeasure)
    End Sub
#End Region

#Region "BUILD VERTICAL MENU "
    Public Function buildMenu() As PanelDoubleBuffer
        Dim menuItems As IList(Of assemblymenuItemClass) = (From s In enVars.layoutDesign.menu.items
                                                            Where s.subMenuIndex.Equals(False)
                                                            Select s).ToList()
        Dim previousSubMenuItemsCounter As Integer = 0
        Dim totalHeight As Integer = 0

        For i = 0 To menuItems.Count - 1

            Me.setup.menuPanel = New PanelDoubleBuffer With {
            .Width = enVars.layoutDesign.menu.properties.ClosedStateSize,
            .Location = New Point(0, position.y + previousSubMenuItemsCounter * (enVars.layoutDesign.menu.properties.height + 1)),
            .Height = enVars.layoutDesign.menu.properties.height,
            .Name = menuItems(i).menuTitle,
            .Parent = parent,
            .BackColor = Color.Transparent
        }
            enVars.layoutDesign.menu.items(i).menuListIndex = i
            Dim d = i

            buildMenu(menuItems(i), 0, i)

            Dim subMenuItems As IList(Of assemblymenuItemClass) = (From s In menuItems
                                                                   Where Not s.subMenuIndex.Equals(False) And s.menuIndex.Equals(menuItems(d).menuIndex)
                                                                   Select s).ToList()

            totalHeight += (subMenuItems.Count) * enVars.layoutDesign.menu.properties.height + 1

            For j = 0 To subMenuItems.Count - 1
                buildMenu(subMenuItems(j), j, i)

            Next j
            previousSubMenuItemsCounter += subMenuItems.Count
            menuItems(i).menuWrapperOpenHeight = enVars.layoutDesign.menu.properties.height * subMenuItems.Count + subMenuItems.Count

            Dim query = enVars.layoutDesign.menu.items.Select(Function(o, k) New With {.menuItems = o, .Index = k}) _
                      .FirstOrDefault(Function(itemC) itemC.menuItems.menuTitle = menuItems(d).menuTitle)

            enVars.layoutDesign.menu.items(query.Index).menuWrapperPanel = Me.setup.menuPanel

        Next i
        ''rerturns a panel control to be added on front end layout : PanelLateral.Controls.Add(menuPanel)
        Return Me.setup.menuPanel
    End Function
#End Region


#Region "BUILD MENU ITEMS"
    Private Sub buildMenu(menuItem As assemblymenuItemClass, placeIndex As Integer, firstmenuItemListIndex As Integer)
        Dim titlePosY As Integer = 0
        Dim menuPosX As Integer = enVars.layoutDesign.menu.properties.ClosedStateSize

        Dim subMenuExpandIcon As New PictureBox
        Dim subMenuIcon As New PictureBox
        menuItem.iconPicHolder = New List(Of PictureBox)


        Dim query = enVars.layoutDesign.menu.items.Select(Function(o, i) New With {.menuItems = o, .Index = i}) _
                      .FirstOrDefault(Function(itemC) itemC.menuItems.menuTitle = menuItem.menuTitle)

        Dim subMenuPanel As New PanelDoubleBuffer With {
            .Width = enVars.layoutDesign.menu.properties.width,
            .Height = enVars.layoutDesign.menu.properties.height,
            .BackColor = enVars.layoutDesign.menu.properties.backColor,
            .Parent = Me.setup.menuPanel,
            .Name = menuItem.menuTitle & "-" & query.Index,
            .Location = New Point(0, enVars.layoutDesign.menu.properties.height * placeIndex + placeIndex)
            }

        AddHandler subMenuPanel.Click, AddressOf menuPanel_Click
        ''AddHandler subMenuPanel.MouseMove, AddressOf menuPanelLateral_mouseMove

        subMenuIcon = New PictureBox With {
        .Width = enVars.layoutDesign.menu.properties.ClosedStateSize - 10,
        .Height = enVars.layoutDesign.menu.properties.ClosedStateSize - 10,
        .Location = New Point(10 / 2, (enVars.layoutDesign.menu.properties.height - enVars.layoutDesign.menu.properties.ClosedStateSize) / 2),
        .Parent = subMenuPanel,
        .Cursor = Cursors.Hand
        }

        If menuItem.menuTitle.Equals("username") Then
            If (enVars.userPhoto.Equals("")) Then
                subMenuIcon.Image = Image.FromFile(enVars.imagesPath & "worker.icon.png")
            Else
                subMenuIcon.InitialImage = Image.FromFile(enVars.imagesPath & Convert.ToString("loading.png"))
                subMenuIcon.SizeMode = PictureBoxSizeMode.StretchImage

                Dim tClient As WebClient = New WebClient
                Try
                    'TODO where to save the files 
                    Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(enVars.ServerBaseAddr & "/csl/photos/" & enVars.userPhoto)))
                    subMenuIcon.Image = tImage
                Catch ex As Exception
                    Threading.Thread.CurrentThread.CurrentUICulture = Globalization.CultureInfo.GetCultureInfo(enVars.currentLang)

                    subMenuIcon.Image = Image.FromFile(enVars.imagesPath & Convert.ToString("worker.icon.png"))
                    RaiseEvent updateStausMessage(Me, My.Resources.strings.errorDownloadingPhoto)
                End Try
            End If

        ElseIf Not menuItem.icon.Equals("") Then
            Dim checkFile = New FileInfo(enVars.imagesPath & menuItem.icon)
            checkFile.Refresh()
            If checkFile.Exists Then
                With subMenuIcon
                    .Image = Image.FromFile(enVars.imagesPath & menuItem.icon)
                End With
            End If
        End If
        With subMenuIcon
            .SizeMode = PictureBoxSizeMode.StretchImage
        End With

        AddHandler subMenuIcon.Click, AddressOf menuPanel_Click
        ''AddHandler subMenuIcon.MouseMove, AddressOf menuPanelLateral_mouseMove

        subMenuPanel.Controls.Add(subMenuIcon)

        subMenuExpandIcon = New PictureBox With {
            .Width = enVars.layoutDesign.menu.properties.ClosedStateSize - 15,
            .Height = enVars.layoutDesign.menu.properties.ClosedStateSize - 15,
            .Image = Image.FromFile(enVars.imagesPath & "downarrow.png"),
            .SizeMode = PictureBoxSizeMode.StretchImage,
            .Location = New Point(enVars.layoutDesign.menu.properties.width - (enVars.layoutDesign.menu.properties.ClosedStateSize - 15), enVars.layoutDesign.menu.properties.height / 2 - (enVars.layoutDesign.menu.properties.ClosedStateSize - 15) / 2),
            .Parent = subMenuPanel,
            .Name = menuItem.menuTitle & "-expandIcon",
            .Cursor = Cursors.Hand
        }

        'TODO add tooltips
        AddHandler subMenuExpandIcon.Click, AddressOf menuExpandPanel_Click
        '' AddHandler subMenuExpandIcon.MouseMove, AddressOf menuPanelLateral_mouseMove

        subMenuPanel.Controls.Add(subMenuExpandIcon)

        'MENU ITEM ACTIVE BAR  =====================================================================================================================
        'TODO: ????
        menuPosX = 5 + 5
        With subMenuPanel
            .Height = sizeOfString.Height + 10
            .Location = New Point(15, subMenuPanel.Location.Y)
            .Width = subMenuPanel.Width - 15
        End With

        Dim activeBar As New PanelDoubleBuffer With {
               .Width = 5,
               .Height = subMenuPanel.Height,
               .BackColor = subMenuActiveBarColor,
               .Location = New Point(0, 0),
               .Parent = subMenuPanel
            }
        subMenuPanel.Controls.Add(activeBar)

        'MENU ITEM NOTIFICATION  =====================================================================================================================
        Dim notif As New LabelDoubleBuffer With {
                    .Location = New Point(subMenuPanel.Width - enVars.layoutDesign.menu.properties.ClosedStateSize, 5),
                    .Font = New Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.subMenuTitleFontSize, Drawing.FontStyle.Regular),
                    .Text = "",
                    .Parent = subMenuPanel,
                    .ForeColor = Color.Orange,
                    .BackColor = Color.Transparent,
                    .Cursor = Cursors.Hand
                }
        If menuItem.notifications > 0 Then
            If menuItem.notifications < 10 Then
                notif.Text = "0" & menuItem.notifications.ToString
            Else
                notif.Text = menuItem.notifications.ToString
            End If
        End If
        AddHandler notif.Click, AddressOf menuNotification_Click
        '' AddHandler notif.MouseMove, AddressOf menuPanelLateral_mouseMove
        subMenuPanel.Controls.Add(notif)

        'MENU ITEM TITLE TEXT =====================================================================================================================
        If menuItem.menuTitle.Equals("username") Then
            Dim subtitle As New LabelDoubleBuffer With {
                    .Font = New Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.subMenuTitleFontSize, Drawing.FontStyle.Regular),
                    .Location = New Point(menuPosX, 26),
                    .Text = enVars.customization.businessname,
                    .Parent = Me.setup.menuPanel,
                    .ForeColor = Color.White,
                    .BackColor = Color.Transparent,
                    .Width = enVars.layoutDesign.menu.properties.width,
                    .Cursor = Cursors.Hand
                }

            AddHandler subtitle.Click, AddressOf menuPanel_Click
            ''  AddHandler subtitle.MouseMove, AddressOf menuPanelLateral_mouseMove

            Me.setup.menuPanel.Controls.Add(subtitle)
            titlePosY = 5
        ElseIf placeIndex = 0 Then
            titlePosY = (Me.setup.menuPanel.Height - sizeOfString.Height) / 2 - 5
        Else
            titlePosY = 5
        End If

        Dim title As New LabelDoubleBuffer With {
                .Font = New Font(enVars.layoutDesign.fontTitle.Families(0), enVars.layoutDesign.menuTitleFontSize, Drawing.FontStyle.Regular),
                .Location = New Point(menuPosX, titlePosY),
                .Text = If(menuItem.menuTitle.Equals("username"), If(enVars.username.Equals(""), "menuProfileTitle", enVars.username), "subTitle"),
                .Parent = Me.setup.menuPanel,
                .ForeColor = Color.White,
                .BackColor = Color.Transparent,
                .Width = enVars.layoutDesign.menu.properties.width,
                .Cursor = Cursors.Hand
            }

        AddHandler title.Click, AddressOf menuPanel_Click
        ''AddHandler title.MouseMove, AddressOf menuPanelLateral_mouseMove
        subMenuPanel.Controls.Add(title)
        ''AddHandler menuPanel.MouseMove, AddressOf menuPanelLateral_mouseMove
        Me.setup.menuPanel.Controls.Add(subMenuPanel)


        enVars.layoutDesign.menu.items(query.Index).menuListIndex = firstmenuItemListIndex
        enVars.layoutDesign.menu.items(query.Index).menuItemPanel = subMenuPanel
        enVars.layoutDesign.menu.items(query.Index).iconPicHolder = New List(Of PictureBox)
        enVars.layoutDesign.menu.items(query.Index).iconPicHolder.Add(subMenuIcon)
        enVars.layoutDesign.menu.items(query.Index).iconPicHolder.Add(subMenuExpandIcon)

    End Sub
#End Region

#Region "MENU EVENTS"
    Private Sub menuPanel_Click(sender As Object, e As EventArgs)
        RaiseEvent menuPanelClick(sender, e)
    End Sub

    Private Sub menuExpandPanel_Click(sender As Object, e As EventArgs)
        RaiseEvent menuExpandPanelClick(sender, e)
    End Sub

    Private Sub menuNotification_Click(sender As Object, e As EventArgs)
        RaiseEvent menuNotificationClick(sender, e)
    End Sub
#End Region
End Class
