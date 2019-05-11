using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    class TextContent
    {
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public TextContent(string text)
        {
            this.text = text;
        }
    }
    class TextMessage:IMessage
    {
        private List<string> ipsTarget = new List<string>();
        public List<string> IpsTarget
        {
            get { return this.ipsTarget; }
            set { this.ipsTarget = value; }
        }
        private string textContent;
        public object Content
        {
            get { return this.textContent;}
            set { this.textContent = value as string;}
        }
        private string sender;
        public string Sender
        {
            get { return this.sender; }
            set { this.sender = value; }
        }
        private int size;
        public int Size
        {
            get { return this.size; }
            set { this.size = value; }
        }
        public TextMessage(List<string>ipsTarget, string text, string sender)
        {
            this.IpsTarget = ipsTarget;
            this.Content = text;
            this.Sender = sender;
        }

        public TextMessage(byte[] data)
        {
            int place = 0;
            int IPListCount = BitConverter.ToInt32(data, place);
            place += 4;
            for(int i=0; i<IPListCount; i++)
            {
                int ipLength = BitConverter.ToInt32(data, place);
                place += 4;
                this.IpsTarget.Add(Encoding.ASCII.GetString(data, place, ipLength));
                place += ipLength;
            }
            int textLength = BitConverter.ToInt32(data, place);
            place += 4;
            this.Content = Encoding.ASCII.GetString(data, place, textLength);
            int senderLength = BitConverter.ToInt32(data, place);
            place += 4;
            this.sender = Encoding.ASCII.GetString(data, place, senderLength);
        }

        public byte[] ConvertToBytes()
        {
            byte[] result = new byte[1024];
            int place = 0;
            Buffer.BlockCopy(BitConverter.GetBytes(IpsTarget.Count), 0, result, place, 4);
            place += 4;
            foreach(string ip in IpsTarget)
            {
                Buffer.BlockCopy(BitConverter.GetBytes(ip.Length), 0, result, place, 4);
                place += 4;
                Buffer.BlockCopy(Encoding.ASCII.GetBytes(ip), 0, result, place, ip.Length);
                place += ip.Length;
            }
            Buffer.BlockCopy(BitConverter.GetBytes((Content as string).Length), 0, result, place, 4);
            place += 4;
            Buffer.BlockCopy(Encoding.ASCII.GetBytes(Content as string), 0, result, place, (Content as string).Length);
            place += (Content as string).Length;
            Buffer.BlockCopy(BitConverter.GetBytes(sender.Length), 0, result, place, 4);
            place += 4;
            Buffer.BlockCopy(Encoding.ASCII.GetBytes(sender), 0, result, place, sender.Length);
            place += sender.Length;
            this.Size = place;
            return result;
        }
    }
}
