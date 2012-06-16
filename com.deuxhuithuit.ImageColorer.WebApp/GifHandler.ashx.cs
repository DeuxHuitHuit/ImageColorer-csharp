//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Drawing;
using NTR.API.Imaging;

namespace com.deuxhuithuit.ImageColorer.WebApp
{
	namespace Handlers
	{
		public class GifHandler : NTR.API.HttpHandlers.ImageHttpHandler
		{
			public override void ProcessRequest(HttpContext context)
			{

				context.SkipAuthorization = true;

				string colorInput = context.Request["color"];
				string victimInput = context.Request["victim"];
				string imageInput = context.Request["image"];

				string cacheKey = string.Format("{0}-{1}", colorInput, imageInput);
				string cacheKeyC = cacheKey + "-c";

				if (!(string.IsNullOrWhiteSpace(colorInput)) && !(string.IsNullOrWhiteSpace(imageInput)) && !(imageInput.Contains("\\")) && !(imageInput.Contains("/"))) // prevent path traversal
				{

					string fullPath = context.Server.MapPath("~/refs/" + imageInput + ".gif");
					Color victimColor = Core.GifImage.ParseColor(victimInput);
					Color newColor = Core.GifImage.ParseColor(colorInput);

					if (newColor != null && System.IO.File.Exists(fullPath))
					{

						if (victimColor == new Color())
						{
							victimColor = Color.Black;
						}

						// Try cache
						//Dim o As Object = context.Cache(cacheKey)
						//Dim oc As Object = context.Cache(cacheKeyC)
						//If o IsNot Nothing AndAlso oc IsNot Nothing Then

						//    Dim b As Byte() = TryCast(o, Byte())
						//    Dim c As String = TryCast(oc, String)

						//    SetCacheInfos(context)
						//    SendImage(context, b, c)

						//    Exit Sub
						//End If

						try
						{
							Image imgObj = Image.FromFile(fullPath);

							// Replace victim colors
							Core.GifImage.ConverToGifImageWithNewColor(ref imgObj, imgObj.Palette, victimColor, newColor);

							// Create ByteImage
							ByteImage img = ByteImage.FromImage(ref imgObj, System.Drawing.Imaging.ImageFormat.Gif);
							string contentType = "gif";

							// Set client cache infos
							SetCacheInfos(context);

							// Send image
							SendImage(context, img.GetBuffer(), contentType);

							// Add to Server cache
							//Dim st As TimeSpan = TimeSpan.FromHours(1)
							//context.Cache.Insert(cacheKey, img.GetBuffer, Nothing, Date.MaxValue, st)
							//context.Cache.Insert(cacheKeyC, contentType, Nothing, Date.MaxValue, st)

							// Clear pointer
							imgObj.Dispose();
							imgObj = null;
							img = null;

							// Stop all processing here: we're done
							return;

						}
						catch (Exception ex)
						{
							// - rien faire
							throw; // Debug purpose
						}
					}
				}

				// Image non trouvée
				context.Response.StatusCode = 404;
				context.Response.Flush();
			}

			private static void SetCacheInfos(HttpContext context)
			{
				context.Response.Cache.SetCacheability(HttpCacheability.Public);
				context.Response.Cache.SetAllowResponseInBrowserHistory(true);
				context.Response.Cache.SetExpires(DateTime.Now.AddYears(1));
			}
		}
	}

}