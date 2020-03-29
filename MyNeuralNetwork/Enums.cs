using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNeuralNetwork
{
    public enum LogOptions
    {
        PrintFirstState,
        PrintTrainingNetwork
    }

    public enum DrawOptions
    {
        DrawWeights,
        DontDrawWeights
    }

    public enum SignalType
    {
        Sinus,
        Image
    }

    public enum ImageType
    {
        FromFile,
        FromDrawer
    }
}
