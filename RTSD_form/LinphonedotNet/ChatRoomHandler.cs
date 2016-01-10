using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LiblinphonedotNET
{
    public class ChatRoomHandler
    {
        List<ChatRoom> chat_rooms;

        public ChatRoomHandler()
        {
            chat_rooms = new List<ChatRoom>();
        }

        public void addChatRoom(string name, IntPtr chat_room)
        {
            if (findChatRoom(chat_room) == -1)
                chat_rooms.Add(new ChatRoom(chat_room, name));
        }

        public void destroyChatRoom(IntPtr chat_room_param)
        {
            int chat_index = findChatRoom(chat_room_param);
            if (chat_index != -1)
                chat_rooms.RemoveAt(chat_index);
        }

        public int Count()
        {
            return chat_rooms.Count();
        }
        public string getText(int index)
        {
            return chat_rooms[index].getTextLog();
        }

        /// <summary>
        /// Takes a "linphone chat room" and "linphone msg" as IntPtr:s and adds the msg to the correct ChatRoom 
        /// </summary>
        /// <param name="chat_room_param">linphone chat room IntPtr</param>
        /// <param name="msg">linphone message IntPtr</param>
        public void receiveMessage(string partner, IntPtr chat_room_param, IntPtr msg)
        {
            int chat_index = findChatRoom(chat_room_param);
            if (chat_index == -1)
            {
                ChatRoom new_room = new ChatRoom(chat_room_param, partner);
                new_room.addMessage(msg);
                chat_rooms.Add(new_room);
            }
            else
            {
                chat_rooms[chat_index].addMessage(msg);
            }
        }

        public ChatRoom getChatRoom(IntPtr chat_room)
        {
            int chat_index = findChatRoom(chat_room);
            if (chat_index != -1)
                return chat_rooms[chat_index];
            return null;
        }

        private int findChatRoom(IntPtr chat_room_param)
        {
            for (int iterator = 0; iterator < chat_rooms.Count; iterator++)
                if (chat_rooms[iterator].isSame(chat_room_param))
                    return iterator;
            return -1;
        }
    }
}
