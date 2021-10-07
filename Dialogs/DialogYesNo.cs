using MatchTemplateOpenCV.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchTemplateOpenCV.Dialogs
{
    public partial class DialogYesNo : Form
    {
        #region MainProgram

        public DialogYesNo()
        {
            InitializeComponent();
        }

        public DialogYesNo(string caption, string message)
        {
            InitializeComponent();
            lbCaption.Text = caption;
            lbInformation.Text = message;
        }

        #endregion

        #region Button Events
        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }

        private void panelCaption_MouseDown(object sender, MouseEventArgs e)
        {
            MyLib.DragWindow(this.Handle);
        }
        #endregion

        #region Hot Keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Enter
            if (keyData == (Keys.Control | Keys.Enter))
            {
                btnOK.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion end_hot_keys
    }
}
