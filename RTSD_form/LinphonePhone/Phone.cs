using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinphoneAccount;
using LinphoneCoreWrapper;

namespace LinphonePhone
{
	public class Phone
	{
		public enum ConnectState
		{
			Disconnected, // Idle
			Progress, // Registering on server
			Connected // Successfull registered
		};
		private ConnectState connectState;

		public Account account {get;}

		private string userAgent {get; set;} = "liblinphone";
		private string version {get; set;} = "6.0.0";

		private CoreWrapper coreWrapper;

		public Phone(Account account)
		{
			this.Account = account;

			this.coreWrapper = new CoreWrapper();
			this.coreWrapper.RegistrationStateChangedEvent += (CoreWrapper.LinphoneRegistrationState state) =>
			{
				// TODO.
			}
		}

		public void Connect()
		{
			if (this.connectState == ConnectState.Disconnected)
			{
				this.connectState = ConnectState.Progress;
				this.coreWrapper.createPhone(this.account.Username, this.account.Password, this.account.Server, this.account.Port, this.userAgent, this.version)
			}
		}
	}
}