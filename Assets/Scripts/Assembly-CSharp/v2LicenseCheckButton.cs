using System;
using UnityEngine;

public class v2LicenseCheckButton : MonoBehaviour
{
	private class LicensingServiceCallback : AndroidJavaProxy
	{
		private v2LicenseCheckButton m_CheckLicenseButton;

		public LicensingServiceCallback(v2LicenseCheckButton checkLicenseButton)
			: base("com.google.licensingservicehelper.LicensingServiceCallback")
		{
			m_CheckLicenseButton = checkLicenseButton;
		}

		public void allow(string payloadJson)
		{
			Debug.Log("allow access");
			m_CheckLicenseButton.processResponse("Allow access\nPayload: " + payloadJson);
		}

		public void dontAllow(AndroidJavaObject pendingIntent)
		{
			Debug.Log("deny access");
			m_CheckLicenseButton.processResponse("Deny access");
			m_CheckLicenseButton.m_LicensingHelper.Call("showPaywall", pendingIntent);
			m_CheckLicenseButton.m_Activity.Call("finish");
		}

		public void applicationError(string errorMessage)
		{
			Debug.Log("application error");
			m_CheckLicenseButton.processResponse("Application error: " + errorMessage);
		}
	}

	private AndroidJavaObject m_Activity;

	private AndroidJavaObject m_LicensingHelper;

	private string m_PublicKey_Base64 = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAz3BhSIagdPPVIl/y3It+CjeNJjxTgzwvaGQUUcK6XRjB4PbGW2uRV0rcN6a6L8CrjGJAHo1UjQgmfzA9FBmylRNeGST3jIesZmv8kZT/MC27dh4XqyXZlkCw8XKSPFwkJbavYY2Q07zf+bT2l/HC27GCQ46mCKvRzY2VX0bh1djmutOyOyx6t179y2hcbQ/OlXf7TL8K8ty9HrBMBFA6w0FV47jLVJtxxzULvqZyW4cvG9jh5rSBHrYFHzJ382y/CeE68/pFianQHcSGNZ2tbZt+w+bvvlV4NuXJ/T9MhqqeBj3oh1xe2n40L1D16a3HpJ0Zc92TqChpXoO0MSRgKwIDAQAB";

	private bool m_RunningOnAndroid;

	private string m_ButtonMessage = string.Empty;

	private bool m_ButtonEnabled = true;

	private bool m_LVL_Received;

	private string m_Result;

	private void Start()
	{
		m_RunningOnAndroid = new AndroidJavaClass("android.os.Build").GetRawClass() != IntPtr.Zero;
		if (m_RunningOnAndroid)
		{
			m_Activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
			m_LicensingHelper = new AndroidJavaObject("com.google.licensingservicehelper.LicensingServiceHelper", m_Activity, m_PublicKey_Base64);
			m_LicensingHelper.Call("checkLicense", new LicensingServiceCallback(this));
		}
	}

	private void processResponse(string result)
	{
		Debug.Log("mjt result: " + result);
		m_LVL_Received = true;
		m_ButtonMessage = "Check LVL";
		m_ButtonEnabled = true;
		m_Result = result;
	}
}
