using AppLogic;
using DTO;
using DTO.Usuarios;
using iTextSharp.text.pdf.security;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Twilio;
using Twilio.Rest.Verify.V2.Service;

namespace NoLimitsSolutions.Controllers
{
    public class OTPController : ApiController
    {
        
        [HttpPost]
        
        public string EnviarOTP(OTP otp)
        {

            if (otp.channel == "sms")
            {
                string accountSid = "ACbd2cabbb9c244b60aab433b2820fad3c";
                string authToken = "112ef10e46d9a60578569639488992ca";
                TwilioClient.Init(accountSid, authToken);
                var verification = VerificationResource.Create(
                    //to: "+15017122661",
                    to: otp.to,
                    //channel: "sms",
                    channel: otp.channel,
                    pathServiceSid: "VA82b38cdbc6826428ba3214f7dc51d928"
                );

                Console.WriteLine(verification.Status);
                
                return verification.Status;
                

            }
            else if (otp.channel == "email")
            {
                string accountSid = "ACbd2cabbb9c244b60aab433b2820fad3c";
                string authToken = "112ef10e46d9a60578569639488992ca";

                TwilioClient.Init(accountSid, authToken);

                var verification = VerificationResource.Create(
                    //to: "+15017122661",
                    to: otp.to,
                    //channel: "sms",
                    channel: otp.channel,
                    pathServiceSid: "VA1aa60609a32a9eee385344f1034790cc"
                );

                Console.WriteLine(verification.Status);
                return verification.Status;

            }
            else
            {
                return "Error";

            }


        }

        [HttpPost]

        public string CheckOTP(OTP otp)
        {
            if (otp.code.Length == 4)
            {
                string accountSid = "ACbd2cabbb9c244b60aab433b2820fad3c";
                string authToken = "112ef10e46d9a60578569639488992ca";
                TwilioClient.Init(accountSid, authToken);

                var verificationCheck = VerificationCheckResource.Create(
                to: otp.to,
                code: otp.code,
                pathServiceSid: "VA82b38cdbc6826428ba3214f7dc51d928"
                );
                Console.WriteLine(verificationCheck.Status);

                if (verificationCheck.Status == "success")
                {

                }

                return verificationCheck.Status;

            }
            else if (otp.code.Length == 6)
            {
                string accountSid = "ACbd2cabbb9c244b60aab433b2820fad3c";
                string authToken = "112ef10e46d9a60578569639488992ca";
                TwilioClient.Init(accountSid, authToken);

                var verificationCheck = VerificationCheckResource.Create(
                to: otp.to,
                code: otp.code,
                pathServiceSid: "VA1aa60609a32a9eee385344f1034790cc"
                );
                Console.WriteLine(verificationCheck.Status);
          
                return verificationCheck.Status;

            }

            else
            {
                return "Error";
            }


        }
    }
}
