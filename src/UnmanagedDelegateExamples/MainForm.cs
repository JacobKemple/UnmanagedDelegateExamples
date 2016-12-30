using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace UnmanagedDelegateExamples {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void buttonGetLocationA_Click(object sender, EventArgs e) {
            var location = Engine.GetLocationA(new IntPtr(123));
            textBoxLocationA.Text = $@"{location.X} - {location.Y} - {location.Z}";
        }

        private void buttonGetLocationB_Click(object sender, EventArgs e) {
            var location = Engine.GetLocationB(new IntPtr(123));
            textBoxLocationB.Text = $@"{location.X} - {location.Y} - {location.Z}";
        }

        private void buttonIsValidA_Click(object sender, EventArgs e) {
            var isValid = Engine.IsEntityValid_A(new IntPtr(123));
            textBoxIsValidA.Text = isValid.ToString();
        }

        private void buttonIsValidB_Click(object sender, EventArgs e) {
            var isValid = Engine.IsEntityValid_B(new IntPtr(123));
            textBoxIsValidB.Text = isValid.ToString();
        }

        private void buttonInitialize_Click(object sender, EventArgs e) {
            var handle = Process.GetProcessesByName("proc").FirstOrDefault().MainWindowHandle;
            var funcPtrGetLocation = new IntPtr(123);
            var funcPtrIsEntityValid = new IntPtr(123);
            Engine.Initialize(handle, funcPtrGetLocation, funcPtrIsEntityValid);
        }

        private void buttonStartUp_Click(object sender, EventArgs e) {
            Engine.Apply();
        }

        private void buttonShutDown_Click(object sender, EventArgs e) {
            Engine.Remove();
        }
    }
}