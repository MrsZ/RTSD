using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinphoneCoreWrapper;

namespace LinphoneChat
{
    public class Chat
    {
        //sip-address of recipient. eg. "sip:joe@sip.linphone.org"
        private string destination_addr { get {return destination_addr;} set {destination_addr = value} }
		private LinphoneChatRoom chat_room;

		public Chat(IntPtr lc, string sip_addr) 
        {
            this.destination_addr = sip_addr;
            this.chat_room = create_chat_room(lc, sip_addr);
        }

        public LinphoneChatRoom create_chat_room(IntPtr lc, string addr) {
            return linphone_core_get_chat_room_from_uri(IntPtr lc, addr);
        }

		/*
        public bool show_received_message(IntPtr lc, LinphoneChat* chat_room, LinphoneAddress* from, LinphoneChatMessage* msg) {
			//TODO: implement callback functionality
            return 0;
        }
		*/

        public void send_message(LinphoneChatRoom* chat_room, LinphoneChatMessage msg) {
            LinphoneChatMessage msg_to_send = linphone_chat_room_create_message(chat_room, msg);
            linphone_chat_room_send_chat_message(chat_room, msg_to_send);
        }

		public void destroy_chat(LinphoneChatRoom chat_room) {
			linphone_chat_room_destroy(chat_room);
		}
    }
}