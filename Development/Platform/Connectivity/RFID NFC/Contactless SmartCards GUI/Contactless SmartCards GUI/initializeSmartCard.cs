using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using siteConstructionSiteLogistics.SmartCards.Library;

namespace ConstructionSiteLogistics.SmartCards.GUI
{
    public partial class initializeSmartCard
    {
        public initializeSmartCard()
        {
            InitializeComponent();
            _closeBtn.Name = "closeBtn";
            _Panel1.Name = "Panel1";
            _authCode_lbl.Name = "authCode_lbl";
            _readCodeOnly.Name = "readCodeOnly";
            _cardIdCode.Name = "cardIdCode";
            _progressBar.Name = "progressBar";
            _StartBtn.Name = "StartBtn";
            _PictureBox1.Name = "PictureBox1";
        }

        public initializeSmartCard(MainMdiForm _mainMdiForm, environmentVars _state, Dictionary<string, string> _currentFormData)
        {
            mainForm = _mainMdiForm;
            state = _state;
            currentFormData = _currentFormData;
            // has: cardId, authString, userCode, pin

            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SuspendLayout();
            InitializeComponent();
            ResumeLayout();
            _closeBtn.Name = "closeBtn";
            _Panel1.Name = "Panel1";
            _authCode_lbl.Name = "authCode_lbl";
            _readCodeOnly.Name = "readCodeOnly";
            _cardIdCode.Name = "cardIdCode";
            _progressBar.Name = "progressBar";
            _StartBtn.Name = "StartBtn";
            _PictureBox1.Name = "PictureBox1";
        }

        private messageBoxForm msgbox;
        private environmentVars state = new environmentVars();
        private languageTranslations translations;
        private smartCard nfCard = new smartCard();

        public MainMdiForm mainForm { get; set; }

        private string currentUID = "";
        private string currentCode = "";
        private string currentPin = "";
        private Dictionary<string, string> currentFormData;

        public event getSmartCardDetailsEventHandler getSmartCardDetails;

        public delegate void getSmartCardDetailsEventHandler(object sender, Dictionary<string, string> args);

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void CloseMe()
        {
            Close();
        }

        private void meteo_frm_Load(object sender, EventArgs e)
        {
            state = mainForm.state;
            translations = new languageTranslations(state);
            SuspendLayout();
            closeBtn.BackColor = state.buttonColor;
            StartBtn.BackColor = state.buttonColor;
            closeBtn.Font = new Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular);
            StartBtn.Font = new Font(state.fontText.Families(0), state.RegularTextFontSize, FontStyle.Regular);
            translations.load("commonForm");
            closeBtn.Text = translations.getText("closeBtn");
            translations.load("smartcard");
            StartBtn.Text = translations.getText("newCard");
            readCodeOnly.Text = translations.getText("readCodeOnly");
            cardIdCode.Text = translations.getText("cardId") + ": - -";
            authCode_lbl.Text = translations.getText("authCode") + ": - -";
            ResumeLayout();
        }

        private void form_frm_show(object sender, EventArgs e)
        {
            nfCard = new smartCard();
            var smartCardReaders = new List<string>();
            string errMsg = "";
            StartBtn.Enabled = false;
            readCodeOnly.Enabled = false;
            cardIdCode.Visible = false;
            authCode_lbl.Visible = false;
            nfCard = new smartCard();
            if (nfCard.SelectDevice())
            {
                if (nfCard.GetAvailableReaders(smartCardReaders, errMsg))
                {
                    StartBtn.Enabled = true;
                    readCodeOnly.Enabled = true;
                    cardIdCode.Visible = true;
                    authCode_lbl.Visible = true;
                    nfCard.establishContext();
                }
            }

            progressBar.Value = 0;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            if (!currentFormData["cardId"].Equals(currentUID) | !currentFormData["authString"].Equals(currentCode))
            {
                translations.load("smartcard");
                string message = translations.getText("questionLoadValuesIntoForm");
                translations.load("messagebox");
                msgbox = new messageBoxForm(message + " ?", translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgbox.ShowDialog() == DialogResult.Yes)
                {
                    var sendData = new Dictionary<string, string>();
                    sendData.Add("CardId", AddSpaces(currentUID, 3));
                    sendData.Add("authString", currentCode.Substring(0, 4) + " - " + currentCode.Substring(4, 3) + " - " + currentCode.Substring(7, 5));
                    getSmartCardDetails?.Invoke(this, sendData);
                }
            }

            Close();
        }

        private void SaveAuthString_Click(object sender, EventArgs e)
        {
            nfCard = new smartCard();
            if (!nfCard.SelectDevice())
            {
                return;
            }
            else
            {
                nfCard.establishContext();
            }

            StartBtn.Enabled = false;
            readCodeOnly.Enabled = false;
            if (nfCard.connectCard())
            {
                progressBar.Value = 0;
                if (!nfCard.readCardUID())
                {
                    progressBar.Value = 0;
                    StartBtn.Enabled = true;
                    readCodeOnly.Enabled = true;
                    mainForm.statusMessage = "erro ao ler ID cartao";
                    return;
                }
                else if (nfCard.getCardUIDString().Equals(""))
                {
                    progressBar.Value = 0;
                    StartBtn.Enabled = true;
                    readCodeOnly.Enabled = true;
                    mainForm.statusMessage = "erro ao ler ID vazio";
                    return;
                }

                string cardUID = nfCard.getCardUIDString();
                progressBar.Value = 50;
                if (cardUID.Equals(currentFormData["cardId"].Replace(" ", "")) & !currentFormData["authString"].Equals(""))
                {
                    translations.load("smartcard");
                    string message = translations.getText("questionCardIsInitialized");
                    translations.load("messagebox");
                    msgbox = new messageBoxForm(message, translations.getText("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msgbox.ShowDialog() != DialogResult.Yes)
                    {
                        StartBtn.Enabled = true;
                        readCodeOnly.Enabled = true;
                        return;
                    }
                }

                string workerCode = "";
                var rnd = new Random();
                VBMath.Randomize();
                if (Conversions.ToInteger(currentFormData["userCode"]) < 10)
                {
                    workerCode = "00" + Conversions.ToInteger(currentFormData["userCode"]).ToString();
                }
                else if (Conversions.ToInteger(currentFormData["userCode"]) < 100)
                {
                    workerCode = "0" + Conversions.ToInteger(currentFormData["userCode"]).ToString();
                }
                else
                {
                    workerCode = Conversions.ToInteger(currentFormData["userCode"]).ToString();
                }

                // auth format is PIN number (4 digits) + cod_worker DB(3 digits including left zeros) + 5 digit random string for a total of 12 bytes or 3 blocks
                string newAuthStr;
                if (currentFormData.ContainsKey("pin"))
                {
                    newAuthStr = currentFormData.ContainsKey("pin") + workerCode + randomString[5];
                }
                else
                {
                    newAuthStr = rnd.Next(1000, 10000).ToString() + workerCode + randomString[5];
                }

                if (!nfCard.SaveStringOnCard(newAuthStr, 5)) // Please make sure you do not write data into these Authentication Blocks 0-4 for mifare ntag 215.
                {
                    translations.load("messagebox");
                    msgbox = new messageBoxForm(nfCard.errorMessage, translations.getText("exclamation"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    msgbox.ShowDialog();
                    nfCard.Close();
                    StartBtn.Enabled = true;
                    readCodeOnly.Enabled = true;
                    return;
                }

                nfCard.Close();
                progressBar.Value = 100;
                authCode_lbl.Text = translations.getText("authCode") + ": " + newAuthStr.Substring(0, 4) + " - " + newAuthStr.Substring(4, 3) + " - " + newAuthStr.Substring(7, 5);
                cardIdCode.Text = translations.getText("cardId") + ": " + AddSpaces(Convert.ToInt64(cardUID, 16).ToString(), 3);
                base.Refresh();
                currentUID = Convert.ToInt64(cardUID, 16).ToString();
                currentCode = newAuthStr;
                currentPin = currentCode.Substring(0, 4);
                var sendData = new Dictionary<string, string>();
                sendData.Add("CardId", AddSpaces(currentUID, 3));
                sendData.Add("authString", currentCode.Substring(0, 4) + " - " + currentCode.Substring(4, 3) + " - " + currentCode.Substring(7, 5));
                getSmartCardDetails?.Invoke(this, sendData);
            }
            else
            {
                cardIdCode.Text = translations.getText("cardId") + ": - -";
                authCode_lbl.Text = translations.getText("authCode") + ": - -";
                base.Refresh();
                var sendData = new Dictionary<string, string>();
                sendData.Add("CardId", "");
                sendData.Add("authString", "");
                getSmartCardDetails?.Invoke(this, sendData);
                currentUID = "";
                currentCode = "";
                currentPin = "";
            }

            StartBtn.Enabled = true;
            readCodeOnly.Enabled = true;
        }

        private void readCodeOnly_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nfCard = new smartCard();
            if (!nfCard.SelectDevice())
            {
                return;
            }
            else
            {
                nfCard.establishContext();
            }

            if (nfCard.connectCard())
            {
                progressBar.Value = 0;
                if (!nfCard.readCardUID())
                {
                    progressBar.Value = 0;
                    StartBtn.Enabled = true;
                    readCodeOnly.Enabled = true;
                    mainForm.statusMessage = "erro ao ler ID cartao";
                    return;
                }
                else if (nfCard.getCardUIDString().Equals(""))
                {
                    progressBar.Value = 0;
                    StartBtn.Enabled = true;
                    readCodeOnly.Enabled = true;
                    mainForm.statusMessage = "erro ao ler ID vazio";
                    return;
                }

                string cardUID = nfCard.getCardUIDString();
                progressBar.Value = 50;
                if (!nfCard.readStringOnCard(12, 5))
                {
                    progressBar.Value = 0;
                    nfCard.Close();
                    return;
                }

                string cardAuth = nfCard.getReadedString();
                progressBar.Value = 100;
                nfCard.Close();
                currentUID = Convert.ToInt64(cardUID, 16).ToString();
                currentCode = cardAuth;
                authCode_lbl.Text = translations.getText("authCode") + ": " + cardAuth.Substring(0, 4) + " - " + cardAuth.Substring(4, 3) + " - " + cardAuth.Substring(7, 5);
                cardIdCode.Text = translations.getText("cardId") + ": " + AddSpaces(Convert.ToInt64(cardUID, 16).ToString(), 3);
                base.Refresh();
            }
            else
            {
                cardIdCode.Text = translations.getText("cardId") + ": - -";
                authCode_lbl.Text = translations.getText("authCode") + ": - -";
                base.Refresh();
                currentUID = "";
                currentCode = "";
            }
        }
    }
}