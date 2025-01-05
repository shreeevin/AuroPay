using AuroPay.Helpers;
using System.ComponentModel;

namespace AuroPay.Components
{
    public class RoundedTextBox : TextBox
    {
        private int _cornerRadius = 10;
        private int _textPadding = 5;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; this.Invalidate(); }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int TextPadding
        {
            get { return _textPadding; }
            set { _textPadding = value; this.Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            LayoutHelper.ApplyRoundedCornersAndBackground(e, this, _cornerRadius, this.BackColor);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~0x200000; 
                return cp;
            }
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            this.Padding = new Padding(_textPadding); 
        }

        public RoundedTextBox()
        {
            this.BorderStyle = BorderStyle.Fixed3D; 
        }
    }
}
