using Hardware.Info;
using LibreHardwareMonitor.Hardware;
using System;
using System.Windows.Forms;
using System.Linq;
namespace infoware
{
    public partial class Form1 : Form
    {
        static IHardwareInfo hardwareInfo;
        private Computer computer;
        private System.Windows.Forms.Timer updateTimer;


        public Form1()
        {
            InitializeComponent();

            try
            {
                hardwareInfo = new HardwareInfo();
                hardwareInfo.RefreshAll();
            }
            catch (Exception ex)
            {
                oslabel.Text = ex.Message;
            }

        

            

            // OS information
            oslabel.Text = hardwareInfo.OperatingSystem.Name;

            // CPU information
            foreach (var cpu in hardwareInfo.CpuList)
            {
                cpulabel.Text = cpulabel.Text + cpu.Name;
                // CPU Core
                foreach (var cpuCore in cpu.CpuCoreList)
                {
                    CpuCoreLabel.Text = CpuCoreLabel.Text + cpuCore.Name;
                }
            }

            // GPU information
            foreach (var hardware in hardwareInfo.VideoControllerList)
            {
                gpulabel.Text = gpulabel.Text + Environment.NewLine + hardware.Name;
            }

            // Battery information
            foreach (var hardware in hardwareInfo.BatteryList)
            {
                BatteryLabel.Text = BatteryLabel.Text + Environment.NewLine + hardware.ToString();
            }

            // BIOS information
            foreach (var hardware in hardwareInfo.BiosList)
            {
                bioslabel.Text = hardware.ToString();
            }

            // Motherboard information
            foreach (var hardware in hardwareInfo.MotherboardList)
            {
                motherboardlabel.Text = hardware.ToString();
            }

            // Sound devices information
            foreach (var hardware in hardwareInfo.SoundDeviceList)
            {
                soundlabel.Text = soundlabel.Text + Environment.NewLine + hardware.ToString();
            }

            // Memory information
            foreach (var hardware in hardwareInfo.MemoryList)
            {
                memorylabel.Text = memorylabel.Text + Environment.NewLine + hardware.ToString();
            }

            // Drive information
            foreach (var drive in hardwareInfo.DriveList)
            {
                Drivelabel.Text = Drivelabel.Text + Environment.NewLine + drive.ToString();
                // Drive partition
                foreach (var partition in drive.PartitionList)
                {
                    drivepartitionlabel.Text = drivepartitionlabel.Text + Environment.NewLine + partition.ToString();
                    // Drive volume
                    foreach (var volume in partition.VolumeList)
                    {
                        drivevolumelabel.Text = drivevolumelabel.Text + Environment.NewLine + volume.ToString();
                    }
                }
            }
    
        }

     
    }
}