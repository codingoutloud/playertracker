using System;
using System.Collections.Generic;
using Twilio;

namespace SportRadarPlayByPlay
{
    public class Alerter
    {
#if false
        const string TwilioAccountSid = "AC6d2473613c874057901961332489861d";
        const string TwilioAuthToken = "83252b3397448cf61693419440122ee8";
        const string TwilioSourcePhoneNumberSid = "PN8cbfc7f39bacccb03ad7bca48ba35591";
        const string TwilioPhoneNumber = "+17812096258";
#else
        const string TwilioAccountSid = "ACcbf6661cd3bc9a63c2f3bc5a38f87b82";
        const string TwilioAuthToken = "c8d0cbf8a84329d3ed67fa6d43ef8205";
        const string TwilioPhoneNumber = "+17813814076";
#endif
        private static List<string> GetDestinationPhoneNumbers()
        {
            var phoneNumbers = new List<string>();
            phoneNumbers.Add("+17814679575");

            return phoneNumbers;
        }
   
        public static string AlertUsers(string url, string msg)
        {
            System.Diagnostics.Debug.Assert(Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute));

            var phoneNumbers = GetDestinationPhoneNumbers();

            var client = new TwilioRestClient(TwilioAccountSid, TwilioAuthToken);

            msg += " " + url;

            var response = String.Format("Begin processing at {0}\n", DateTime.Now.ToLongTimeString());

            foreach (var phoneNumber in phoneNumbers)
            {
                var r = client.SendMessage(TwilioPhoneNumber, phoneNumber, msg);
                if (r.RestException != null)
                {                  
                    response += String.Format("Exception sending to {0}: {1}\n", phoneNumber, r.RestException.Message);
                }
                else
                {
                    response += String.Format("Successfully sent to {0}\n", phoneNumber);
                }
            }
            return response;
        }
    }
}

