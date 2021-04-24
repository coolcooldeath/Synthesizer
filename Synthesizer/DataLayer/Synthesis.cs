using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer.DataLayer
{
    class Synthesis 
    {
        
        
        public int Id { get; set; }
        public string Name { get; set; }
        public double Volume { get; set; }
        public float Attack { get; set; }
        public float Decay { get; set; }
        public float Sustain { get; set; }
        public float Release { get; set; }
        public int CutOff { get; set; }
        public float Q { get; set; }
        public int TremoloFreq { get; set; }
        public float ChorusDelay { get; set; }
        public float ChorusSweep { get; set; }
        public float ChorusWidth { get; set; }
        public float PhaserDry { get; set; }
        public float PhaserWet { get; set; }
        public float PhaserFeedback { get; set; }
        public float PhaserFreq { get; set; }
        public float PhaserWidth { get; set; }
        public float PhaserSweep { get; set; }
        public bool Filter { get; set; }
        public bool Tremolo { get; set; }
        public bool Vibrato { get; set; }
       
    }
}
