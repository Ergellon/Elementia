namespace TrueVK.Test
{
	using Core;
	using UnityEngine;
	using UnityEngine.UI;
	using System.Collections.Generic;
	using System;

	public class VKTest : MonoBehaviour {

		#region - Inspector Fields -

		/// <summary>
		/// Init button.
		/// </summary>
		public Button InitButton;

		/// <summary>
		/// Logout button.
		/// </summary>
		public Button LogoutButton;

		/// <summary>
		/// Get users button.
		/// </summary>
		public Button GetUsersButton;

		/// <summary>
		/// Create album button.
		/// </summary>
		public Button CreateAlbumButton;

		/// <summary>
		/// Input for app identifier.
		/// </summary>
		public InputField AppIdInput;

		/// <summary>
		/// Input for user identifiers.
		/// </summary>
		public InputField UserIds;

		/// <summary>
		/// JS login button.
		/// REMARK: We use JS button insted of default, because JS button allows intercept user clicks so browser does not block pop-ups window.
		/// </summary>
		public JSButton LoginButton;

		/// <summary>
		/// JS wall post button.
		/// REMARK: We use JS button insted of default, because JS button allows intercept user clicks so browser does not block pop-ups window.
		/// </summary>
		public JSButton WallPostButton;

		/// <summary>
		/// VK logger.
		/// </summary>
		public CanvasLog Logger;

		#endregion

		#region - Unity Lifecycle -

		public void Start () {
		
			InitButton.onClick.AddListener(() => HandleInitButtonClick());
			LogoutButton.onClick.AddListener(() => HandleLogoutButtonClick());
			GetUsersButton.onClick.AddListener(() => HandleGetUsersButtonClick());
			CreateAlbumButton.onClick.AddListener(() => HandleCreateAlbumButtonClick());

			LoginButton.Click += HandleLoginButtonClick;
			WallPostButton.Click += HandleWallPostClick;
		}	

		#endregion

		#region - Buttons Event Click Handlers -

		/// <summary>
		/// Handle initialization button click.
		/// </summary>
		private void HandleInitButtonClick ()
		{
			var appId = AppIdInput.text;

			if (string.IsNullOrEmpty(appId))
			{
				Logger.Log("Enter App Id");
			}
			else
			{
				VK.Init(appId);
			}

			if (VK.IsInitialized)
			{
				Logger.Log("VK initialized");
			}
		}

		/// <summary>
		/// Handle login button click.
		/// </summary>
		private void HandleLoginButtonClick (object sender, EventArgs e)
		{
			// Only for test we request all available pesmission.
			VK.Login(HandleVKLogin, 
			         Permissions.Video,
			         Permissions.Status,
			         Permissions.Wall,
			         Permissions.Stats,
			         Permissions.Questions,
			         Permissions.Photos,
			         Permissions.Pages,
			         Permissions.Offline,
			         Permissions.Offers,
			         Permissions.Notify,
			         Permissions.Notifications,
			         Permissions.Notes,
			         Permissions.Messages,
			         Permissions.Groups,
			         Permissions.Friends,
			         Permissions.Email,
			         Permissions.Docs,
			         Permissions.Audio,
			         Permissions.Ads,
			         Permissions.AddAppToMenu
			         );
		}

		/// <summary>
		/// Handle logout button click.
		/// </summary>
		private void HandleLogoutButtonClick ()
		{
			VK.Logout(HandleVKLogout);
		}

		/// <summary>
		/// Handle get users button click.
		/// </summary>
		private void HandleGetUsersButtonClick()
		{
			var userIds = string.IsNullOrEmpty(UserIds.text) ? "0" : UserIds.text;
			var parameters = new Dictionary<string, object>
			{
				{"user_ids", userIds},
				{"fields", "city"},
				{"name_case", "Nom"}
			};

			VK.Call(HandleVKGetUsers, "users.get", parameters);
		}
		
		/// <summary>
		/// Handle wall.post button click.
		/// </summary>
		private void HandleWallPostClick (object sender, EventArgs e)
		{
			var parameters = new Dictionary<string, object>
			{
				{"message", "TrueVK test."},
				{"friends_only", "1"},
				{"attachments", "photo1_385062313,https://vk.com"}
			};

			VK.Call(HandleVKWallPost, "wall.post", parameters, true);
		}

		/// <summary>
		/// Handle create.album button click.
		/// </summary>
		private void HandleCreateAlbumButtonClick ()
		{
			var parameters = new Dictionary<string, object>
			{
				{"title", "TrueVkTestAlbum"},
				{"description", "Description"}
			};
			
			VK.Call(HandleVKCreateAlbum, "photos.createAlbum", parameters);
		}
		
		#endregion - Buttons Event Click Handlers -
		
		#region - VK Api Callbacks -

		/// <summary>
		/// Login callbcak.
		/// </summary>
		/// <param name="response">Response.</param>
		private void HandleVKLogin (IResponseVK response)
		{
			var session = response.ResponseDictionary["session"] as Dictionary<string, object>;
			Logger.Log(string.Format("\nLogin completed. sid = {0}, expire = {1}", session["sid"], session["expire"]));

			var user = session["user"] as Dictionary<string, object>;
			Logger.Log(string.Format("userId = {0}, userName = {1}, userLastName= {2}", user["id"], user["first_name"], user["last_name"]));
		}

		/// <summary>
		/// Logout callback.
		/// </summary>
		private void HandleVKLogout (IResponseVK response)
		{
			Logger.Log("\nLogout completed");
		}

		/// <summary>
		/// Get.users callback.
		/// </summary>
		private void HandleVKGetUsers (IResponseVK response)
		{
			Logger.Log("\nUsers.get completed. ");
			
			if (response.ErrorCode != null)
			{
				Logger.Log(string.Format("Error code = {0}.", response.ErrorCode));
				return;
			}

			var users = response.ResponseDictionary["response"] as List<object>;
			foreach (var user in users)
			{
				var userDictionary = user as Dictionary<string, object>;

				var userId = userDictionary["uid"];
				var firstName = userDictionary["first_name"];
				var lastName = userDictionary["last_name"];

				object city;
				userDictionary.TryGetValue("city", out city);

				Logger.Log(string.Format("\nuserId = {0}, userName = {1}, userLastName= {2}, userCity = {3}",
				                  userId, firstName, lastName, city));
				
			}
		}

		/// <summary>
		/// Wall.post callback.
		/// </summary>
		private void HandleVKWallPost (IResponseVK response)
		{	
			Logger.Log("\nWall.post completed.");
			if (response.ErrorCode != null)
			{
				Logger.Log(string.Format("Error code = {0}.", response.ErrorCode));
				return;
			}

			var postIdDictionary = response.ResponseDictionary["response"] as Dictionary<string, object>;
			object postId;
			postIdDictionary.TryGetValue("post_id", out postId);
			Logger.Log(string.Format("Post_id = {0}", postId));

		}

		/// <summary>
		/// Create.album callback.
		/// </summary>
		/// <param name="response">Response.</param>
		private void HandleVKCreateAlbum (IResponseVK response)
		{
			Logger.Log("\nPhotos.CreateAlbum completed.");
			if (response.ErrorCode != null)
			{
				Logger.Log(string.Format("Error code = {0}.", response.ErrorCode));
				return;
			}

			var dictionary = response.ResponseDictionary["response"] as Dictionary<string, object>;
			object id;
			object ownerId;
			dictionary.TryGetValue("aid", out id);
			dictionary.TryGetValue("owner_id", out ownerId);
			Logger.Log(string.Format("Album id = {0}, owner id = {1}", id, ownerId));
		}

		#endregion - VK Api Callbacks -
	}
}
