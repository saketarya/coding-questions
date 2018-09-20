using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures
{
    public delegate void PrintMessage(string s);
    //public delegate void PrintMessage(Car c); 
    abstract class AbsBase
    {
        private string Msg;
        internal abstract void PrimtMe();

        internal string Message
        {
            get { return this.Msg; }
            private set { this.Msg = value; }
        }
        
    }

    class Kid1 : AbsBase
    {
        internal override void PrimtMe()
        {
            throw new NotImplementedException();
        }
    }
}
