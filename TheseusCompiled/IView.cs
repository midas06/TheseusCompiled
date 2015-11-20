using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheseusCompiled
{
    public interface IView
    {
        // generic
        void Start();
        void Stop();
        void Display<T>(T message);
        // filer
        //int ChoosePool(string prompt);
        // game
        //string SetLevel(string prompt);
        // builder
        //Point SetDimensions(string prompt);
    }
}
