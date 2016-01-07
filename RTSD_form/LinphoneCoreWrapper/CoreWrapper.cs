using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LinphoneCoreWrapper
{
    public class CoreWrapper
    {
		#region Import
        private const string LIBRARY_NAME = "Linphone.dll";

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

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void LinphoneCoreRegistrationStateChangedCb(IntPtr lc, IntPtr cfg, LinphoneRegistrationState cstate, string message);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate void LinphoneCoreCallStateChangedCb(IntPtr lc, IntPtr call, LinphoneCallState cstate, string message);

		#endregion

		LinphoneCoreRegistrationStateChangedCb registration_state_changed;
		//LinphoneCoreCallStateChangedCb call_state_changed; // TODO. remember to add into vtable;
		IntPtr linphoneCore;
		IntPtr vtablePtr;
		IntPtr auth_info;
		string identity;
		LinphoneCoreVTable vtable;
		bool running;

		public void createPhone(string username, string password, string server, int port, string agent, string version)
		{
			this.running = true;
			this.registration_state_changed = new LinphoneCoreRegistrationStateChangedCb(OnRegistrationChanged);
			this.vtable = new LinphoneCoreVTable()
			{
				global_state_changed = IntPtr.Zero,
				registration_state_changed = Marshal.GetFunctionPointerForDelegate(registration_state_changed),
				call_state_changed = IntPtr.Zero,//Marshal.GetFunctionPointerForDelegate(call_state_changed),
				notify_presence_received = IntPtr.Zero,
				new_subscription_requested = IntPtr.Zero,
				auth_info_requested = IntPtr.Zero,
				call_log_updated = IntPtr.Zero,
				message_received = IntPtr.Zero,
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

			// TODO: Add coreloop and defaultparams.

		}
			
		public void destroyPhone()
		{
			if (this.RegistrationStateChangedEvent != null)
			{
				this.RegistrationStateChangedEvent(LinphoneRegistrationState.LinphoneRegistrationProgress);
			}

			// TODO: terminate and destroy everything.
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
    }
}
