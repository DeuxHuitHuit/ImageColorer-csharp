//INSTANT C# TODO TASK: C# compiler constants cannot be set to explicit values:

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

namespace com.deuxhuithuit.ImageColorer.WebApp
{
#if _MyType != "Empty"

	namespace My
	{
		/// <summary>
		/// Module used to define the properties that are available in the My Namespace for Web projects.
		/// </summary>
		/// <remarks></remarks>
		
		internal static class MyWebExtension
		{
			private static ThreadSafeObjectProvider<Microsoft.VisualBasic.Devices.ServerComputer> s_Computer = new ThreadSafeObjectProvider<Microsoft.VisualBasic.Devices.ServerComputer>();
			private static ThreadSafeObjectProvider<Microsoft.VisualBasic.ApplicationServices.WebUser> s_User = new ThreadSafeObjectProvider<Microsoft.VisualBasic.ApplicationServices.WebUser>();
			private static ThreadSafeObjectProvider<Microsoft.VisualBasic.Logging.AspLog> s_Log = new ThreadSafeObjectProvider<Microsoft.VisualBasic.Logging.AspLog>();
			private static ThreadSafeObjectProvider<MyApplication> s_Application = new ThreadSafeObjectProvider<MyApplication>();

			/// <summary>
			/// Returns information about the current application.
			/// </summary>
			[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
			internal static MyApplication Application
			{
				get
				{
					return s_Application.GetInstance();
				}
			}

			/// <summary>
			/// Returns information about the host computer.
			/// </summary>
			[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
			internal static Microsoft.VisualBasic.Devices.ServerComputer Computer
			{
				get
				{
					return s_Computer.GetInstance();
				}
			}
			/// <summary>
			/// Returns information for the current Web user.
			/// </summary>
			[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
			internal static Microsoft.VisualBasic.ApplicationServices.WebUser User
			{
				get
				{
					return s_User.GetInstance();
				}
			}
			/// <summary>
			/// Returns Request object.
			/// </summary>
			[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode"), global::System.ComponentModel.Design.HelpKeyword("My.Request")]
			internal static global::System.Web.HttpRequest Request
			{
				[global::System.Diagnostics.DebuggerHidden()]
				get
				{
					global::System.Web.HttpContext CurrentContext = global::System.Web.HttpContext.Current;
					if (CurrentContext != null)
					{
						return CurrentContext.Request;
					}
					return null;
				}
			}
			/// <summary>
			/// Returns Response object.
			/// </summary>
			[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode"), global::System.ComponentModel.Design.HelpKeyword("My.Response")]
			internal static global::System.Web.HttpResponse Response
			{
				[global::System.Diagnostics.DebuggerHidden()]
				get
				{
					global::System.Web.HttpContext CurrentContext = global::System.Web.HttpContext.Current;
					if (CurrentContext != null)
					{
						return CurrentContext.Response;
					}
					return null;
				}
			}
			/// <summary>
			/// Returns the Asp log object.
			/// </summary>
			[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
			internal static Microsoft.VisualBasic.Logging.AspLog Log
			{
				[global::System.Diagnostics.DebuggerHidden()]
				get
				{
					return s_Log.GetInstance();
				}
			}

			/// <summary>
			/// Provides access to WebServices added to this project.
			/// </summary>
			[global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode"), global::System.ComponentModel.Design.HelpKeyword("My.WebServices")]
			internal static MyWebServices WebServices
			{
				[global::System.Diagnostics.DebuggerHidden()]
				get
				{
					return m_MyWebServicesObjectProvider.GetInstance();
				}
			}

			[global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never), Microsoft.VisualBasic.MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", ""), global::System.Runtime.CompilerServices.CompilerGenerated()]
			internal sealed class MyWebServices
			{

				[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never), global::System.Diagnostics.DebuggerHidden()]
				public override bool Equals(object o)
				{
					return base.Equals(o);
				}
				[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never), global::System.Diagnostics.DebuggerHidden()]
				public override int GetHashCode()
				{
					return base.GetHashCode();
				}
				[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never), global::System.Diagnostics.DebuggerHidden()]
				internal global::System.Type GetType()
				{
					return typeof(MyWebServices);
				}
				[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never), global::System.Diagnostics.DebuggerHidden()]
				public override string ToString()
				{
					return base.ToString();
				}

				[global::System.Diagnostics.DebuggerHidden()]
				private static T Create__Instance__<T>(T instance) where T: new()
				{
					if (instance == null)
					{
						return new T();
					}
					else
					{
						return instance;
					}
				}

				[global::System.Diagnostics.DebuggerHidden()]
				private void Dispose__Instance__<T>(ref T instance)
				{
					instance = null;
				}

				[global::System.Diagnostics.DebuggerHidden(), global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
				public MyWebServices() : base()
				{
				}
			}

			[global::System.Runtime.CompilerServices.CompilerGenerated()]
			private static readonly ThreadSafeObjectProvider<MyWebServices> m_MyWebServicesObjectProvider = new ThreadSafeObjectProvider<MyWebServices>();
		}

		[global::System.Runtime.CompilerServices.CompilerGenerated(), global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
		internal partial class MyApplication : Microsoft.VisualBasic.ApplicationServices.ApplicationBase
		{
		}

	}

#endif
}