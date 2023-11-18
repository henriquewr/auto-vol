using Microsoft.Win32;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Text;
using Auto_VOL.Helpers;
using System.Security.Principal;

namespace Auto_VOL
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cancellationTokenSource;
        private CancellationToken cancellationToken;
        private readonly VolumeHelper _volumeHelper;
        private readonly ProcessHelper _processHelper;

        private bool isOn;

        private const string APP_NAME = "Auto_VOL";
        private const string DEFAULT_PROCESS_NAME = "notepad";
        private const int DEFAULT_VOL_ON_OPEN = 6;
        private const int DEFAULT_VOL_ON_CLOSE = 2;

        public Form1()
        {
            InitializeComponent();
           
            _volumeHelper = new VolumeHelper();
            _processHelper = new ProcessHelper();

            UpdateToken();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string processName = Properties.Settings.Default.processName;
            tb_processName.Text = processName;

            int volOnOpen = Properties.Settings.Default.volOnOpen;
            tb_onOpenVol.Text = volOnOpen.ToString();

            int volOnClose = Properties.Settings.Default.volOnClose;
            tb_onCloseVol.Text = volOnClose.ToString();

            isOn = Properties.Settings.Default.isOn;

            VolumeAndProcess volProc = new VolumeAndProcess
            {
                VolOnClose = volOnClose,
                VolOnOpen = volOnOpen,
                ProcessName = processName
            };

            ChangeState(isOn, volProc);

            ContextMenu contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem("Exit", ExitApp_Click));
            notifyIcon1.ContextMenu = contextMenu;
        }

        private void btn_changeOnOff_Click(object sender, EventArgs e)
        {
            if (isOn != true)
            {
                string message = string.Empty;

                string processName = tb_processName.Text;
                if (string.IsNullOrEmpty(processName))
                {
                    message += "The process name cannot be null\n";
                }

                string volOnCloseStr = tb_onCloseVol.Text;
                int? volOnClose = volOnCloseStr.ToSafeZeroToHundredInt();
                if (!volOnClose.HasValue)
                {
                    message += $"Volume on close: {volOnCloseStr} is not a valid number\n";
                }

                string volOnOpenStr = tb_onOpenVol.Text;
                int? volOnOpen = volOnOpenStr.ToSafeZeroToHundredInt();
                if (!volOnOpen.HasValue)
                {
                    message += $"Volume on open: {volOnOpenStr} is not a valid number\n";
                }

                if(message != string.Empty)
                {
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                VolumeAndProcess volAnProc = new VolumeAndProcess
                {
                    VolOnClose = volOnClose.Value,
                    VolOnOpen = volOnOpen.Value,
                    ProcessName = processName
                };
                tb_onOpenVol.Text = volAnProc.VolOnOpen.ToString();
                tb_onCloseVol.Text = volAnProc.VolOnClose.ToString();

                SaveSettings(volAnProc);
                UpdateVolProcess(volAnProc);

                btn_changeOnOff.Text = "Stop";
                isOn = true;
            }
            else
            {
                cancellationTokenSource.Cancel();
                btn_changeOnOff.Text = "Start";
                isOn = false;
            }

            Properties.Settings.Default.isOn = isOn;
            Properties.Settings.Default.Save();
        }

        private void SaveSettings(VolumeAndProcess volAndProc)
        {
            Properties.Settings.Default.volOnOpen = volAndProc.VolOnOpen;
            Properties.Settings.Default.volOnClose = volAndProc.VolOnClose;
            Properties.Settings.Default.processName = volAndProc.ProcessName;

            Properties.Settings.Default.Save();
        }

        private void UpdateToken()
        {
            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;
        }

        private void btn_exitApp_Click(object sender, EventArgs e)
        {
            ExitApp();
        }

        private void ExitApp_Click(object sender, EventArgs e)
        {
            ExitApp();
        }

        private void ExitApp()
        {
            notifyIcon1.Dispose();
            Application.Exit();
        }

        private void ChangeState(bool isOn, VolumeAndProcess volAndProc = null)
        {
            this.isOn = isOn;

            if (isOn)
            {
                if (volAndProc == null)
                {
                    throw new ArgumentNullException(nameof(volAndProc));
                }
                btn_changeOnOff.Text = "Stop";
                UpdateVolProcess(volAndProc);
            }
            else
            {
                cancellationTokenSource.Cancel();
                UpdateToken();
                btn_changeOnOff.Text = "Start";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.BalloonTipText = "Application minimized";
                notifyIcon1.BalloonTipTitle = APP_NAME;
                notifyIcon1.ShowBalloonTip(2);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void UpdateVolProcess(VolumeAndProcess volumeAndProcess)
        {
            cancellationTokenSource.Cancel();
            UpdateToken();
            _processHelper.WhenProcessStartOrCloses(_volumeHelper.SetVolume, volumeAndProcess.VolOnOpen, _volumeHelper.SetVolume, volumeAndProcess.VolOnClose, volumeAndProcess.ProcessName, cancellationToken);
        }

        private void btn_defaultSettings_Click(object sender, EventArgs e)
        {
            ChangeState(false);
            Properties.Settings.Default.isOn = false;
            Properties.Settings.Default.processName = DEFAULT_PROCESS_NAME;
            Properties.Settings.Default.volOnClose = DEFAULT_VOL_ON_CLOSE;
            Properties.Settings.Default.volOnOpen = DEFAULT_VOL_ON_OPEN;

            tb_onCloseVol.Text = DEFAULT_VOL_ON_CLOSE.ToString();
            tb_onOpenVol.Text = DEFAULT_VOL_ON_OPEN.ToString();
            tb_processName.Text = DEFAULT_PROCESS_NAME;

            Properties.Settings.Default.Save();
        }

        private void ChangeStartWithSO(bool enable)
        {
            try
            {
                string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                RegistryKey startupKey = Registry.LocalMachine.OpenSubKey(runKey, true);
                bool hasStartupKey = startupKey.GetValue(APP_NAME) != null;

                if (enable)
                {
                    if (!hasStartupKey)
                    {
                        startupKey.SetValue(APP_NAME, @"""" + Application.ExecutablePath.ToString() + @"""");
                        startupKey.Close();
                    }

                    MessageBox.Show("The program will starts with the SO", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (hasStartupKey)
                    {
                        startupKey.DeleteValue(APP_NAME, false);
                        startupKey.Close();
                    }

                    MessageBox.Show("The program will not starts with the SO", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Try to run as administrator!\n\n" + ex.Message);
            }
        }

        private bool? WillStartWithOS()
        {
            try
            {
                RegistryKey startupKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                bool hasStartupKey = startupKey.GetValue(APP_NAME) != null;
                return hasStartupKey;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void btn_startWithOS_Click(object sender, EventArgs e)
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (isAdmin == false)
            {
                MessageBox.Show("You need to run as administrator to use this function!");
                return;
            }

            bool startWithOS = WillStartWithOS().Value;
            ChangeStartWithSO(!startWithOS);
        }
    }
}
