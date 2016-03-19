using System;
#if true
using Twilio;

namespace SportRadarPlayByPlay
{
    public class Alerter
    {
        const string TwilioAccountSid = "AC6d2473613c874057901961332489861d";
        const string TwilioAuthToken = "83252b3397448cf61693419440122ee8";
        const string TwilioSourcePhoneNumberSid = "PN8cbfc7f39bacccb03ad7bca48ba35591";
        const string TwilioPhoneNumber = "+17812096258";

        public static string AlertUsers(string url, string msg)
        {
            System.Diagnostics.Debug.Assert(Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute));

            var client = new TwilioRestClient(TwilioAccountSid, TwilioAuthToken);
            var destinationPhone = "+17814679575";

            msg += " http://blog.codingoutloud.com";
            string[] gameLinks = { "http://blog.codingoutloud.com", "http://bostonazure.org" };

            var response = client.SendMessage(TwilioPhoneNumber, destinationPhone, msg); // , gameLinks);

            destinationPhone = "+17812238770";
            response = client.SendMessage(TwilioPhoneNumber, destinationPhone, msg); // , gameLinks);

            return response.Body;
        }
    }
}
#endif

