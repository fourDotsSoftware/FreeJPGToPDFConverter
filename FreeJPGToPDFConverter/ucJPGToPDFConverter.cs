using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;

namespace FreeJPGToPDFConverter
{
    public partial class ucJPGToPDFConverter : UserControl
    {
        public ucJPGToPDFConverter()
        {
            InitializeComponent();

            cmbDocumentSize.Items.Add(TranslateHelper.Translate("Original Size"));
            cmbDocumentSize.Items.Add(TranslateHelper.Translate("A4"));
            cmbDocumentSize.Items.Add(TranslateHelper.Translate("US Letter"));

            cmbOrientation.Items.Add(TranslateHelper.Translate("Portrait"));
            cmbOrientation.Items.Add(TranslateHelper.Translate("Landscape"));
            cmbOrientation.Items.Add(TranslateHelper.Translate("Auto"));

            cmbMargin.Items.Add(TranslateHelper.Translate("Small Margin"));
            cmbMargin.Items.Add(TranslateHelper.Translate("Big Margin"));
            cmbMargin.Items.Add(TranslateHelper.Translate("No Margin"));

            cmbImageAlignment.Items.Add(TranslateHelper.Translate("Middle Center"));
            cmbImageAlignment.Items.Add(TranslateHelper.Translate("Top Center"));
            cmbImageAlignment.Items.Add(TranslateHelper.Translate("Bottom Center"));
            cmbImageAlignment.Items.Add(TranslateHelper.Translate("Middle Left"));
            cmbImageAlignment.Items.Add(TranslateHelper.Translate("Top Left"));
            cmbImageAlignment.Items.Add(TranslateHelper.Translate("Bottom Left"));
            cmbImageAlignment.Items.Add(TranslateHelper.Translate("Middle Right"));
            cmbImageAlignment.Items.Add(TranslateHelper.Translate("Top Right"));
            cmbImageAlignment.Items.Add(TranslateHelper.Translate("Bottom Right"));

            cmbDocumentSize.SelectedIndex = 0;
            cmbImageAlignment.SelectedIndex = 0;
            cmbMargin.SelectedIndex = 0;
            cmbOrientation.SelectedIndex = 0;

        }
    }
}
