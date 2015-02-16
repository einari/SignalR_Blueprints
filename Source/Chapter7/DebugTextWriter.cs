using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Chapter7
{
    public class DebugTextWriter : TextWriter
    {
        private StringBuilder buffer;

        public DebugTextWriter()
        {
            buffer = new StringBuilder();
        }

        public override void Write(char value)
        {
            switch (value)
            {
                case '\n':
                    return;
                case '\r':
                    Debug.WriteLine(buffer.ToString());
                    buffer.Clear();
                    return;
                default:
                    buffer.Append(value);
                    break;
            }
        }

        public override void Write(string value)
        {
            Debug.WriteLine(value);

        }
        #region implemented abstract members of TextWriter
        public override Encoding Encoding
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
    }
}
