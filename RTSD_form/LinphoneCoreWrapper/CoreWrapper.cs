using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

using LinphoneCall;

namespace LinphoneCoreWrapper
{
    public class CoreWrapper
    {
		#region Import
        private const string LIBRARY_NAME = "Linphone.dll";

        struct LCSipTransports
        {
            public int udp_port; // udp port to listening on, negative value if not set
            public int tcp_port; // tcp port to listening on, negative value if not set
            public int dtls_port; // dtls port to listening on, negative value if not set
            public int tls_port; // tls port to listening on, negative value if not set
        };

        // from /include/linphone/linphonecore.h
        public enum LinphoneCallState
		{
			LinphoneCallIdle, // Initial call state
			LinphoneCallIncomingReceived, // This is a new incoming call
			LinphoneCallOutgoingInit, // An outgoing call is started
			LinphoneCallOutgoingProgress, // An outgoing call is in progress
			LinphoneCallOutgoingRinging, // An outgoing call is ringing at remote end
			LinphoneCallOutgoingEarlyMedia, // An outgoing call is proposed early media
			LinphoneCallConnected, // Connected, the call is answered
			LinphoneCallStreamsRunning, // The media streams are established and running
			LinphoneCallPausing, // The call is pausing at the initiative of local end
			LinphoneCallPaused, // The call is paused, remote end has accepted the pause
			LinphoneCallResuming, // The call is being resumed by local end
			LinphoneCallRefered, // The call is being transfered to another party, resulting in a new outgoing call to follow immediately
			LinphoneCallError, // The call encountered an error
			LinphoneCallEnd, // The call ended normally
			LinphoneCallPausedByRemote, // The call is paused by remote end
			LinphoneCallUpdatedByRemote, // The call's parameters change is requested by remote end, used for example when video is added by remote
			LinphoneCallIncomingEarlyMedia, // We are proposing early media to an incoming call
			LinphoneCallUpdating, // A call update has been initiated by us
			LinphoneCallReleased, // The call object is no more retained by the core
			LinphoneCallEarlyUpdatedByRemote, // The call is updated by remote while not yet answered (early dialog SIP UPDATE received).
			LinphoneCallEarlyUpdating // We are updating the call while not yet answered (early dialog SIP UPDATE sent)
		};

		public enum LinphoneRegistrationState
		{
			LinphoneRegistrationNone, // Initial state for registrations
			LinphoneRegistrationProgress, // Registration is in progress
			LinphoneRegistrationOk,	// Registration is successful
			LinphoneRegistrationCleared, // Unregistration succeeded
			LinphoneRegistrationFailed	// Registration failed
		};

		public enum LinphoneChatMessageState
		{
			LinphoneChatMessageStateIdle, // Initial state
			LinphoneChatMessageStateInProgress, // Delivery in progress
			LinphoneChatMessageStateDelivered, // Message successfully delivered and acknowledged by remote end point
			LinphoneChatMessageStateNotDelivered, // Message was not delivered
			LinphoneChatMessageStateFileTransferError, // Message was received(and acknowledged) but cannot get file from server
			LinphoneChatMessageStateFileTransferDone // File transfer has been completed successfully.
		};

		struct LinphoneCoreVTable
		{
			public IntPtr global_state_changed; // Notifies global state changes
			public IntPtr registration_state_changed; // Notifies registration state changes
			public IntPtr call_state_changed; // Notifies call state changes
			public IntPtr notify_presence_received; // Notify received presence events
			public IntPtr new_subscription_requested; // Notify about pending presence subscription request
			public IntPtr auth_info_requested; // Ask the application some authentication information
			public IntPtr call_log_updated; // Notifies that call log list has been updated
			public IntPtr message_received; // a message is received, can be text or external body
			public IntPtr is_composing_received; // An is-composing notification has been received
			public IntPtr dtmf_received; // A dtmf has been received received
			public IntPtr refer_received; // An out of call refer was received
			public IntPtr call_encryption_changed; // Notifies on change in the encryption of call streams
			public IntPtr transfer_state_changed; // Notifies when a transfer is in progress
			public IntPtr buddy_info_updated; // a LinphoneFriend's BuddyInfo has changed
			public IntPtr call_stats_updated; // Notifies on refreshing of call's statistics.
			public IntPtr info_received; // Notifies an incoming informational message received.
			public IntPtr subscription_state_changed; // Notifies subscription state change
			public IntPtr notify_received; // Notifies a an event notification, see linphone_core_subscribe()
			public IntPtr publish_state_changed; // Notifies publish state change (only from #LinphoneEvent api)
			public IntPtr configuring_status; // Notifies configuring status changes
			public IntPtr display_status; // @deprecated Callback that notifies various events with human readable text.
			public IntPtr display_message; // @deprecated Callback to display a message to the user
			public IntPtr display_warning; // @deprecated Callback to display a warning to the user
			public IntPtr display_url; // @deprecated
			public IntPtr show; // @deprecated Notifies the application that it should show up
			public IntPtr text_received; // @deprecated, use #message_received instead <br> A text message has been received
			public IntPtr file_transfer_recv; // @deprecated Callback to store file received attached to a #LinphoneChatMessage
			public IntPtr file_transfer_send; // @deprecated Callback to collect file chunk to be sent for a #LinphoneChatMessage
			public IntPtr file_transfer_progress_indication; // @deprecated Callback to indicate file transfer progress
			public IntPtr network_reachable; // Callback to report IP network status (I.E up/down )
			public IntPtr log_collection_upload_state_changed; // Callback to upload collected logs
			public IntPtr log_collection_upload_progress_indication; // Callback to indicate log collection upload progress
		};

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern void linphone_core_destroy(IntPtr lc);

		[DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr linphone_core_new(IntPtr vtable, string config_path, string factory_config_path, IntPtr userdata);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void linphone_core_iterate(IntPtr lc);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void linphone_core_set_sip_transports(IntPtr lc, IntPtr tr_config);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void linphone_core_set_user_agent(IntPtr lc, string ua_name, string version);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr linphone_core_create_default_call_parameters(IntPtr lc);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void linphone_call_params_enable_video(IntPtr calls_def_params, bool isEnabled);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void linphone_call_params_enable_early_media_sending(IntPtr calls_def_params, bool isEnabled);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr linphone_auth_info_new(string username, string userid, string password, string ha1, string realm, string domain);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void linphone_core_add_auth_info(IntPtr lc, IntPtr auth_info);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr linphone_core_create_proxy_config(IntPtr lc);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void linphone_proxy_config_set_identity(IntPtr cfg, string identity);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void linphone_proxy_config_set_server_addr(IntPtr cfg, string server);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void linphone_proxy_config_enable_register(IntPtr cfg, bool isEnabled);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void linphone_core_add_proxy_config(IntPtr lc, IntPtr cfg);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void linphone_core_set_default_proxy_config(IntPtr lc, IntPtr cfg);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr linphone_core_invite(IntPtr lc, string uri);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr linphone_call_get_remote_address_as_string(IntPtr call);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr linphone_call_params_get_record_file(IntPtr default_params);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void linphone_call_stop_recording(IntPtr call);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void linphone_core_accept_call(IntPtr lc, IntPtr call);

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr linphone_core_get_chat_room_from_uri(IntPtr lc, string contact);

		[DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr linphone_chat_room_create_message(IntPtr ChatRoom, string message);

		[DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern void linphone_chat_room_send_chat_message(IntPtr ChatRoom, IntPtr ChatMessage);

		[DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
		public static extern void linphone_chat_room_destroy(IntPtr ChatRoom);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void LinphoneCoreRegistrationStateChangedCb(IntPtr lc, IntPtr cfg, LinphoneRegistrationState cstate, string message);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void LinphoneCoreCallStateChangedCb(IntPtr lc, IntPtr call, LinphoneCallState cstate, string message);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void LinphoneCoreMessageReceivedCb(IntPtr lc, IntPtr room, IntPtr message);


		#endregion
		class LinphoneCallPtr : Call
        {
            IntPtr ptr;
            public IntPtr Ptr
            {
                get { return ptr;  }
                set { this.ptr = value; }
            }
        }

        public delegate void CallStateChangedDelegate(Call call);
        public event CallStateChangedDelegate CallStateChangedEvent;

        public delegate void ErrorDelegate(Call call, string message);
        public event ErrorDelegate ErrorEvent;

		LinphoneCoreRegistrationStateChangedCb registration_state_changed;
		LinphoneCoreCallStateChangedCb call_state_changed; // TODO. remember to add into vtable;
		LinphoneCoreMessageReceivedCb message_received;
		IntPtr linphoneCore;

		IntPtr auth_info;
		string identity;

		LinphoneCoreVTable vtable;
        IntPtr vtablePtr;

        LCSipTransports t_config;
        IntPtr t_configPtr;

        Thread core_loop;
		bool running;

        IntPtr calls_default_params;

        IntPtr proxy_cfg;

        List<LinphoneCallPtr> calls = new List<LinphoneCallPtr>();
        LinphoneCallPtr FindCall(IntPtr call)
        {
            return calls.Find(delegate (LinphoneCallPtr obj) {
                return (obj.Ptr == call);
            });
        }

        public void createPhone(string username, string password, string server, int port, string agent, string version)
		{
			this.running = true;
			this.registration_state_changed = new LinphoneCoreRegistrationStateChangedCb(OnRegistrationChanged);
            this.call_state_changed = new LinphoneCoreCallStateChangedCb(OnCallStateChanged);
			this.message_received = new LinphoneCoreMessageReceivedCb(OnMessageReceived);
            this.vtable = new LinphoneCoreVTable()
			{
				global_state_changed = IntPtr.Zero,
				registration_state_changed = Marshal.GetFunctionPointerForDelegate(registration_state_changed),
				call_state_changed = Marshal.GetFunctionPointerForDelegate(call_state_changed),
				notify_presence_received = IntPtr.Zero,
				new_subscription_requested = IntPtr.Zero,
				auth_info_requested = IntPtr.Zero,
				call_log_updated = IntPtr.Zero,
				message_received = Marshal.GetFunctionPointerForDelegate(message_received),
				is_composing_received = IntPtr.Zero,
				dtmf_received = IntPtr.Zero,
				refer_received = IntPtr.Zero,
				call_encryption_changed = IntPtr.Zero,
				transfer_state_changed = IntPtr.Zero,
				buddy_info_updated = IntPtr.Zero,
				call_stats_updated = IntPtr.Zero,
				info_received = IntPtr.Zero,
				subscription_state_changed = IntPtr.Zero,
				notify_received = IntPtr.Zero,
				publish_state_changed = IntPtr.Zero,
				configuring_status = IntPtr.Zero,
				display_status = IntPtr.Zero,
				display_message = IntPtr.Zero,
				display_warning = IntPtr.Zero,
				display_url = IntPtr.Zero,
				show = IntPtr.Zero,
				text_received = IntPtr.Zero,
				file_transfer_recv = IntPtr.Zero,
				file_transfer_send = IntPtr.Zero,
				file_transfer_progress_indication = IntPtr.Zero,
				network_reachable = IntPtr.Zero,
				log_collection_upload_state_changed = IntPtr.Zero,
				log_collection_upload_progress_indication = IntPtr.Zero
			};
			this.vtablePtr = Marshal.AllocHGlobal(Marshal.SizeOf(this.vtable));
			Marshal.StructureToPtr(vtable, this.vtablePtr, false);

			this.linphoneCore = linphone_core_new(this.vtablePtr, null, null, IntPtr.Zero);

            core_loop = new Thread(LinphoneMainloop);
            core_loop.IsBackground = false;
            core_loop.Start();

            t_config = new LCSipTransports()
            {
                udp_port = -1,
                tcp_port = -1,
                dtls_port = -1,
                tls_port = -1
            };
            t_configPtr = Marshal.AllocHGlobal(Marshal.SizeOf(t_config));
            Marshal.StructureToPtr(t_config, t_configPtr, false);

            linphone_core_set_sip_transports(linphoneCore, t_configPtr);
            linphone_core_set_user_agent(linphoneCore, agent, version);

            calls_default_params = linphone_core_create_default_call_parameters(linphoneCore);
            linphone_call_params_enable_video(calls_default_params, false);
            linphone_call_params_enable_early_media_sending(calls_default_params, true); //Test if absolutely necessary

            identity = "sip:" + username + "@" + server;
            server = "sip:" + server + ":" + port.ToString();

            auth_info = linphone_auth_info_new(username, null, password, null, null, null);
            linphone_core_add_auth_info(linphoneCore, auth_info);

            proxy_cfg = linphone_core_create_proxy_config(linphoneCore);
            linphone_proxy_config_set_identity(proxy_cfg, identity);
            linphone_proxy_config_set_server_addr(proxy_cfg, server);
            linphone_proxy_config_enable_register(proxy_cfg, true);
            linphone_core_add_proxy_config(linphoneCore, proxy_cfg);
            linphone_core_set_default_proxy_config(linphoneCore, proxy_cfg);
        }
			
		public void destroyPhone()
		{
			if (this.RegistrationStateChangedEvent != null)
			{
				this.RegistrationStateChangedEvent(LinphoneRegistrationState.LinphoneRegistrationProgress);
			}

			// TODO: terminate and destroy everything.
		}

        public void LinphoneMainloop()
        {
            while (running)
            {
                linphone_core_iterate(linphoneCore);

                //Sleep 50 millis
                Thread.Sleep(50);
            }

            //No longer running, free resources
            linphone_core_destroy(linphoneCore);

            if (vtablePtr != IntPtr.Zero)
                Marshal.FreeHGlobal(vtablePtr);
            if (t_configPtr != IntPtr.Zero)
                Marshal.FreeHGlobal(t_configPtr);

            registration_state_changed = null;
            //call_state
        }

        public void makeCall(string uri)
        {
            if (linphoneCore == IntPtr.Zero || !running)
            {
                if (ErrorEvent != null)
                    ErrorEvent(null, "Cannot make or receive calls.");
                return;
            }

            IntPtr call = linphone_core_invite(linphoneCore, uri);

            if (call == IntPtr.Zero)
            {
                if (ErrorEvent != null)
                    ErrorEvent(null, "Cannot call.");
            }
        }

        public delegate void RegistrationStateChangedDelegate(LinphoneRegistrationState state);
		public event RegistrationStateChangedDelegate RegistrationStateChangedEvent;

		// TODO: Add CallStateChangedEvent and ChatMessageChangedEvent.

		void OnRegistrationChanged(IntPtr lc, IntPtr cfg, LinphoneRegistrationState cstate, string message)
		{
			if (this.linphoneCore == IntPtr.Zero || !this.running)
			{
				return;
			}

			if (this.RegistrationStateChangedEvent != null)
			{
				this.RegistrationStateChangedEvent(cstate);
			}
		}

        // TODO: Add OnCallStateChanged and OnChatMessageStateChanged.
        void OnCallStateChanged(IntPtr lc, IntPtr call, LinphoneCallState cstate, string message)
        {
            if (linphoneCore == IntPtr.Zero || !running) return;
            #if (TRACE)
            Console.WriteLine("OnCallStateChanged: {0}", cstate);
            #endif

            Call.State newstate = Call.State.None;
            Call.CallType newtype = Call.CallType.None;
            string from = "";
            string to = "";
            IntPtr addressStringPtr;

            // detecting direction, state and source-destination data by state
            switch (cstate)
            {
                case LinphoneCallState.LinphoneCallIncomingReceived:
                    newstate = Call.State.Ringing;
                    linphone_core_accept_call(linphoneCore, call);
                    break;

                case LinphoneCallState.LinphoneCallIncomingEarlyMedia:
                    newstate = Call.State.Loading;
                    newtype = Call.CallType.Incoming;
                    addressStringPtr = linphone_call_get_remote_address_as_string(call);
                    if (addressStringPtr != IntPtr.Zero) from = Marshal.PtrToStringAnsi(addressStringPtr);
                        to = identity;
                    break;

                case LinphoneCallState.LinphoneCallConnected:
                case LinphoneCallState.LinphoneCallStreamsRunning:
                case LinphoneCallState.LinphoneCallPausedByRemote:
                case LinphoneCallState.LinphoneCallUpdatedByRemote:
                    newstate = Call.State.Active;
                    break;

                case LinphoneCallState.LinphoneCallOutgoingInit:
                case LinphoneCallState.LinphoneCallOutgoingProgress:
                case LinphoneCallState.LinphoneCallOutgoingRinging:
                    newstate = Call.State.Ringing;
                    break;

                case LinphoneCallState.LinphoneCallOutgoingEarlyMedia:
                    newstate = Call.State.Loading;
                    newtype = Call.CallType.Outcoming;
                    addressStringPtr = linphone_call_get_remote_address_as_string(call);
                    if (addressStringPtr != IntPtr.Zero) to = Marshal.PtrToStringAnsi(addressStringPtr);
                    from = this.identity;
                    break;

                case LinphoneCallState.LinphoneCallError:
                    newstate = Call.State.Error;
                    break;

                case LinphoneCallState.LinphoneCallReleased:
                case LinphoneCallState.LinphoneCallEnd:
                    newstate = Call.State.Completed;
                    if (linphone_call_params_get_record_file(calls_default_params) != IntPtr.Zero)
                        linphone_call_stop_recording(call);
                    break;

                default:
                    break;
            }

            //Change the calls state or create a new call if it doesn't exist yet
            LinphoneCallPtr existCall = FindCall(call);
            if (existCall == null)
            {
                existCall = new LinphoneCallPtr();
                existCall.state = newstate;
                existCall.call_type = newtype;
                existCall.from = from;
                existCall.to = to;
                existCall.Ptr = call;

                calls.Add(existCall);

                if ((CallStateChangedEvent != null))
                    CallStateChangedEvent(existCall);
            }
            else
            {
                if (existCall.state != newstate)
                {
                    existCall.state = newstate;
                    CallStateChangedEvent(existCall);
                }
            }
        }
		void OnMessageReceived(IntPtr lc, IntPtr chat_room, IntPtr msg) {
			//TODO: add functionality
        }

    }
}
