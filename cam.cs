using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using centrafuse.Plugins;
using System.Runtime.InteropServices;
using System.Xml;
using System.Collections;
using System.Text;
using centrafuse.Plugins.DirectShowLib;

namespace cam
{
    public class WMData
    {
        // Declarations Windows Media Profiles
        // 20 version 4.0 formats (not used anymore???)
        public static readonly Guid WMProfile_V40_DialUpMBR = new Guid("fd7f47f1-72a6-45a4-80f0-3aecefc32c07");
        public static readonly Guid WMProfile_V40_IntranetMBR = new Guid("82cd3321-a94a-4ffc-9c2b-092c10ca16e7");
        public static readonly Guid WMProfile_V40_2856100MBR = new Guid("5a1c2206-dc5e-4186-beb2-4c5a994b132e");
        public static readonly Guid WMProfile_V40_6VoiceAudio = new Guid("D508978A-11A0-4d15-B0DA-ACDC99D4F890");
        public static readonly Guid WMProfile_V40_16AMRadio = new Guid("0f4be81f-d57d-41e1-b2e3-2fad986bfec2");
        public static readonly Guid WMProfile_V40_288FMRadioMono = new Guid("7fa57fc8-6ea4-4645-8abf-b6e5a8f814a1");
        public static readonly Guid WMProfile_V40_288FMRadioStereo = new Guid("22fcf466-aa40-431f-a289-06d0ea1a1e40");
        public static readonly Guid WMProfile_V40_56DialUpStereo = new Guid("e8026f87-e905-4594-a3c7-00d00041d1d9");
        public static readonly Guid WMProfile_V40_64Audio = new Guid("4820b3f7-cbec-41dc-9391-78598714c8e5");
        public static readonly Guid WMProfile_V40_96Audio = new Guid("0efa0ee3-9e64-41e2-837f-3c0038f327ba");
        public static readonly Guid WMProfile_V40_128Audio = new Guid("93ddbe12-13dc-4e32-a35e-40378e34279a");
        public static readonly Guid WMProfile_V40_288VideoVoice = new Guid("bb2bc274-0eb6-4da9-b550-ecf7f2b9948f");
        public static readonly Guid WMProfile_V40_288VideoAudio = new Guid("ac617f2d-6cbe-4e84-8e9a-ce151a12a354");
        public static readonly Guid WMProfile_V40_288VideoWebServer = new Guid("abf2f00d-d555-4815-94ce-8275f3a70bfe");
        public static readonly Guid WMProfile_V40_56DialUpVideo = new Guid("e21713bb-652f-4dab-99de-71e04400270f");
        public static readonly Guid WMProfile_V40_56DialUpVideoWebServer = new Guid("b756ff10-520f-4749-a399-b780e2fc9250");
        public static readonly Guid WMProfile_V40_100Video = new Guid("8f99ddd8-6684-456b-a0a3-33e1316895f0");
        public static readonly Guid WMProfile_V40_250Video = new Guid("541841c3-9339-4f7b-9a22-b11540894e42");
        public static readonly Guid WMProfile_V40_512Video = new Guid("70440e6d-c4ef-4f84-8cd0-d5c28686e784");
        public static readonly Guid WMProfile_V40_1MBVideo = new Guid("b4482a4c-cc17-4b07-a94e-9818d5e0f13f");
        public static readonly Guid WMProfile_V40_3MBVideo = new Guid("55374ac0-309b-4396-b88f-e6e292113f28");

        // 26 version 7.0 formats
        public static readonly Guid WMProfile_V70_DialUpMBR = new Guid("5B16E74B-4068-45b5-B80E-7BF8C80D2C2F");
        public static readonly Guid WMProfile_V70_IntranetMBR = new Guid("045880DC-34B6-4ca9-A326-73557ED143F3");
        public static readonly Guid WMProfile_V70_2856100MBR = new Guid("07DF7A25-3FE2-4a5b-8B1E-348B0721CA70");
        public static readonly Guid WMProfile_V70_288VideoVoice = new Guid("B952F38E-7DBC-4533-A9CA-B00B1C6E9800");
        public static readonly Guid WMProfile_V70_288VideoAudio = new Guid("58BBA0EE-896A-4948-9953-85B736F83947");
        public static readonly Guid WMProfile_V70_288VideoWebServer = new Guid("70A32E2B-E2DF-4ebd-9105-D9CA194A2D50");
        public static readonly Guid WMProfile_V70_56VideoWebServer = new Guid("DEF99E40-57BC-4ab3-B2D1-B6E3CAF64257");
        public static readonly Guid WMProfile_V70_64VideoISDN = new Guid("C2B7A7E9-7B8E-4992-A1A1-068217A3B311");
        public static readonly Guid WMProfile_V70_100Video = new Guid("D9F3C932-5EA9-4c6d-89B4-2686E515426E");
        public static readonly Guid WMProfile_V70_256Video = new Guid("AFE69B3A-403F-4a1b-8007-0E21CFB3DF84");
        public static readonly Guid WMProfile_V70_384Video = new Guid("F3D45FBB-8782-44df-97C6-8678E2F9B13D");
        public static readonly Guid WMProfile_V70_768Video = new Guid("0326EBB6-F76E-4964-B0DB-E729978D35EE");
        public static readonly Guid WMProfile_V70_1500Video = new Guid("0B89164A-5490-4686-9E37-5A80884E5146");
        public static readonly Guid WMProfile_V70_2000Video = new Guid("AA980124-BF10-4e4f-9AFD-4329A7395CFF");
        public static readonly Guid WMProfile_V70_700FilmContentVideo = new Guid("7A747920-2449-4d76-99CB-FDB0C90484D4");
        public static readonly Guid WMProfile_V70_1500FilmContentVideo = new Guid("F6A5F6DF-EE3F-434c-A433-523CE55F516B");
        public static readonly Guid WMProfile_V70_6VoiceAudio = new Guid("EABA9FBF-B64F-49b3-AA0C-73FBDD150AD0");
        public static readonly Guid WMProfile_V70_288FMRadioMono = new Guid("C012A833-A03B-44a5-96DC-ED95CC65582D");
        public static readonly Guid WMProfile_V70_288FMRadioStereo = new Guid("E96D67C9-1A39-4dc4-B900-B1184DC83620");
        public static readonly Guid WMProfile_V70_56DialUpStereo = new Guid("674EE767-0949-4fac-875E-F4C9C292013B");
        public static readonly Guid WMProfile_V70_64AudioISDN = new Guid("91DEA458-9D60-4212-9C59-D40919C939E4");
        public static readonly Guid WMProfile_V70_64Audio = new Guid("B29CFFC6-F131-41db-B5E8-99D8B0B945F4");
        public static readonly Guid WMProfile_V70_96Audio = new Guid("A9D4B819-16CC-4a59-9F37-693DBB0302D6");
        public static readonly Guid WMProfile_V70_128Audio = new Guid("C64CF5DA-DF45-40d3-8027-DE698D68DC66");
        public static readonly Guid WMProfile_V70_225VideoPDA = new Guid("F55EA573-4C02-42b5-9026-A8260C438A9F");
        public static readonly Guid WMProfile_V70_150VideoPDA = new Guid("0F472967-E3C6-4797-9694-F0304C5E2F17");

        // 27 version 8.0 formats
        public static readonly Guid WMProfile_V80_255VideoPDA = new Guid("FEEDBCDF-3FAC-4c93-AC0D-47941EC72C0B");
        public static readonly Guid WMProfile_V80_150VideoPDA = new Guid("AEE16DFA-2C14-4a2f-AD3F-A3034031784F");
        public static readonly Guid WMProfile_V80_28856VideoMBR = new Guid("D66920C4-C21F-4ec8-A0B4-95CF2BD57FC4");
        public static readonly Guid WMProfile_V80_100768VideoMBR = new Guid("5BDB5A0E-979E-47d3-9596-73B386392A55");
        public static readonly Guid WMProfile_V80_288100VideoMBR = new Guid("D8722C69-2419-4b36-B4E0-6E17B60564E5");
        public static readonly Guid WMProfile_V80_288Video = new Guid("3DF678D9-1352-4186-BBF8-74F0C19B6AE2");
        public static readonly Guid WMProfile_V80_56Video = new Guid("254E8A96-2612-405c-8039-F0BF725CED7D");
        public static readonly Guid WMProfile_V80_100Video = new Guid("A2E300B4-C2D4-4fc0-B5DD-ECBD948DC0DF");
        public static readonly Guid WMProfile_V80_256Video = new Guid("BBC75500-33D2-4466-B86B-122B201CC9AE");
        public static readonly Guid WMProfile_V80_384Video = new Guid("29B00C2B-09A9-48bd-AD09-CDAE117D1DA7");
        public static readonly Guid WMProfile_V80_768Video = new Guid("74D01102-E71A-4820-8F0D-13D2EC1E4872");
        public static readonly Guid WMProfile_V80_700NTSCVideo = new Guid("C8C2985F-E5D9-4538-9E23-9B21BF78F745");
        public static readonly Guid WMProfile_V80_1400NTSCVideo = new Guid("931D1BEE-617A-4bcd-9905-CCD0786683EE");
        public static readonly Guid WMProfile_V80_384PALVideo = new Guid("9227C692-AE62-4f72-A7EA-736062D0E21E");
        
        // Windows Media Video 8 for Broadband (PAL, 700 Kbps)
        public static readonly Guid WMProfile_V80_700PALVideo = new Guid("EC298949-639B-45e2-96FD-4AB32D5919C2");
        // Windows Media Audio 8 for Dial-up Modem (Mono, 28.8 Kbps)
        public static readonly Guid WMProfile_V80_288MonoAudio = new Guid("7EA3126D-E1BA-4716-89AF-F65CEE0C0C67");
        // Windows Media Audio 8 for Dial-up Modem (FM Radio Stereo, 28.8 Kbps)
        public static readonly Guid WMProfile_V80_288StereoAudio = new Guid("7E4CAB5C-35DC-45bb-A7C0-19B28070D0CC");
        // Windows Media Audio 8 for Dial-up Modem (32 Kbps)
        public static readonly Guid WMProfile_V80_32StereoAudio = new Guid("60907F9F-B352-47e5-B210-0EF1F47E9F9D");
        // Windows Media Audio 8 for Dial-up Modem (Near CD quality, 48 Kbps)
        public static readonly Guid WMProfile_V80_48StereoAudio = new Guid("5EE06BE5-492B-480a-8A8F-12F373ECF9D4");
        // Windows Media Audio 8 for Dial-up Modem (CD quality, 64 Kbps)
        public static readonly Guid WMProfile_V80_64StereoAudio = new Guid("09BB5BC4-3176-457f-8DD6-3CD919123E2D");
        // Windows Media Audio 8 for Dial-up Modem (CD quality, 64 Kbps)
        public static readonly Guid WMProfile_V80_96StereoAudio = new Guid("1FC81930-61F2-436f-9D33-349F2A1C0F10");
        // Windows Media Audio 8 for ISDN (Better than CD quality, 96 Kbps)
        public static readonly Guid WMProfile_V80_128StereoAudio = new Guid("407B9450-8BDC-4ee5-88B8-6F527BD941F2");
        public static readonly Guid WMProfile_V80_288VideoOnly = new Guid("8C45B4C7-4AEB-4f78-A5EC-88420B9DADEF");
        // Windows Media Video 8 for Dial-up Modem (No audio, 56 Kbps)
        public static readonly Guid WMProfile_V80_56VideoOnly = new Guid(0x6E2A6955, 0x81DF, 0x4943, 0xBA, 0x50, 0x68, 0xA9, 0x86, 0xA7, 0x08, 0xF6);
        public static readonly Guid WMProfile_V80_FAIRVBRVideo = new Guid("3510A862-5850-4886-835F-D78EC6A64042");
        public static readonly Guid WMProfile_V80_HIGHVBRVideo = new Guid("0F10D9D3-3B04-4fb0-A3D3-88D4AC854ACC");
        // Windows Media Video 8 for Broadband (PAL, 700 Kbps)
        public static readonly Guid WMProfile_V80_BESTVBRVideo = new Guid("048439BA-309C-440e-9CB4-3DCCA3756423");
        // End of declarations Windows Media profiles
    }

	public class cam : CFPlugin
    {

#region Variables

        private int currentcam = 0;
        private bool recording = false;
        private bool widescreen = false;
        private bool fliphorizontal = true;
        private int resx = 640;
        private int resy = 480;
        private bool initialized = false;

		private setup mysetup;
        private CFControls.CFPictureBox2 pbVideo;
		private bool firstrun = true;
		private bool isfullscreen = true;
        private bool firstActive = false;
        private string fileName = "";

        const int WM_GRAPHNOTIFY = 0x8000 + 1;

        private DsROTEntry rot = null;
        private IVideoWindow videoWindow = null;
        private IMediaControl mediaControl = null;
        private IMediaEventEx mediaEventEx = null;
        private IGraphBuilder graphBuilder = null;
        private ICaptureGraphBuilder2 captureGraphBuilder = null;

		private System.Windows.Forms.Timer saveTimer;
		private System.Windows.Forms.Timer diskspaceTimer;

        public string PluginLocation
        {
            get
            {
                return CFTools.StartupPath + Path.DirectorySeparatorChar + "Plugins" + Path.DirectorySeparatorChar + "Cam";
            }
        }

        public string PluginAppData
        {
            get
            {
                return CFTools.AppDataPath + Path.DirectorySeparatorChar + "Plugins" + Path.DirectorySeparatorChar + "Cam";
            }
        }

        public string PictureFolder
        {
            get
            {
                string picturepath = CFTools.SystemPicturePath;
                string[] picturepaths = this.CF_getConfigSetting(CF_ConfigSettings.PicturePath).Split('|');

                if (picturepaths.Length >= 1)
                    picturepath = picturepaths[0];

                return Path.Combine(picturepath, "CFCam");
            }
        }

        public string VideoFolder
        {
            get
            {
                string videopath = CFTools.SystemVideoPath;
                string[] videopaths = this.CF_getConfigSetting(CF_ConfigSettings.VideoPath).Split('|');

                if (videopaths.Length >= 1)
                    videopath = videopaths[0];

                return Path.Combine(videopath, "CFCam");
            }
        }

#endregion

#region CFPlugin

        public override void CF_sectionToggleFullScreen()
		{
			minmax();
		}

        public override void CF_pluginInit()
		{
            CFTools.writeLog("CAM", "CF_pluginInit", "");
			try
			{
                if (!Directory.Exists(PluginAppData))
                    Directory.CreateDirectory(PluginAppData);

                if (!Directory.Exists(PictureFolder))
                    Directory.CreateDirectory(PictureFolder);

                if (!Directory.Exists(VideoFolder))
                    Directory.CreateDirectory(VideoFolder);

                System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(cam));
				this.SuspendLayout();

                diskspaceTimer = new System.Windows.Forms.Timer();
				diskspaceTimer.Enabled = false;
				diskspaceTimer.Interval = 250;
				diskspaceTimer.Tick += new System.EventHandler(diskspaceTimer_Tick);

				saveTimer = new Timer();
				saveTimer.Interval = 1000;
				saveTimer.Enabled = false;
				saveTimer.Tick += new EventHandler(saveTimer_Tick);

                this.CF_params.supportsRearScreen = true;

                this.CF3_initPlugin("CAM", true);

                LoadSettings();

                this.CF_localskinsetup();

				this.VisibleChanged += new EventHandler(cam_VisibleChanged);
				this.CF_events.powerModeChanged += new Microsoft.Win32.PowerModeChangedEventHandler(cam_CF_Event_powerModeChanged);

				this.ResumeLayout(false);
			}
			catch(Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
		}

		
        public override void CF_localskinsetup()
		{
            CFTools.writeLog("CAM", "CF_localskinsetup", "");
			try
			{
                CF3_initSection("Cam");

                this.pbVideo = this.picturebox2Array[0];
                this.pbVideo.BackColor = Color.Black;

                updateTitle();
				ResizeVideoPanel();
			}
			catch(Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
		}


		public override void CF_pluginClose()
		{
            try
            {
                CloseInterfaces();
                this.Dispose();
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
		}

        public override bool CF_pluginCMLCommand(string command, string[] strparams, CF_ButtonState state, int zone)
        {
            try
            {
                command = command.ToLower().Replace("centrafuse.", "").Trim();

                switch (command)
                {
                    case "cam.toggledevice":
                        if (state == CF_ButtonState.Click)
                            this.toggledevices();
                        return true;
                    case "cam.record":
                        if (state == CF_ButtonState.Click)
                            this.record();
                        return true;
                    case "cam.save":
                        if (state == CF_ButtonState.Click)
                            this.save();
                        return true;
                    case "cam.minmax":
                        if (state == CF_ButtonState.Click)
                            this.minmax();
                        return true;
                    default:
                        return false;
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }

            return false;
        }

		
        public override DialogResult CF_pluginShowSetup()
		{
			/*
			 * Return DialogResult.OK for the main application
			 * to update from plugin changes.
			*/
			DialogResult returnvalue = DialogResult.Cancel;

			try
			{
				/*
				 * Creates a new plugin setup instance.
				*/
				mysetup = new setup(this.MainForm, this.pluginConfig, this.pluginLang);
				returnvalue = mysetup.ShowDialog();

                if (returnvalue == DialogResult.OK)
                {
                    if (recording)
                        stopCapture();

                    reloadSettings();
                }

				mysetup.Close();
				mysetup = null;
			}
			catch(Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }

			return returnvalue;
		}


        public override string CF_pluginDefaultConfig()
        {
            return "<APPCONFIG>\r\n" +
                    "    <SKIN>Clean</SKIN>\r\n" +
                    "    <APPLANG>English</APPLANG>\r\n" +
                    "    <STARTFULLSCREEN>False</STARTFULLSCREEN>\r\n" +
                    "    <VIDEODEVICE>-1</VIDEODEVICE>\r\n" +
                    "    <AUDIODEVICE>-1</AUDIODEVICE>\r\n" +
                    "    <VIDEOSOURCE>-1</VIDEOSOURCE>\r\n" +
                    "    <AUDIOSOURCE>-1</AUDIOSOURCE>\r\n" +
                    "    <TUNESOURCE>1</TUNESOURCE>\r\n" +
                    "    <FRAMERATE>15</FRAMERATE>\r\n" +
                    "    <DISPLAY>1</DISPLAY>\r\n" +
                    "    <WIDTH>160</WIDTH>\r\n" +
                    "    <HEIGHT>120</HEIGHT>\r\n" +
                    "</APPCONFIG>\r\n";
        }

#endregion

#region System Functions

		private void LoadSettings()
		{
            CFTools.writeLog("CAM", "LoadSettings", "");
            try
            {
                if (this.pluginConfig == null)
                    this.CF_loadConfig(Path.Combine(PluginAppData, "config.xml"));

                // The display name is shown in the application to represent the plugin.  This sets the display name from the configuration file.
                this.CF_params.displayName = this.pluginLang.ReadField("/APPLANG/CAM/DISPLAYNAME");
                this.CF_params.settingsDisplayDesc = this.pluginLang.ReadField("/APPLANG/CAM/DESCRIPTION");

                try { currentcam = Int32.Parse(this.pluginConfig.ReadField("/APPCONFIG/VIDEODEVICE")); }
                catch { currentcam = -1; }

                try
                {
                    widescreen = Boolean.Parse(this.pluginConfig.ReadField("/APPCONFIG/WIDESCREEN"));
                }
                catch
                {
                    this.pluginConfig.WriteField("/APPCONFIG/WIDESCREEN", "False");
                    this.pluginConfig.Save();
                    widescreen = false;
                }

                try
                {
                    fliphorizontal = Boolean.Parse(this.pluginConfig.ReadField("/APPCONFIG/FLIPSCREEN"));
                }
                catch
                {
                    this.pluginConfig.WriteField("/APPCONFIG/FLIPSCREEN", "True");
                    this.pluginConfig.Save();
                    fliphorizontal = true;
                }

                try
                {
                    resx = Int32.Parse(this.pluginConfig.ReadField("/APPCONFIG/RESX"));
                }
                catch
                {
                    this.pluginConfig.WriteField("/APPCONFIG/RESX", "640");
                    this.pluginConfig.Save();
                    resx = 640;
                }

                try
                {
                    resy = Int32.Parse(this.pluginConfig.ReadField("/APPCONFIG/RESY"));
                }
                catch
                {
                    this.pluginConfig.WriteField("/APPCONFIG/RESY", "640");
                    this.pluginConfig.Save();
                    resy = 640;
                }

                // This sets which monitor to display the plugin on.
                try { this.CF_displayHooks.displayNumber = Int32.Parse(this.pluginConfig.ReadField("/APPCONFIG/DISPLAY")); }
                catch { this.CF_displayHooks.displayNumber = 1; }

                //	Read start fullscreen.
                if (firstrun)
                {
                    try { isfullscreen = Convert.ToBoolean(this.pluginConfig.ReadField("/APPCONFIG/STARTFULLSCREEN")); }
                    catch { isfullscreen = true; }
                    this.CF_displayHooks.boundsAttributeId = (isfullscreen ? "fullbounds" : "bounds");
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }

			firstrun = false;
		}


        private void reloadSettings()
        {
            try
            {
                CloseInterfaces();
                LoadSettings();
                openPreviewWindow(false);
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


        private void minmax()
        {
            try
            {
                if (isfullscreen && CF_displayHooks.displayNumber > 1 && CF_displayHooks.displayNumber <= CFTools.AllScreens.Length && !this.CF_displayHooks.rearScreen)
                {
                    this.Visible = false;
                    return;
                }

                isfullscreen = !isfullscreen;
                this.CF_displayHooks.boundsAttributeId = (isfullscreen ? "fullbounds" : "bounds");

                CF_localskinsetup();

                if (recording)
                    this.CF_setButtonOn("RECORD");

                SetupVideoWindow();
                this.Invalidate();
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


        private void updateTitle()
        {
            try
            {
                string devicetext = this.pluginLang.ReadField("/APPLANG/SETUP/NONE");

                if (!recording)
                {
                    // Get all video input devices
                    DsDevice[] devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

                    if (currentcam >= 0 && currentcam < devices.Length && devices.Length > 0)
                    {
                        if (devices.Length > 1)
                            devicetext = (currentcam + 1) + "/" + devices.Length + " " + devices[currentcam].Name;
                        else
                            devicetext = devices[currentcam].Name;
                    }

                    if (isfullscreen || (Screen.AllScreens.Length >= CF_displayHooks.displayNumber && CF_displayHooks.displayNumber > 1))
                    {
                        isfullscreen = true;
                        this.CF_updateText("TITLE", devicetext);
                    }
                    else
                        this.CF_updateText("TITLE", devicetext);
                }
                else
                    CF_updateText("TITLE", this.pluginLang.ReadField("/APPLANG/SETUP/RECORDING"));
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }

#endregion

#region Events

        private void diskspaceTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (recording)
                {
                    System.Management.ManagementObject disk = new System.Management.ManagementObject("Win32_LogicalDisk.DeviceID=\"" + fileName.Substring(0, 1) + ":\"");
                    disk.Get();
                    double freespace = double.Parse(disk["FreeSpace"].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                    if (freespace < 209715200)
                        stopCapture();
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


        private void saveTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                saveTimer.Enabled = false;

                if (mediaControl != null)
                    mediaControl.Run();
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }

		private void toggledevices()
		{
            try
            {
                if (!initialized || currentcam == -1)
                    return;

                // Get all video input devices
                DsDevice[] devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

                if (devices.Length > 1)
                {
                    currentcam++;
                    if (currentcam >= devices.Length)
                        currentcam = 0;

                    if (!recording)
                    {
                        CloseInterfaces();
                        openPreviewWindow(false);
                    }
                    else
                        stopCapture();
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
		}

        private void cam_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                openPreviewWindow(false);
            else
                CloseInterfaces();
        }

        private void record()
        {
            try
            {
                if (!initialized || currentcam == -1)
                    return;
                if (!recording)
                    this.captureVideo();
                else
                    this.stopCapture();
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }

        private void save()
        {
            try
            {
                CF3_writePluginLog("saveClick");
                if (!initialized || currentcam == -1)
                    return;
                if (!recording)
                    capturePicture();
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }

        private void cam_CF_Event_powerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
        {
            if (e.Mode == Microsoft.Win32.PowerModes.Suspend)
            {
                if (recording)
                    stopCapture();

                CloseInterfaces();
            }
            else if (e.Mode == Microsoft.Win32.PowerModes.Resume)
            {
                LoadSettings();
                if (this.Visible)
                    openPreviewWindow(false);
            }
        }

#endregion

#region Capture methods

        private void ResizeVideoPanel()
        {
            try
            {
                if (!widescreen)
                {
                    int newwidth = ((int)(((double)pbVideo.Height) * 1.33));
                    int newx = (pbVideo.Width - newwidth) / 2;
                    pbVideo.Bounds = new Rectangle(newx, pbVideo.Bounds.Y, newwidth, pbVideo.Bounds.Height);
                }
                else
                {
                    int newwidth = ((int)(((double)pbVideo.Height) * 1.77));
                    int newx = (pbVideo.Width - newwidth) / 2;
                    pbVideo.Bounds = new Rectangle(newx, pbVideo.Bounds.Y, newwidth, pbVideo.Bounds.Height);
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


        private void capturePicture()
        {
            try
            {
                CF3_writePluginLog("capturePicture");

                if (mediaControl != null)
                    mediaControl.Pause();

                saveTimer.Enabled = true;
                string snapshotSavePath = Path.Combine(PictureFolder, "cam-" + DateTime.Now.ToString("MM-dd-yyyy-hhmmss") + ".jpg");

                pbVideo.Focus();
                SendKeys.SendWait("%{PRTSC}");

                IDataObject clpbrd = Clipboard.GetDataObject();
                if (clpbrd.GetDataPresent(typeof(Bitmap)))
                {
                    Image sshot = (Image)clpbrd.GetData(typeof(Bitmap));
                    pbVideo.Image = sshot;
                    pbVideo.Update();

                    Bitmap bdst = new Bitmap(pbVideo.Size.Width, pbVideo.Size.Height);
                    Graphics gdst = Graphics.FromImage(bdst);

                    gdst.DrawImage(sshot, new Rectangle(0, 0, pbVideo.Bounds.Width, pbVideo.Bounds.Height), pbVideo.Bounds.X, pbVideo.Bounds.Y, pbVideo.Bounds.Width, pbVideo.Bounds.Height, GraphicsUnit.Pixel);
                    bdst.Save(snapshotSavePath, ImageFormat.Jpeg);
                    CF_setConfigFlag(CF_ConfigFlags.MediaAdded, true);
                }

                this.CF_playAudioFile(Path.Combine(PluginLocation, "camera.wav"));
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


        private void stopCapture()
        {
            try
            {
                diskspaceTimer.Enabled = false;

                recording = false;
                CloseInterfaces();

                updateTitle();
                openPreviewWindow(false);

                if (!isfullscreen && !(Screen.AllScreens.Length >= CF_displayHooks.displayNumber && CF_displayHooks.displayNumber > 1))
                {
                    this.CF_setButtonOff("Centrafuse.Cam.Record");
                }
                else
                {
                    isfullscreen = true;
                    this.CF_setButtonOff("Centrafuse.Cam.Record");
                }

                this.CF_setConfigFlag(CF_ConfigFlags.MediaAdded, true);
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


        private void captureVideo()
        {
            try
            {
                recording = true;
                CloseInterfaces();

                updateTitle();
                fileName = Path.Combine(VideoFolder, "cam-" + DateTime.Now.ToString("MM-dd-yyyy-hhmmss") + ".wmv");
                openPreviewWindow(true);

                if (!isfullscreen && !(Screen.AllScreens.Length >= CF_displayHooks.displayNumber && CF_displayHooks.displayNumber > 1))
                {
                    this.CF_setButtonOn("Centrafuse.Cam.Record");
                }
                else
                {
                    isfullscreen = true;
                    this.CF_setButtonOn("Centrafuse.Cam.Record");
                }

                diskspaceTimer.Enabled = true;
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


		private void openPreviewWindow(bool record)
		{
            if (firstActive)
                return;
            firstActive = true;

            int hr = 0;
            IBaseFilter mux = null;
            IBaseFilter sourceFilter = null;
            IBaseFilter audioFilter = null;
            IFileSinkFilter sink = null;
            IBaseFilter asfWriter = null;

			try
			{
                // Get DirectShow interfaces
                GetInterfaces();

                // Attach the filter graph to the capture graph
                hr = this.captureGraphBuilder.SetFiltergraph(this.graphBuilder);
                DsError.ThrowExceptionForHR(hr);

                // Use the system device enumerator and class enumerator to find
                // a video capture/preview device, such as a desktop USB video camera.
                sourceFilter = FindCaptureDevice();

                if (sourceFilter != null)
                {
                    // Add Capture filter to our graph.
                    hr = this.graphBuilder.AddFilter(sourceFilter, "Video Capture");
                    DsError.ThrowExceptionForHR(hr);

                    // Set Horizontal flip
                    SetFlipHorizontal(captureGraphBuilder, sourceFilter, fliphorizontal);

                    // Render the preview pin on the video capture filter
                    // Use this instead of this.graphBuilder.RenderFile
                    hr = this.captureGraphBuilder.RenderStream(PinCategory.Preview, MediaType.Video, sourceFilter, null, null);
                    DsError.ThrowExceptionForHR(hr);

                    // Use the system device enumerator and class enumerator to find
                    // a audio capture/preview device, such as a microphone.
                    audioFilter = FindAudioDevice();

                    if (audioFilter != null)
                    {
                        // Add Capture filter to our graph.
                        hr = this.graphBuilder.AddFilter(audioFilter, "Audio Capture");
                        DsError.ThrowExceptionForHR(hr);

                        /*
                        hr = this.captureGraphBuilder.RenderStream(PinCategory.Preview, MediaType.Audio, audioFilter, null, null);
                        DsError.ThrowExceptionForHR(hr);
                        */
                    }

                    if (record)
                    {
                        /*
                        hr = this.captureGraphBuilder.SetOutputFileName(MediaSubType.Avi, fileName, out mux, out sink);
                        DsError.ThrowExceptionForHR(hr);
                        hr = this.captureGraphBuilder.RenderStream(PinCategory.Capture, MediaType.Video, sourceFilter, null, mux); // stream to file 
                        DsError.ThrowExceptionForHR(hr);
                        */

                        asfWriter = ConfigAsf(captureGraphBuilder, fileName, (audioFilter != null ? true : false));

                        if (asfWriter != null)
                        {
                            hr = this.captureGraphBuilder.RenderStream(PinCategory.Capture, MediaType.Video, sourceFilter, null, asfWriter);
                            DsError.ThrowExceptionForHR(hr);

                            if (audioFilter != null)
                            {
                                hr = this.captureGraphBuilder.RenderStream(PinCategory.Capture, MediaType.Audio, audioFilter, null, asfWriter);
                                DsError.ThrowExceptionForHR(hr);
                            }
                        }
                    }

                    // Now that the filter has been added to the graph and we have
                    // rendered its stream, we can release this reference to the filter.
                    Marshal.ReleaseComObject(sourceFilter);

                    // Set video window style and position
                    SetupVideoWindow();

                    // Add our graph to the running object table, which will allow
                    // the GraphEdit application to "spy" on our graph
                    rot = new DsROTEntry(this.graphBuilder);

                    // Start previewing video data
                    hr = this.mediaControl.Run();
                    DsError.ThrowExceptionForHR(hr);
                }

                updateTitle();
			}
			catch(Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
            finally
            {
                if (mux != null)
                    Marshal.ReleaseComObject(mux); mux = null;
                if (sink != null)
                    Marshal.ReleaseComObject(sink); sink = null;
                if (asfWriter != null)
                    Marshal.ReleaseComObject(asfWriter); asfWriter = null;
            }
		}

#endregion

#region DShowControls

        private IBaseFilter ConfigAsf(ICaptureGraphBuilder2 capGraph, string szOutputFileName, bool hasaudio)
        {
            IBaseFilter asfWriter = null;
            IFileSinkFilter pTmpSink = null;

            try
            {
                int hr = capGraph.SetOutputFileName(MediaSubType.Asf, szOutputFileName, out asfWriter, out pTmpSink);
                DsError.ThrowExceptionForHR(hr);

                try
                {
                    IConfigAsfWriter lConfig = asfWriter as IConfigAsfWriter;

                    Guid cat = WMData.WMProfile_V80_56Video;

                    if (hasaudio)
                        cat = WMData.WMProfile_V80_256Video;

                    hr = lConfig.ConfigureFilterUsingProfileGuid(cat);
                    DsError.ThrowExceptionForHR(hr);
                }
                catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
                finally
                {
                    if (pTmpSink != null)
                        Marshal.ReleaseComObject(pTmpSink);
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }

            return asfWriter;
        }


        private void SetFlipHorizontal(ICaptureGraphBuilder2 capGraph, IBaseFilter capFilter, bool flip)
        {
            try
            {
                int hr;
                IAMVideoControl videoControl = capFilter as IAMVideoControl;

                if (videoControl != null)
                {
                    VideoControlFlags pCapsFlags;

                    IPin pPin = DsFindPin.ByCategory(capFilter, PinCategory.Capture, 0);
                    hr = videoControl.GetCaps(pPin, out pCapsFlags);
                    DsError.ThrowExceptionForHR(hr);

                    if ((pCapsFlags & VideoControlFlags.FlipHorizontal) > 0)
                    {
                        hr = videoControl.GetMode(pPin, out pCapsFlags);
                        DsError.ThrowExceptionForHR(hr);

                        if(flip)
                            hr = videoControl.SetMode(pPin, VideoControlFlags.FlipHorizontal);
                        else
                            hr = videoControl.SetMode(pPin, VideoControlFlags.None);
                    }
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


        // Set the Framerate, and video size
        private void SetConfigParms(ICaptureGraphBuilder2 capGraph, IBaseFilter capFilter, int iFrameRate, int iWidth, int iHeight)
        {
            try
            {
                int hr;
                object o;
                AMMediaType media;
                IAMStreamConfig videoStreamConfig;
                IAMVideoControl videoControl = capFilter as IAMVideoControl;

                // Find the stream config interface
                hr = capGraph.FindInterface(PinCategory.Capture, MediaType.Video, capFilter, typeof(IAMStreamConfig).GUID, out o);
                videoStreamConfig = o as IAMStreamConfig;

                try
                {
                    if (videoStreamConfig == null)
                        throw new Exception("Failed to get IAMStreamConfig");

                    hr = videoStreamConfig.GetFormat(out media);
                    DsError.ThrowExceptionForHR(hr);

                    // copy out the videoinfoheader
                    VideoInfoHeader v = new VideoInfoHeader();
                    Marshal.PtrToStructure(media.formatPtr, v);

                    // if overriding the framerate, set the frame rate
                    if (iFrameRate > 0)
                        v.AvgTimePerFrame = 10000000 / iFrameRate;

                    // if overriding the width, set the width
                    if (iWidth > 0)
                        v.BmiHeader.Width = iWidth;

                    // if overriding the Height, set the Height
                    if (iHeight > 0)
                        v.BmiHeader.Height = iHeight;

                    // Copy the media structure back
                    Marshal.StructureToPtr(v, media.formatPtr, false);

                    // Set the new format
                    hr = videoStreamConfig.SetFormat(media);

                    DsError.ThrowExceptionForHR(hr);
                    DsUtils.FreeAMMediaType(media);
                    media = null;
                }
                finally
                {
                    Marshal.ReleaseComObject(videoStreamConfig);
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


        private IBaseFilter FindCaptureDevice()
        {
            object source;
            DsDevice[] devices;
            DsDevice device = null;

            try
            {
                // Get all video input devices
                devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

                if (currentcam < devices.Length && devices.Length > 0)
                    device = (DsDevice)devices[currentcam];

                if (device != null)
                {
                    // Bind Moniker to a filter object
                    Guid iid = typeof(IBaseFilter).GUID;
                    device.Mon.BindToObject(null, null, ref iid, out source);

                    // An exception is thrown if cast fail
                    return (IBaseFilter)source;
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }

            return null;
        }


        private IBaseFilter FindAudioDevice()
        {
            object source;
            DsDevice[] devices;
            DsDevice device = null;

            try
            {
                // Get all audio input devices
                devices = DsDevice.GetDevicesOfCat(FilterCategory.AudioInputDevice);

                //hard coded
                if (0 < devices.Length && devices.Length > 0)
                    device = (DsDevice)devices[0];

                if (device != null)
                {
                    // Bind Moniker to a filter object
                    Guid iid = typeof(IBaseFilter).GUID;
                    device.Mon.BindToObject(null, null, ref iid, out source);

                    // An exception is thrown if cast fail
                    return (IBaseFilter)source;
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }

            return null;
        }


        private void GetInterfaces()
        {
            try
            {
                int hr = 0;

                // An exception is thrown if cast fail
                this.graphBuilder = (IGraphBuilder)new FilterGraph();
                this.captureGraphBuilder = (ICaptureGraphBuilder2)new CaptureGraphBuilder2();
                this.mediaControl = (IMediaControl)this.graphBuilder;
                this.videoWindow = (IVideoWindow)this.graphBuilder;
                this.mediaEventEx = (IMediaEventEx)this.graphBuilder;

                hr = this.mediaEventEx.SetNotifyWindow(this.Handle, WM_GRAPHNOTIFY, IntPtr.Zero);
                DsError.ThrowExceptionForHR(hr);

                initialized = true;
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


        private void CloseInterfaces()
        {
            try
            {
                // Stop previewing data
                if (this.mediaControl != null)
                    this.mediaControl.StopWhenReady();

                // Stop receiving events
                if (this.mediaEventEx != null)
                    this.mediaEventEx.SetNotifyWindow(IntPtr.Zero, WM_GRAPHNOTIFY, IntPtr.Zero);

                // Relinquish ownership (IMPORTANT!) of the video window.
                // Failing to call put_Owner can lead to assert failures within
                // the video renderer, as it still assumes that it has a valid
                // parent window.
                if (this.videoWindow != null)
                {
                    this.videoWindow.put_Visible(OABool.False);
                    this.videoWindow.put_Owner(IntPtr.Zero);
                }

                // Remove filter graph from the running object table
                if (rot != null)
                {
                    rot.Dispose();
                    rot = null;
                }

                // Release DirectShow interfaces
                if (this.mediaControl != null)
                    Marshal.ReleaseComObject(this.mediaControl); this.mediaControl = null;
                if (this.mediaEventEx != null)
                    Marshal.ReleaseComObject(this.mediaEventEx); this.mediaEventEx = null;
                if (this.videoWindow != null)
                    Marshal.ReleaseComObject(this.videoWindow); this.videoWindow = null;
                if (this.graphBuilder != null)
                    Marshal.ReleaseComObject(this.graphBuilder); this.graphBuilder = null;
                if (this.captureGraphBuilder != null)
                    Marshal.ReleaseComObject(this.captureGraphBuilder); this.captureGraphBuilder = null;
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }

            firstActive = false;
            initialized = false;
        }


        private void SetupVideoWindow()
        {
            try
            {
                int hr = 0;

                // Set the video window to be a child of the main window
                hr = this.videoWindow.put_Owner(this.pbVideo.Handle);
                DsError.ThrowExceptionForHR(hr);

                hr = this.videoWindow.put_WindowStyle(WindowStyle.Child | WindowStyle.ClipChildren);
                DsError.ThrowExceptionForHR(hr);

                // Use helper function to position video window in client rect 
                // of main application window
                ResizeVideoWindow();

                // Make the video window visible, now that it is properly positioned
                hr = this.videoWindow.put_Visible(OABool.True);
                DsError.ThrowExceptionForHR(hr);
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


        private void ResizeVideoWindow()
        {
            try
            {
                // Resize the video preview window to match owner window size
                if (this.videoWindow != null)
                {
                    this.videoWindow.SetWindowPosition(0, 0, this.pbVideo.Width, this.pbVideo.Height);
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


        private void HandleGraphEvent()
        {
            try
            {
                int hr = 0;
                EventCode evCode;
                IntPtr evParam1, evParam2;

                if (this.mediaEventEx == null)
                    return;

                while (this.mediaEventEx.GetEvent(out evCode, out evParam1, out evParam2, 0) == 0)
                {
                    // Free event parameters to prevent memory leaks associated with
                    // event parameter data.  While this application is not interested
                    // in the received events, applications should always process them.
                    hr = this.mediaEventEx.FreeEventParams(evCode, evParam1, evParam2);
                    DsError.ThrowExceptionForHR(hr);

                    // Insert event processing code here, if desired
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


        protected override void WndProc(ref Message m)
        {
            try
            {
                switch (m.Msg)
                {
                    case WM_GRAPHNOTIFY:
                    {
                        HandleGraphEvent();
                        break;
                    }
                }

                if (this.videoWindow != null)
                    this.videoWindow.NotifyOwnerMessage(m.HWnd, m.Msg, m.WParam, m.LParam);
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }

            base.WndProc(ref m);
        }

#endregion

    }
}