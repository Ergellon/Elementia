namespace TrueVK.Core
{
	/// <summary>
	/// Application Access Permissions. http://vk.com/dev/permissions
	/// </summary>
	public enum Permissions  
	{
		/// <summary>
		///(+1)	User allowed to send notifications to him/her. (flash/iframe-applications).
		/// </summary>
		Notify = 1, 

		/// <summary>
		///(+2)	Access to friends.
		/// </summary>
		Friends = 2, 

		/// <summary>
		///(+4)	Access to photos.
		/// </summary>
		Photos = 4,

		/// <summary>
		///(+8)	Access to audios.
		/// </summary>
		Audio = 8,

		/// <summary>
		///(+16) Access to videos.
		/// </summary>
		Video = 16,

		/// <summary>
		///(+131072) Access to documents.
		/// </summary>
		Docs = 131072,

		/// <summary>
		///(+2048) Access to user notes.
		/// </summary>
		Notes = 2048,

		/// <summary>
		//(+128) Access to wiki pages.
		/// </summary>
		Pages = 128,

		/// <summary>
		///(+256) Addition of link to the application in the left menu.
		/// </summary>
		AddAppToMenu= 256,

		/// <summary>
		///(+1024) Access to user status.
		/// </summary>
		Status = 1024,

		/// <summary>
		///(+32) Access to offers (obsolete methods).
		/// </summary>
		Offers = 32,

		/// <summary>
		///(+64) Access to questions (obsolete methods).
		/// </summary>
		Questions = 64,

		/// <summary>
		///(+8192) Access to standard and advanced methods for the wall.
		/// Note that this access permission is unavailable for sites (it is ignored at attempt of authorization).
		/// </summary>
		Wall = 8192,

		/// <summary>
		///(+262144) Access to user groups.
		/// </summary>
		Groups = 262144,

		/// <summary>
		///(+4096) (for Standalone applications) Access to advanced methods for messaging.
		/// </summary>
		Messages = 4096,

		/// <summary>
		///(+4194304) User e-mail access. Available only for sites.
		/// </summary>
		Email = 4194304,

		/// <summary>
		///(+524288) Access to notifications about answers to the user.
		/// </summary>
		Notifications= 524288,

		/// <summary>
		///(+1048576) Access to statistics of user groups and applications where he/she is an administrator.
		/// </summary>
		Stats = 1048576,

		/// <summary>
		///(+32768) Access to advanced methods for Ads API.
		/// </summary>
		Ads = 32768,

		/// <summary>
		///(+65536) Access to API at any time.
		/// </summary>
		Offline = 65536 
	}
}