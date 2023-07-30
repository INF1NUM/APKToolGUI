using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace APKToolGUI.Controls
{
    internal class DarkTheme
    {
        public static Color bgColor = Color.FromArgb(32, 32, 32);
        public static Color txtBoxColor = Color.FromArgb(64, 64, 64);
        public static Color btnColor = Color.FromArgb(51, 51, 51);
        public static Color btnBorderColor = Color.FromArgb(155, 155, 155);
        public static Color tabBorderColor = Color.FromArgb(45, 45, 45);
        public static Color menuItemHoverColor = Color.FromArgb(51, 51, 51);
        public static Color menuItemSelectedColor = Color.FromArgb(41, 41, 41);
        public static Color separatorColor = Color.FromArgb(62, 62, 62);

        public static void SetTheme(Control.ControlCollection container, Form form)
        {
            form.BackColor = bgColor;
            form.ForeColor = Color.White;
            foreach (Control component in container)
            {
                Debug.WriteLine(component.GetType());
                component.BackColor = bgColor;
                component.ForeColor = Color.White;

                SetThemeTabControl(component, container);
            }
        }

        public static void SetThemeTabControl(Control component, Control.ControlCollection container)
        {
            if (component is TabControl)
            {
                ((TabControl)component).DrawMode = TabDrawMode.OwnerDrawFixed;

                foreach (Control tabControl in component.Controls)
                {
                    SetThemeTabControl(tabControl, container);

                    //Debug.WriteLine("tabPage " + tabControl.GetType());

                    ((TabControl)component).DrawItem += (sender, e) =>
                    {
                        // Set Border header  
                        e.Graphics.FillRectangle(new SolidBrush(tabBorderColor), e.Bounds);
                        Rectangle paddedBounds = e.Bounds;

                        paddedBounds.Inflate(0, 0);

                        // Set the rectangle for the tab button
                        Rectangle tabRect = ((TabControl)component).GetTabRect(e.Index);

                        // Draw the border color
                        using (Pen borderPen = new Pen(tabBorderColor, 7))
                        {
                            e.Graphics.DrawRectangle(borderPen, tabRect);
                        }

                        StringFormat stringFlags = new StringFormat();
                        stringFlags.Alignment = StringAlignment.Center;
                        stringFlags.LineAlignment = StringAlignment.Center;

                        e.Graphics.DrawString(((TabControl)component).TabPages[e.Index].Text, FormMain.Instance.Font, SystemBrushes.HighlightText, tabRect, stringFlags);

                        //set Tabcontrol border 
                        Graphics g = e.Graphics;
                        Pen p = new Pen(tabBorderColor, 8);
                        g.DrawRectangle(p, tabControl.Bounds.X, tabControl.Bounds.Y, tabControl.Bounds.Width, tabControl.Bounds.Height);

                        SolidBrush fillbrush = new SolidBrush(bgColor);

                        //draw rectangle behind the tabs
                        Rectangle lasttabrect = ((TabControl)component).GetTabRect(((TabControl)component).TabPages.Count - 1);
                        Rectangle background = new Rectangle();
                        background.Location = new Point(lasttabrect.Right, 0);

                        //pad the rectangle to cover the 1 pixel line between the top of the tabpage and the start of the tabs
                        background.Size = new Size(((TabControl)component).Right - background.Left, lasttabrect.Height + 1);
                        e.Graphics.FillRectangle(fillbrush, background);
                    };

                    foreach (Control tabPage in tabControl.Controls)
                    {
                        SetThemeTabControl(tabPage, container);
                    }
                }
            }
            else if (component is Panel)
            {
                foreach (Control control in component.Controls)
                {
                    SetThemeTabControl(control, container);
                }
                component.BackColor = bgColor;
                component.ForeColor = Color.White;
            }
            if (component is MenuStrip menuStrip)
            {
                ((MenuStrip)component).Renderer = new ToolStripProfessionalRenderer(new MenuItemColorTable());

                foreach (ToolStripItem item in menuStrip.Items)
                {
                    if (item is ToolStripMenuItem toolStripMenuItem)
                    {
                        foreach (ToolStripMenuItem dditem in toolStripMenuItem.DropDownItems.OfType<ToolStripMenuItem>())
                        {
                            dditem.BackColor = bgColor;
                            dditem.ForeColor = Color.White;
                            //Debug.WriteLine(dditem.Text);
                        }
                        foreach (ToolStripSeparator toolStripSeparator in toolStripMenuItem.DropDownItems.OfType<ToolStripSeparator>())
                        {
                            toolStripSeparator.BackColor = Color.Blue;
                            toolStripSeparator.ForeColor = Color.Blue;
                            Debug.WriteLine(toolStripSeparator.Name);
                        }

                        toolStripMenuItem.BackColor = bgColor;
                        toolStripMenuItem.ForeColor = Color.White;
                    }
                }
            }
            else if (component is GroupBox)
            {
                foreach (Control control in component.Controls)
                {
                    SetThemeTabControl(control, container);
                }
                component.BackColor = bgColor;
                component.ForeColor = Color.White;
            }
            else if (component is ComboBox)
            {
                component.BackColor = bgColor;
                component.ForeColor = Color.White;
                ((ComboBox)component).FlatStyle = FlatStyle.Flat;
            }
            else if (component is Button)
            {
                component.BackColor = btnColor;
                component.ForeColor = Color.White;
                ((Button)component).FlatStyle = FlatStyle.Flat;
                ((Button)component).FlatAppearance.BorderColor = btnBorderColor;

            }
            else if (component is TextBox)
            {
                component.BackColor = txtBoxColor;
                component.ForeColor = Color.White;
                ((TextBox)component).BorderStyle = BorderStyle.FixedSingle;
            }
            else if (component is RichTextBox)
            {
                if (component.Name == "logTxtBox")
                    ((RichTextBox)component).BorderStyle = BorderStyle.None;
                component.BackColor = bgColor;
                component.ForeColor = Color.White;
            }
            else
            {
                component.BackColor = bgColor;
                component.ForeColor = Color.White;
            }
        }

        public class MenuItemColorTable : ProfessionalColorTable
        {
            /// <summary>
            /// Gets the starting color of the gradient used when 
            /// a top-level System.Windows.Forms.ToolStripMenuItem is pressed.
            /// </summary>
            public override Color MenuItemPressedGradientBegin => menuItemSelectedColor;

            /// <summary>
            /// Gets the end color of the gradient used when a top-level 
            /// System.Windows.Forms.ToolStripMenuItem is pressed.
            /// </summary>
            public override Color MenuItemPressedGradientEnd => menuItemSelectedColor;

            /// <summary>
            /// Gets the border color to use with a 
            /// System.Windows.Forms.ToolStripMenuItem.
            /// </summary>
            public override Color MenuItemBorder => menuItemSelectedColor;

            /// <summary>
            /// Gets the starting color of the gradient used when the 
            /// System.Windows.Forms.ToolStripMenuItem is selected.
            /// </summary>
            public override Color MenuItemSelectedGradientBegin => menuItemSelectedColor;

            /// <summary>
            /// Gets the end color of the gradient used when the 
            /// System.Windows.Forms.ToolStripMenuItem is selected.
            /// </summary>
            public override Color MenuItemSelectedGradientEnd => menuItemSelectedColor;

            /// <summary>
            /// Gets the border color to use with a 
            /// System.Windows.Forms.ToolStripMenuItem.
            /// </summary>
            public override Color MenuItemSelected => menuItemHoverColor;

            /// <summary>
            /// Gets the solid background color of the 
            /// System.Windows.Forms.ToolStripDropDown.
            /// </summary>
            public override Color ToolStripDropDownBackground => bgColor;

            /// <summary>
            /// Gets the starting color of the gradient used in the image 
            /// margin of a System.Windows.Forms.ToolStripDropDownMenu.
            /// </summary>
            public override Color ImageMarginGradientBegin => bgColor;

            /// <summary>
            /// Gets the middle color of the gradient used in the image 
            /// margin of a System.Windows.Forms.ToolStripDropDownMenu.
            /// </summary>
            public override Color ImageMarginGradientMiddle => bgColor;

            /// <summary>
            /// Gets the end color of the gradient used in the image 
            /// margin of a System.Windows.Forms.ToolStripDropDownMenu.
            /// </summary>
            public override Color ImageMarginGradientEnd => bgColor;

            /// <summary>
            /// Gets the color to use to for shadow effects on 
            /// the System.Windows.Forms.ToolStripSeparator.
            /// </summary>
            public override Color SeparatorDark => separatorColor;

            /// <summary>
            /// Gets the color that is the border color to use 
            /// on a System.Windows.Forms.MenuStrip.
            /// </summary>
            public override Color MenuBorder => menuItemHoverColor;
        }
    }
}
