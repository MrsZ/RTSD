using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiblinphonedotNET
{
	public class Phone
	{
		public enum ConnectState
		{
			Disconnected, // Idle
			Progress, // Registering on server
			Connected // Successfull registered
		};
        public enum LineState
        {
            Free,
            Busy
        }

        public enum Error
        {
            RegisterFailed, // registration error
            LineIsBusyError, // trying to make/receive call while another call is active
            OrderError, // trying to connect while connected / connecting or disconnect when not connected
            CallError, // call failed
            UnknownError
        };

        //Define delegates and events
        public delegate void OnPhoneConnected();
        public delegate void OnPhoneDisconnected();
        public delegate void OnIncomingCall(Call call);
        public delegate void OnCallActive(Call call);
        public delegate void OnCallCompleted(Call call);
        public delegate void OnCallRinging(Call call);
        public delegate void OnError(Call call, Error error);
		public delegate void MessageReceivedDelegate(string message);

		public event OnPhoneConnected ConnectedEvent;
        public event OnPhoneDisconnected DisconnectedEvent;
        public event OnIncomingCall CallIncomingEvent;
        public event OnCallActive CallActiveEvent;
        public event OnCallCompleted CallCompletedEvent;
        public event OnCallRinging CallRingingEvent;
        public event OnError ErrorEvent;
		public event MessageReceivedDelegate MessageReceivedEvent;

		private ConnectState connectState;
        private LineState line_state;

		public Account account {get;}

		private string userAgent {get; set;} = "liblinphone";
		private string version {get; set;} = "0.1.0";

		private CoreWrapper coreWrapper;
		private IntPtr chat_room;

		public Phone(Account account)
		{
			this.account = account;
			
			this.coreWrapper = new CoreWrapper();
            this.coreWrapper.RegistrationStateChangedEvent += (CoreWrapper.LinphoneRegistrationState state) =>
            {
                switch (state)
                {
                    case CoreWrapper.LinphoneRegistrationState.LinphoneRegistrationProgress:
                        connectState = ConnectState.Progress;
                        break;

                    case CoreWrapper.LinphoneRegistrationState.LinphoneRegistrationFailed:
                        coreWrapper.destroyPhone();
                        if (ErrorEvent != null)
                            ErrorEvent(null, Error.RegisterFailed);
                        break;

                    case CoreWrapper.LinphoneRegistrationState.LinphoneRegistrationCleared:
                        connectState = ConnectState.Connected;
                        if (DisconnectedEvent != null)
                            DisconnectedEvent(); //Trigger disconnect event
                        break;

                    case CoreWrapper.LinphoneRegistrationState.LinphoneRegistrationOk:
                        connectState = ConnectState.Connected;
                        if (ConnectedEvent != null)
                            ConnectedEvent(); //Trigger connected event
                        break;

                    case CoreWrapper.LinphoneRegistrationState.LinphoneRegistrationNone:
                    default:
                        break;
                }
            };

            //Create body for error callbacks
            coreWrapper.ErrorEvent += (call, message) =>
            {
                Console.WriteLine("Error: {0}!", message);
                if (ErrorEvent != null) ErrorEvent(call, Error.UnknownError);
            };

			coreWrapper.MessageReceivedEvent += OnMessageReceived;

            //Seperate call state changed event into CallState events
            coreWrapper.CallStateChangedEvent += (Call call) =>
            {
                Call.State state = call.state;

                switch (state)
                {
                    case Call.State.Active:
                        line_state = LineState.Busy;
                        if (CallActiveEvent != null)
                            CallActiveEvent(call);
                        break;

                    case Call.State.Ringing:
                        line_state = LineState.Busy;
                        if (CallRingingEvent != null)
                            CallRingingEvent(call);
                        break;

                    case Call.State.Loading:
                        line_state = LineState.Busy;
                        if (call.call_type == Call.CallType.Incoming)
                            if (CallIncomingEvent != null)
                                CallIncomingEvent(call);
                        break;

                    case Call.State.Error:
                        line_state = LineState.Free;
                        if (ErrorEvent != null)
                            ErrorEvent(null, Error.CallError);
                        if (CallCompletedEvent != null)
                            CallCompletedEvent(call);
                        break;

                    case Call.State.Completed:
                    default:
                        line_state = LineState.Free;
                        if (CallCompletedEvent != null)
                            CallCompletedEvent(call);
                        break;
                }
            };
		}

		public void Connect()
		{
			if (this.connectState == ConnectState.Disconnected)
			{
				this.connectState = ConnectState.Progress;
                this.coreWrapper.createPhone(this.account.Username, this.account.Password, this.account.Server, this.account.Port, this.userAgent, this.version);
			}
		}

        public void MakeCall(string sipUriOrPhone)
        {
            if (string.IsNullOrEmpty(sipUriOrPhone))
                throw new ArgumentNullException("sipUriOrPhone");

            if (line_state == LineState.Free)
                coreWrapper.makeCall(sipUriOrPhone);
            else if (ErrorEvent != null)
                ErrorEvent(null, Error.LineIsBusyError);
        }

		public void CreateChatRoom(string uri)
		{
			if (string.IsNullOrEmpty(uri))
				throw new ArgumentNullException("uri");
			this.chat_room = coreWrapper.createChatRoom(uri);
		}

		public void SendMessage(string message)
		{
			if (message.Length != 0) {
				coreWrapper.sendMessage(this.chat_room, message);
			}
		}

		public void OnMessageReceived(string msg)
		{
			if (MessageReceivedEvent != null)
			{
				MessageReceivedEvent(msg);
			}
		}
	}
}