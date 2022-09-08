using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPC.CommandMod.Notification
{
    internal class NotificationMessage
    {
        public NotificationMessage()
        {
        }

        public NotificationMessage Write(string text)
        {
            _current.Add(text);
            return this;
        }

        public NotificationMessage WriteLine(string text)
        {
            _current.Add($"{text}<br>");
            return this;
        }

        public NotificationMessage NewLine()
        {
            _current.Add("<br>");
            return this;
        }

        public NotificationMessage Item(string name)
        {
            return WriteColor(name, Color.Item);
        }

        public NotificationMessage Location(string name)
        {
            return WriteColor(name, Color.Location);
        }

        public NotificationMessage Info(string name)
        {
            return WriteColor(name, Color.Info);
        }

        public NotificationMessage Number(string name)
        {
            return WriteColor(name, Color.Number);
        }

        private NotificationMessage WriteColor(string text, string colorName)
        {
            _current.Add($"<color={colorName}>{text}</color>");
            return this;
        }

        public string GetSendText()
        {
            var formatted = "";

            foreach(var str in _current)
            {
                formatted += str;
            }

            return formatted;
        }

        private List<string> _current = new List<string>();
    }
}
