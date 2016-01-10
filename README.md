# **RTSD**
Repository for Real Time Something Software Development course programming exercise.
RTSD contains two projects, LinphonedotNet and RTSD_form. 

##1. LinphonedotNet.dll

###Introduction
Based on and extends the functionality of the github project [sipdotnet](https://github.com/bedefaced/sipdotnet) by github user [bedefacet](https://github.com/bedefaced). 

*LinphonedotNet* is a a C# wrapper for the *liblinphone API* Linphone provides. Currently it has been tested to work on windows versions 10 and 8.1. The wrapper encloses basic calling and messaging functionality from the host library and wraps them to a more graspable object oriented approach. This functionality can be accessed mainly from the *Phone* class.

###Requirements
 1. *dotnet v.4.5* or higher
 2. *C liblinphone libraries v.3.90* or possibly higher
 3. *zlib.dll*
 
###Install
 1. Aquire a copy of the *Liblinphone C API*. ([http://www.linphone.org/.../downloads](http://www.linphone.org/technical-corner/liblinphone/downloads))
 2. Copy the dll files from the */bin* folder to your executable's directory *
 3. Build the project
 
** Optionally instead of step 2, you can set your system path so your computer automatically finds these libraries whenever necessary.*
	
###Current functionality
	//Authentication
	Connect();
	Disconnect();
	
	//Callbacks
	OnPhoneConnected();
	OnPhoneDisconnected();
	OnIncomingCall(Call call);
	OnCallRinging(Call call);
	OnCallActive(Call call);
	OnCallCompleted(Call call);
	OnCallError(Call call, Error error);
	OnMessageReceived(Chatroom room, LinphoneMessage message);
    		
   	//Actions
   	makeCall(string uri)
   	sendMessage(string uri, string message);

##2. RTSD_form.dll

###Introduction
RTSD_form is a simple example project that shows how use LinphonedotNet and can be used as a starting point or an example on how to use the library.

###Requirements
LinphonedotNet library and all it's requirements

###Usage
Build the project and you can run the executable.
