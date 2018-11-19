using app_HogBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_HogBank.Forms
{
    class WindowManager
    {
        //=======================================================
        //  Window Dragging 
        //=======================================================
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public static void fireMouseDownEvent(IntPtr handle, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        //=======================================================
        //  Window State Handling
        //=======================================================
        public static void handleWindowMaximization(Form f)
        {
            if (f.WindowState != FormWindowState.Maximized)
                f.WindowState = FormWindowState.Maximized;
            else
                f.WindowState = FormWindowState.Normal;
        }

        public static void handleWindowMinimization(Form f)
        {
            f.WindowState = FormWindowState.Minimized;
        }

        //=======================================================
        //  Form Navigation
        //=======================================================
        public static void navigateToForm(Form src, Type srcType, object dest, Type destType)
        {
            // Warning -- dynamic means that the compiler does not check that it actually is the type we say it is.
            // Undefined behavior can occur if the supplied types are incorrect.
            dynamic srcForm = Convert.ChangeType(src, srcType);
            dynamic destForm = Convert.ChangeType(dest, destType);

            destForm.Show();
            srcForm.Close();
        }

        public static void navigateToForm(Form src, Type srcType, Type destType)
        {
            dynamic srcForm = Convert.ChangeType(src, srcType);
            dynamic destForm = Convert.ChangeType(Activator.CreateInstance(destType), destType);

            // Transfer main login instance object
            destForm.Tag = srcForm.Tag;

            destForm.Show(srcForm);
            srcForm.Hide();
        }

        public static void navigateToFormStartTag(Form src, Type srcType, Type destType, Object valueObject)
        {
            dynamic srcForm = Convert.ChangeType(src, srcType);
            dynamic destForm = Convert.ChangeType(Activator.CreateInstance(destType), destType);

            // Transfer main login instance information
            destForm.Tag = valueObject;

            destForm.Show(srcForm);
            srcForm.Hide();
        }

        public static Type getTagType(Object tag)
        {
            if(tag is CustomerVO)
            {
                return typeof(CustomerVO);
            }
            else if(tag is EmployeeVO)
            {
                return typeof(EmployeeVO);
            }
            else
            {
                return null;
            }
        }
    }
}
