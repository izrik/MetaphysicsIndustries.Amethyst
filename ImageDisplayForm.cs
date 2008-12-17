using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MetaphysicsIndustries.Solus;

namespace MetaphysicsIndustries.Epiphany.Amethyst
{
    public partial class ImageDisplayForm : Form
    {
        public ImageDisplayForm()
        {
            InitializeComponent();
        }

        private bool _stretch;
        public bool Stretch
        {
            get { return _stretch; }
            set
            {
                _stretch = value;
                _displayPanel.Invalidate();
            }
        }

        private Bitmap _image;
        public Bitmap Image
        {
            get { return _image; }
            set
            {
                _image = value;
                _displayPanel.Invalidate();
            }
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stretch = false;
        }

        private void stretchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stretch = true;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            normalToolStripMenuItem.Checked = !Stretch;
            stretchToolStripMenuItem.Checked = Stretch;
        }

        private void _displayPanel_Paint(object sender, PaintEventArgs e)
        {
            if (Stretch)
            {
                e.Graphics.DrawImage(Image, ClientRectangle);
            }
            else
            {
                e.Graphics.DrawImage(Image, 0, 0);
            }
        }

        private void _displayPanel_ClientSizeChanged(object sender, EventArgs e)
        {
            _displayPanel.Invalidate();
        }

        protected static SolusEngine _engine = new SolusEngine();

        private void saveImageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Bitmap Images (*.bmp)|*.bmp|All Files (*.*)|*.*";

            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
                Image.Save(sfd.FileName);
            }
        }

        private static Dictionary<Bitmap, ImageDisplayForm> _forms = new Dictionary<Bitmap, ImageDisplayForm>();
        public static void OpenDisplay(Bitmap bitmap, AmethystControl control)
        {
            ImageDisplayForm form;

            if (bitmap != null)
            {
                if (_forms.ContainsKey(bitmap))
                {
                    form = _forms[bitmap];
                }
                else
                {
                    form = new ImageDisplayForm();
                    form.Image = bitmap;
                    _forms[bitmap] = form;
                    form.Show(control);
                }

                form.BringToFront();
            }
        }

        protected static void RemoveFromFormList(Bitmap bitmap)
        {
            ImageDisplayForm form;

            if (bitmap != null)
            {
                if (_forms.ContainsKey(bitmap))
                {
                    form = _forms[bitmap];
                    _forms.Remove(bitmap);
                    form.Close();
                }
            }
        }

        private void ImageDisplayForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RemoveFromFormList(Image);
        }
    }
}