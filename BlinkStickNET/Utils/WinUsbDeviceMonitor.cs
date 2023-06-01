/*
namespace BlinkStickNET.Utils;

using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;

public class WinUsbDeviceMonitor
{
	/// <summary>
	/// Occurs when device list changed.
	/// </summary>
	public event EventHandler DeviceListChanged;
	
	/// <summary>
	/// Raises the device list changed event.
	/// </summary>
	protected void OnDeviceListChanged()
	{
		if (DeviceListChanged != null)
		{
			DeviceListChanged(this, new EventArgs());
		}
	}

	public Boolean Enabled { get; set; }

	/// <summary>
	/// Private property to keep reference to Windows form for getting
	/// notification from the OS about changes to USB devices
	/// </summary>
	MyForm form;

	public class MyForm : Form
	{
		public WinUsbDeviceMonitor Monitor;

		const int WM_DEVICECHANGE = 0x0219;
		const int DBT_DEVICEARRIVAL = 0x8000; // system detected a new device
		const int DBT_DEVICEREMOVECOMPLETE = 0x8004; //device was removed
		const int DBT_DEVNODES_CHANGED = 0x0007; //device changed
		const int DBT_DEVTYP_VOLUME = 0x00000002; // logical volume

		//[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == WM_DEVICECHANGE
				&& (m.WParam.ToInt32() == DBT_DEVICEARRIVAL
				|| m.WParam.ToInt32() == DBT_DEVICEREMOVECOMPLETE
				|| m.WParam.ToInt32() == DBT_DEVNODES_CHANGED))
			{
				if (this.Enabled)
					Monitor.OnDeviceListChanged();
			}
			
			base.WndProc(ref m);
		}
	
	}

	public WinUsbDeviceMonitor ()
	{
		this.Enabled = false;

		form = new MyForm();
		form.Monitor = this;

		//Move main form off the screen
		form.StartPosition = FormStartPosition.Manual;
		form.Width = 10;
		form.Height = 10;
		form.Left = -200;
		form.ShowInTaskbar = false;

		form.Visible = true;
		form.Visible = false;
	}
}
*/
