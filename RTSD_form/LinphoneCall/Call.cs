using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//PODO Namespace possible naming issue, change if something arises
namespace LinphoneCall
{
    public class Call
    {
        public enum CallType
        {
            None,
            Incoming,
            Outcoming
        }
        public enum State
        {
            None,
            Loading,
            Active,
            Completed,
            Error
        }

        public CallType call_type { get; set; }
        public State state { get; set; }
        public string from { get; set; }
        public string to { get; set; }

        public Call()
        {
            call_type = CallType.None;
            state = State.None;

            from = "";
            to = "";
        }
    }
}
