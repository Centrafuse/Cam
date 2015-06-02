using System;
using System.Xml;
using System.Windows.Forms;
using centrafuse.Plugins;
using System.Text;
using System.Collections;
using System.Web;
using centrafuse.Plugins.DirectShowLib;

namespace cam
{
	/*
	 * Setup class inherits from CFSetup
	 * so that it will not show up as a seperate
	 * plugin, but a dialog within a plugin.
	 * It uses the standard setup screens from the
	 * main application
	*/
	public class setup : CFSetup
	{
		public setup(ICFMain mForm, ConfigReader config, LanguageReader lang)
		{
            this.MainForm = mForm;

            this.pluginConfig = config;
            this.pluginLang = lang;

            CF_initSetup(1, 1);

            this.CF_updateText("TITLE", this.pluginLang.ReadField("/APPLANG/SETUP/HEADER"));
		}


        public override void CF_setupReadSettings(int currentpage, bool advanced)
        {
            try {
                int i = CFSetupButton.One;
                if (advanced) 
                {
                    /*******************************************************************************************/
                    /*****  ADVANCED SETTINGS - PAGE 1  ********************************************************/
                    /*******************************************************************************************/
                    if (currentpage == 1) 
                    {
                        // TEXT BUTTONS (1-4)

                        ButtonHandler[i] = new CFSetupHandler(SetDisplayName);
                        ButtonText[i] = pluginLang.ReadField("/APPLANG/SETUP/DISPLAYNAME");
                        ButtonValue[i++] = pluginLang.ReadField("/APPLANG/CAM/DISPLAYNAME");
                        
                        ButtonHandler[i] = new CFSetupHandler(SetVideoDevice);
                        ButtonText[i] = pluginLang.ReadField("APPLANG/SETUP/VIDEODEVICE");
                        ButtonValue[i++] = VideoDeviceText();

                        ButtonHandler[i] = new CFSetupHandler(SetDisplay);
                        ButtonText[i] = pluginLang.ReadField("/APPLANG/SETUP/CAMDISPLAY");
                        ButtonValue[i++] = LanguageReader.GetText("APPLANG/SETUP/DISPLAY") + this.pluginConfig.ReadField("/APPCONFIG/DISPLAY");

                        ButtonHandler[i] = new CFSetupHandler(SetResolution);
                        ButtonText[i] = "RESOLUTION";
                        ButtonValue[i++] = this.pluginConfig.ReadField("/APPCONFIG/RESX") + " x " + this.pluginConfig.ReadField("/APPCONFIG/RESY");

                        // BOOL BUTTONS (5-8)

                        ButtonHandler[i] = new CFSetupHandler(SetStartFullScreen);
                        ButtonText[i] = pluginLang.ReadField("/APPLANG/SETUP/FULLSCREEN");
                        ButtonValue[i++] = this.pluginConfig.ReadField("/APPCONFIG/STARTFULLSCREEN");

                        ButtonHandler[i] = new CFSetupHandler(SetWideScreen);
                        ButtonText[i] = pluginLang.ReadField("/APPLANG/SETUP/WIDESCREEN");
                        ButtonValue[i++] = this.pluginConfig.ReadField("/APPCONFIG/WIDESCREEN");

                        ButtonHandler[i] = new CFSetupHandler(SetFlipScreen);
                        ButtonText[i] = pluginLang.ReadField("/APPLANG/SETUP/FLIPSCREEN");
                        ButtonValue[i++] = this.pluginConfig.ReadField("/APPCONFIG/FLIPSCREEN");
                        
                        ButtonHandler[i] = null;
                        ButtonText[i] = "";
                        ButtonValue[i++] = "";
                    }
                }
                else 
                {
                    /*******************************************************************************************/
                    /*****  BASIC SETTINGS - PAGE 1  ***********************************************************/
                    /*******************************************************************************************/
                    if (currentpage == 1) 
                    {
                        // TEXT BUTTONS (1-4)

                        ButtonHandler[i] = new CFSetupHandler(SetDisplayName);
                        ButtonText[i] = pluginLang.ReadField("/APPLANG/SETUP/DISPLAYNAME");
                        ButtonValue[i++] = pluginLang.ReadField("/APPLANG/CAM/DISPLAYNAME");

                        ButtonHandler[i] = new CFSetupHandler(SetVideoDevice);
                        ButtonText[i] = pluginLang.ReadField("APPLANG/SETUP/VIDEODEVICE");
                        ButtonValue[i++] = VideoDeviceText();

                        ButtonHandler[i] = new CFSetupHandler(SetDisplay);
                        ButtonText[i] = pluginLang.ReadField("/APPLANG/SETUP/CAMDISPLAY");
                        ButtonValue[i++] = LanguageReader.GetText("APPLANG/SETUP/DISPLAY") + this.pluginConfig.ReadField("/APPCONFIG/DISPLAY");

                        ButtonHandler[i] = null;
                        ButtonText[i] = "";
                        ButtonValue[i++] = "";

                        // BOOL BUTTONS (5-8)

                        ButtonHandler[i] = new CFSetupHandler(SetStartFullScreen);
                        ButtonText[i] = pluginLang.ReadField("/APPLANG/SETUP/FULLSCREEN");
                        ButtonValue[i++] = this.pluginConfig.ReadField("/APPCONFIG/STARTFULLSCREEN");

                        ButtonHandler[i] = new CFSetupHandler(SetWideScreen);
                        ButtonText[i] = pluginLang.ReadField("/APPLANG/SETUP/WIDESCREEN");
                        ButtonValue[i++] = this.pluginConfig.ReadField("/APPCONFIG/WIDESCREEN");

                        ButtonHandler[i] = new CFSetupHandler(SetFlipScreen);
                        ButtonText[i] = pluginLang.ReadField("/APPLANG/SETUP/FLIPSCREEN");
                        ButtonValue[i++] = this.pluginConfig.ReadField("/APPCONFIG/FLIPSCREEN");

                        ButtonHandler[i] = null;
                        ButtonText[i] = "";
                        ButtonValue[i++] = "";
                    }
                }
            }
			catch(Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


        private string VideoDeviceText()
        {
            string camdevice = "";

            try
            {
                DsDevice[] devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
                int configcamdevice = Int32.Parse(this.pluginConfig.ReadField("/APPCONFIG/VIDEODEVICE"));

                for (int i = 0; i < devices.Length; i++)
                {
                    if (configcamdevice == i)
                    {
                        camdevice = devices[i].Name;
                        break;
                    }
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }

            return camdevice;
        }

#region Button Clicks

		private void SetDisplayName(ref object value)
        {
            try
            {
                object tempobject;
                string resultvalue, resulttext;
                if (this.CF_systemDisplayDialog(CF_Dialogs.OSK, this.pluginLang.ReadField("/APPLANG/SETUP/BUTTON1TEXT"), ButtonValue[(int)value], null, out resultvalue, out resulttext, out tempobject, null, true, true, true, true, false, false, 1) == DialogResult.OK)
                {
                    this.pluginLang.WriteField("/APPLANG/CAM/DISPLAYNAME", resultvalue);
                    ButtonValue[(int)value] = resultvalue;
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


        private void SetVideoDevice(ref object value)
        {
            try
            {
                DsDevice[] devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
                CFControls.CFListViewItem[] camdevices = new CFControls.CFListViewItem[devices.Length];

                for (int i = 0; i < devices.Length; i++)
                {
                    camdevices[i] = new CFControls.CFListViewItem(devices[i].Name, i.ToString(), -1, false);
                }

                object tempobject;
                string resultvalue, resulttext;
                if (this.CF_systemDisplayDialog(CF_Dialogs.FileBrowser, this.pluginLang.ReadField("/APPLANG/SETUP/BUTTON2TEXT"), this.pluginLang.ReadField("/APPLANG/SETUP/VIDEODEVICES"), ButtonValue[(int)value], out resultvalue, out resulttext, out tempobject, camdevices, true, true, true, true, false, false, 1) == DialogResult.OK)
                {
                    this.pluginConfig.WriteField("/APPCONFIG/VIDEODEVICE", resultvalue);
                    ButtonValue[(int)value] = VideoDeviceText();
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


        private void SetDisplay(ref object value)
        {
            try
            {
                CFControls.CFListViewItem[] playlist = new CFControls.CFListViewItem[Screen.AllScreens.Length];
                for (int i = 0; i < Screen.AllScreens.Length; i++)
                {
                    playlist[i] = new CFControls.CFListViewItem(LanguageReader.GetText("APPLANG/SETUP/DISPLAY") + (i + 1), (i + 1).ToString(), -1, false);
                }

                object tempobject;
                string resultvalue, resulttext;
                if (this.CF_systemDisplayDialog(CF_Dialogs.FileBrowser, LanguageReader.GetText("APPLANG/SETUP/SELECTDISPLAYTEXT"), LanguageReader.GetText("APPLANG/SETUP/DISPLAYS"), ButtonValue[(int)value], out resultvalue, out resulttext, out tempobject, playlist, true, true, true, false, false, false, 1) == DialogResult.OK)
                {
                    this.pluginConfig.WriteField("/APPCONFIG/DISPLAY", resultvalue);
                    ButtonValue[(int)value] = LanguageReader.GetText("APPLANG/SETUP/DISPLAY") + resultvalue;
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


        private void SetResolution(ref object value)
        {
            try
            {
                CFControls.CFListViewItem[] playlist = new CFControls.CFListViewItem[11];
                playlist[0] = new CFControls.CFListViewItem("240 x 240", "240x240", -1, false);
                playlist[1] = new CFControls.CFListViewItem("320 x 240", "320x240", -1, false);
                playlist[2] = new CFControls.CFListViewItem("320 x 320", "320x320", -1, false);
                playlist[3] = new CFControls.CFListViewItem("480 x 360", "480x360", -1, false);
                playlist[4] = new CFControls.CFListViewItem("480 x 480", "480x480", -1, false);
                playlist[5] = new CFControls.CFListViewItem("640 x 480", "640x480", -1, false);
                playlist[6] = new CFControls.CFListViewItem("640 x 640", "640x640", -1, false);
                playlist[7] = new CFControls.CFListViewItem("800 x 600", "800x600", -1, false);
                playlist[8] = new CFControls.CFListViewItem("800 x 800", "800x800", -1, false);
                playlist[9] = new CFControls.CFListViewItem("1024 x 768", "1024x768", -1, false);
                playlist[10] = new CFControls.CFListViewItem("1024 x 1024", "1024x1024", -1, false);

                object tempobject;
                string resultvalue, resulttext;
                if (this.CF_systemDisplayDialog(CF_Dialogs.FileBrowser, LanguageReader.GetText("APPLANG/SETUP/RESOLUTION"), LanguageReader.GetText("APPLANG/SETUP/RESOLUTIONS"), ButtonValue[(int)value], out resultvalue, out resulttext, out tempobject, playlist, true, true, true, false, false, false, 1) == DialogResult.OK)
                {
                    char[] delims = { 'x' } ;
                    this.pluginConfig.WriteField("/APPCONFIG/RESX", resultvalue.Split(delims)[0].Trim());
                    this.pluginConfig.WriteField("/APPCONFIG/RESY", resultvalue.Split(delims)[1].Trim());
                    ButtonValue[(int)value] = resulttext;
                }
            }
            catch (Exception errmsg) { CFTools.writeError(errmsg.Message, errmsg.StackTrace); }
        }


		private void SetStartFullScreen(ref object value)
		{
            this.pluginConfig.WriteField("/APPCONFIG/STARTFULLSCREEN", value.ToString());
		}


        private void SetWideScreen(ref object value)
        {
            this.pluginConfig.WriteField("/APPCONFIG/WIDESCREEN", value.ToString());
        }


        private void SetFlipScreen(ref object value)
        {
            this.pluginConfig.WriteField("/APPCONFIG/FLIPSCREEN", value.ToString());
        }

#endregion

	}
}