using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheseusCompiled
{
    interface IView_Game
    {
        void Start();
        void Stop();
        int SetLevel(string prompt);
        void Display<T>(T message);
    }
}
